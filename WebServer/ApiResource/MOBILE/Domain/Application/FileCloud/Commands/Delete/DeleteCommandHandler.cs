using AutoMapper;
using BCCP.Dao.Entities;
using BCCP.Dao.FileCloud;
using BCCP.DomainGlobal._Base.Exceptions;
using BCCP.DomainGlobal._Base.Extentions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly FileCloudDbContext _context;

        public DeleteCommandHandler(FileCloudDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null && request.Url == null)
            {
                throw new ValidationException("", "Id hoặc Url Không được để trống");
            }

            if (request.Id != null && request.Id.Length > 0)
            {
                await _context.FileStorage.AsQueryable()
                .Where(x => request.Id.Contains(x.Id))
                .DeleteFromQueryAsync(cancellationToken);
                return true;
            }
            else if(request.Url != null && request.Url.Length > 0)
            {
                await _context.FileStorage.AsQueryable()
                    .Where(x => request.Url.Contains(x.Url))
                    .DeleteFromQueryAsync(cancellationToken);
                return true;
            }
            return true;
        }
    }
}
