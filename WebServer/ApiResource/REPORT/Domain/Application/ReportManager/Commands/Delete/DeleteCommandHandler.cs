using AutoMapper;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
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
            var listItemDelete = await _context.ReportManager.Where(x => request.Id.Contains(x.Id)).ToArrayAsync();
            //List<Dao.Entities.ReportManager> listItemChild = new List<Dao.Entities.ReportManager>();
            if (listItemDelete.Length == 0)
            {
                throw new ValidationException("", "Không tìm thấy dữ liệu cần xóa");
            } else
            {
                // xóa các con của cây cáo báo
                foreach (var item in listItemDelete)
                {
                    var child = await _context.ReportManager.Where(x => x.ParentTag.StartsWith(item.ParentTag)).ToArrayAsync();
                    _context.ReportManager.RemoveRange(child);
                }
            }

            _context.ReportManager.RemoveRange(listItemDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}

