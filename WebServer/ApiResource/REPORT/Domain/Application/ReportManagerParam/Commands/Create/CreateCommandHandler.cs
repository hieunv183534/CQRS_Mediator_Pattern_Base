using AutoMapper;
using NOM.Dao.Entities;
using NOM.DomainGlobal.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RT.Comb;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerParam.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private IUserService _user;

        public CreateCommandHandler(ApplicationDbContext context, IMapper mapper, IUserService user)
        {
            _mapper = mapper;
            _context = context;
            _user = user;
        }

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var reportmanagerparam = _mapper.Map<NOM.Dao.Entities.ReportManagerParam>(request);

            reportmanagerparam.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));

            //if (await _context.ReportManagerParam.AnyAsync(x=>x.ColText == request.ColText))
            //{
            //throw new ValidationException("ColText", "Tên đã bị trùng");
            //}

            _context.ReportManagerParam.Add(reportmanagerparam);
            await _context.SaveChangesAsync(cancellationToken);
            return reportmanagerparam.Id;
        }
    }
}

