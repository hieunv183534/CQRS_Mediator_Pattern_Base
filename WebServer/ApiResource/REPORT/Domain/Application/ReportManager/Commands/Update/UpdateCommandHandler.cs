using AutoMapper;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using NOM.DomainGlobal.Interfaces;
using NOM.DomainGlobal.Models.FileCenter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RT.Comb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private IUserService _user;
        private IMediator _mediator;
        private IFileCenterService _file;

        public UpdateCommandHandler(
            ApplicationDbContext context, 
            IMapper mapper, 
            IUserService user, 
            IMediator mediator,
            IFileCenterService file)
        {
            _mapper = mapper;
            _context = context;
            _user = user;
            _mediator = mediator;
            _file = file;
        }

        public async Task<long> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var dataOld = await _context.ReportManager.FindAsync(request.Id);
            var FileTemplateOld = dataOld.FileTemplate;

            var dateNew = _mapper.Map<NOM.Dao.Entities.ReportManager>(request);

            if (request.Name != dataOld.Name && await _context.ReportManager.AnyAsync(x => x.Name == request.Name))
            {
                throw new ValidationException("Name", "Mã báo cáo đã bị trùng");
            }

            
            foreach (var item in dateNew.ReportManagerParam)
            {
                if (item.Id == 0)
                {
                    item.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
                }
            }

            // tự sinh id cho list dataset
            foreach (var item in dateNew.ReportManagerDataSet)
            {
                if (item.Id == 0)
                {
                    item.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
                }    
            }

            // tự sinh id cho list group by
            foreach (var item in dateNew.ReportManagerGroupBy)
            {
                if (item.Id == 0)
                {
                    item.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
                }
            }

            // xóa params cũ
            var listParamsOld = await _context.ReportManagerParam.Where(x => x.ReportManagerId == request.Id).ToArrayAsync();
            _context.ReportManagerParam.RemoveRange(listParamsOld);

            // xóa dada set cũ
            var listDataSetOld = await _context.ReportManagerDataSet.Where(x => x.ReportManagerId == request.Id).ToArrayAsync();
            _context.ReportManagerDataSet.RemoveRange(listDataSetOld);

            // xóa group by cũ
            var listGroupByOld = await _context.ReportManagerGroupBy.Where(x => x.ReportManagerId == request.Id).ToArrayAsync();
            _context.ReportManagerDataSet.RemoveRange(listDataSetOld);

            // update file
            dataOld.Name = dateNew.Name;
            dataOld.Description = dateNew.Description;
            dataOld.FileTemplate = dateNew.FileTemplate;

            dataOld.ReportManagerParam = dateNew.ReportManagerParam;
            dataOld.ReportManagerDataSet = dateNew.ReportManagerDataSet;
            dataOld.ReportManagerGroupBy = dateNew.ReportManagerGroupBy;

            await _context.SaveChangesAsync(cancellationToken);

            // update file đã được sử ụng để hệ thống ko dọn mất file tạm
            await _file.SynFile(new SynFileModel
            {
                DataOld = new
                {
                    FileTemplate =  FileTemplateOld
                },
                DataNew = new {
                    FileTemplate = dateNew.FileTemplate
                }
            });
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}

