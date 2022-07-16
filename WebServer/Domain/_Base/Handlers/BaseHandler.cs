using AutoMapper;
using NOM.Dao.Entities;
using System;

namespace NOM.Domain._Base.Handlers
{
    public class BaseHandler
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public BaseHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}