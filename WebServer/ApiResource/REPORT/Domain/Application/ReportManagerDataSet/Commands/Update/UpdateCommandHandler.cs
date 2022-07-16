using AutoMapper;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public UpdateCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<long> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var dataOld = await _context.ReportManagerDataSet.FindAsync(request.Id);
            if (dataOld == null)
            {
                throw new ValidationException("", "Không tìm thấy dữ liệu cần update");
            }
            var update = _mapper.Map<Dao.Entities.ReportManagerDataSet>(request);
            //if (update.ColText != dataOld.ColText && await _context.ReportManagerDataSet.AnyAsync(x => x.ColText == update.ColText))
            //{
                //throw new ValidationException("ColText", "Tên đã bị trùng");
            //}

            _context.Entry(dataOld).CurrentValues.SetValues(update);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}

