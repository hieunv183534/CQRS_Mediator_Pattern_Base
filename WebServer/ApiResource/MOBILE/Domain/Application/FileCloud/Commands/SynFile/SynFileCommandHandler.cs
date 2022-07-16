using AutoMapper;
using BCCP.Common.Enums;
using BCCP.Dao.FileCloud;
using BCCP.DomainGlobal.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RT.Comb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using BCCP.DomainGlobal._Base.Extentions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class SynFileCommandHandler : IRequestHandler<SynFileCommand, bool>
    {
        private IMapper _mapper;
        private FileCloudDbContext _context;
        private IUserService _user;

        public SynFileCommandHandler(FileCloudDbContext context, IMapper mapper, IUserService user)
        {
            _mapper = mapper;
            _context = context;
            _user = user;
        }

        public async Task<bool> Handle(SynFileCommand request, CancellationToken cancellationToken)
        {
            var listFileOld = new List<Guid>();
            var listFileNew = new List<Guid>();

            if (request.DataOld != null)
            {
                var objecJson = JToken.FromObject(request.DataOld);
                listFileOld = GetFile(objecJson);
            }
            if (request.DataNew != null)
            {
                var objecJson = JToken.FromObject(request.DataNew);
                listFileNew = GetFile(objecJson);
            }

            var listCreate = listFileNew.Where(x => !listFileOld.Contains(x));
            var listDelete = listFileOld.Where(x => !listFileNew.Contains(x));

            if (listCreate.Count() > 0)
            {
               await _context.FileStorage.Where(x => listCreate.Contains(x.FileNumber))
                    .UpdateFromQueryAsync(x => new FileStorage { Status = 2 }, cancellationToken);
            }
            if (listDelete.Count() > 0)
            {
                await _context.FileStorage.Where(x => listDelete.Contains(x.FileNumber))
                   .DeleteFromQueryAsync(cancellationToken);
            }
            return true;
        }

        private List<Guid> GetFile(JToken source)
        {
            var listFile = new List<Guid>();
            if (source.Type == JTokenType.Object)
            {
                foreach (var pro in (source as JObject).Properties())
                {
                    listFile.AddRange(GetFile(pro.Value));
                }
            }
            else if (source.Type == JTokenType.Array)
            {
                foreach (var item in source as JArray)
                {
                    listFile.AddRange(GetFile(item));
                }
            }
            else if (source.Type == JTokenType.String)
            {
                var valueItem = source.Value<String>();
                if (valueItem.StartsWith("[{\"fileNumber\":\""))
                {
                    foreach (JObject item in Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(valueItem))
                    {
                        listFile.Add(new Guid(item.GetValue("fileNumber").Value<string>()));
                    }
                }
            }

            return listFile;
        }
    }
}
