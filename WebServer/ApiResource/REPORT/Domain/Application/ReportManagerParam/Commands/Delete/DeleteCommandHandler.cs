using AutoMapper;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerParam.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, long[]>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public DeleteCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<long[]> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var listItemDelete = await _context.ReportManagerParam.Where(x => request.Id.Contains(x.Id)).ToArrayAsync();
            
            if (listItemDelete.Length == 0)
            {
                throw new ValidationException("", "Không tìm thấy dữ liệu cần xóa");
            }

            _context.ReportManagerParam.RemoveRange(listItemDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}

