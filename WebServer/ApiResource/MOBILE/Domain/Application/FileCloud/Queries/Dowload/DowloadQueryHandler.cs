using AutoMapper;
using AutoMapper.QueryableExtensions;
using BCCP.Dao.Entities;
using BCCP.Dao.FileCloud;
using BCCP.DomainGlobal._Base.Extentions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BCCP.DomainGlobal.Application.FileCloud.Queries
{
    public class DowloadQueryHandler : IRequestHandler<DowloadQuery, DowloadQueryResult>
    {
        private readonly FileCloudDbContext _context;
        private readonly IMapper _mapper;

        public DowloadQueryHandler(FileCloudDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DowloadQueryResult> Handle(DowloadQuery request, CancellationToken cancellationToken)
        {
            var query = _context.FileStorage.AsQueryable();

            // where custom in here
            if (request.Id.HasValue)
            {
                query = query.Where(x => x.Id == request.Id);
            }

            if (request.Url.HasValue())
            {
                query = query.Where(x => x.Url == request.Url);
            }

            if (request.FileNumber.HasValue())
            {
                query = query.Where(x => x.FileNumber.ToString() == request.FileNumber);
            }

            return await query.Select(x => new DowloadQueryResult
            {
                FileName = x.FileName,
                FileData = x.FileStreamData
            }).FirstOrDefaultAsync();
        }
    }
}
