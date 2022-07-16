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
    public class FindOneQueryHandler : IRequestHandler<FindOneQuery, FindOneQueryResult>
    {
        private readonly FileCloudDbContext _context;
        private readonly IMapper _mapper;

        public FindOneQueryHandler(FileCloudDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FindOneQueryResult> Handle(FindOneQuery request, CancellationToken cancellationToken)
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

            // where loopback default
            if (request.Where.HasValue())
            {
                query = query.WhereLoopback(request.WhereLoopBack);
            }

            // order by paging by lookback default
            if (request.Order.HasValue())
            {
                query = query.OrderByLoopback(request.OrderLoopBack);
            }

            return await query.ProjectTo<FindOneQueryResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
