using AutoMapper;
using NOM.Dao.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerParam.Commands
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
            var dataOld = await _context.ReportManagerParam.FindAsync(request.Id);
            
            //if (request.ColText != dataOld.ColText && await _context.ReportManagerParam.AnyAsync(x => x.ColText == request.ColText))
            //{
                //throw new ValidationException("ColText", "Tên đã bị trùng");
            //}

            _context.Entry(dataOld).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}

