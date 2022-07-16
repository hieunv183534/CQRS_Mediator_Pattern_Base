using AutoMapper;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class RenameCommandHandler : IRequestHandler<RenameCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public RenameCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<long> Handle(RenameCommand request, CancellationToken cancellationToken)
        {
            var dataOld = await _context.ReportManager.FindAsync(request.Id);

            if (request.Name != dataOld.Name && await _context.ReportManager.AnyAsync(x => x.Name == request.Name))
            {
                throw new ValidationException("name", "Tên đã bị trùng");
            }

            _context.Entry(dataOld).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}

