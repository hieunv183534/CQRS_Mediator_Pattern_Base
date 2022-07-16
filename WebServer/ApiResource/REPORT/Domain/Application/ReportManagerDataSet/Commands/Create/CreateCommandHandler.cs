using AutoMapper;
using NOM.Dao.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using RT.Comb;
using NOM.DomainGlobal.Interfaces;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Commands
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
            var reportmanagerdataset = _mapper.Map<NOM.Dao.Entities.ReportManagerDataSet>(request);

            //if (await _context.ReportManagerDataSet.AnyAsync(x=>x.ColText == request.ColText))
            //{
                //throw new ValidationException("ColText", "Tên đã bị trùng");
            //}

            // sinh mã nếu db không dùng identity
           // reportmanagerdataset.Id = Provider.Sql.CreateDoubleID(_user.GetUserInfo().PostId);
            _context.ReportManagerDataSet.Add(reportmanagerdataset);
            await _context.SaveChangesAsync(cancellationToken);
            return reportmanagerdataset.Id;
        }
    }
}

