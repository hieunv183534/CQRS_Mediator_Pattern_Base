using AutoMapper;
using NOM.Common.Ultilities;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using NOM.DomainGlobal.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RT.Comb;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private IUserService _user;
        private IMediator _mediator;
        
        public CreateCommandHandler(ApplicationDbContext context, IMapper mapper, IUserService user, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;
            _user = user;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {

            var reportmanager = _mapper.Map<NOM.Dao.Entities.ReportManager>(request);

            // sinh id cho report
            reportmanager.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
            // logic tìm dường dẫn tạo report
            var parentReport = await _context.ReportManager.FindAsync(request.ParentId);
            //nếu cha của report cần thêm không phải là thư mục thì tạo mới report cùng cấp với report cha
            if(parentReport != null)
            {
                if (parentReport.Type != 1)
                {
                    reportmanager.ParentId = parentReport.ParentId;
                    reportmanager.ParentTag = HandleParentTag.ChangeIdInParentTag(parentReport.ParentTag, reportmanager.Id);
                } else
                {
                    //reportmanager.ParentTag = parentReport.ParentTag + reportmanager.ParentId + ",";
                    reportmanager.ParentTag = HandleParentTag.addIdToParentTag(parentReport.ParentTag, reportmanager.Id);
                }
                
            } else
            {
                reportmanager.ParentTag = "," + reportmanager.Id + ",";
                reportmanager.ParentTag = HandleParentTag.GenaretaParentTag(reportmanager.Id);
            }


            // tự sinh id cho list params
            foreach (var item in reportmanager.ReportManagerParam)
            {
                item.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
            }

            // tự sinh id cho list dataset
            foreach (var item in reportmanager.ReportManagerDataSet)
            {
                item.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
            }

            // tự sinh id cho list group
            foreach (var item in reportmanager.ReportManagerGroupBy)
            {
                item.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
            }

            //reportmanager.Id = new Random().Next(1, 99999999);
            if (await _context.ReportManager.AnyAsync(x => x.Name == request.Name && x.Type == request.Type))
            {
                throw new ValidationException("Name", "Tên đã bị trùng");
            }

            _context.ReportManager.Add(reportmanager);
            // đánh dấu không phải file rác
            //await _mediator.Send(new SynFileCommand
            //{
            //    DataNew = reportmanager
            //});
            await _context.SaveChangesAsync(cancellationToken);


            return reportmanager.Id;
        }
    }
}

