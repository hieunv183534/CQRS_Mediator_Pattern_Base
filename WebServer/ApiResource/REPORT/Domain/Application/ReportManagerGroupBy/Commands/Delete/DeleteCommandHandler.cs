using AutoMapper;
using NOM.Dao.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NOM.DomainGlobal._Base.Exceptions;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerGroupBy.Commands
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
            if (request.Id.Length == 0)
            {
                throw new ValidationException("Id", "Id Không được để trống");
            }
            var listItemDelete = await _context.ReportManagerGroupBy.Where(x => request.Id.Contains(x.Id)).ToArrayAsync();
            if (listItemDelete.Length == 0)
            {
                throw new ValidationException("", "Không tìm thấy dữ liệu cần xóa");
            }

            _context.ReportManagerGroupBy.RemoveRange(listItemDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}
