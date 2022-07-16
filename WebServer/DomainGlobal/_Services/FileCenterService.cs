using NOM.Dao.FileCloud;
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal.Interfaces;
using NOM.DomainGlobal.Models.FileCenter;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOM.DomainGlobal._Services
{
    public class FileCenterService : IFileCenterService
    {

        private readonly FileCloudDbContext _context;

        public FileCenterService(FileCloudDbContext context)
        {
            _context = context;
        }

        public async Task<DowloadModelResult> Dowload(DowloadModel model)
        {
            var query = _context.FileStorage.AsQueryable();

            // where custom in here
            if (model.Id.HasValue)
            {
                query = query.Where(x => x.Id == model.Id);
            }

            if (model.Url.HasValue())
            {
                query = query.Where(x => x.Url == model.Url);
            }

            if (model.FileNumber.HasValue())
            {
                query = query.Where(x => x.FileNumber.ToString() == model.FileNumber);
            }

            return await query.Select(x => new DowloadModelResult
            {
                FileName = x.FileName,
                FileData = x.FileStreamData
            }).FirstOrDefaultAsync();
        }

        public async Task<FindOneModelResult> FindOne(FindOneModel model)
        {
            var query = _context.FileStorage.AsQueryable();

            // where custom in here
            if (model.Id.HasValue)
            {
                query = query.Where(x => x.Id == model.Id);
            }

            if (model.Url.HasValue())
            {
                query = query.Where(x => x.Url == model.Url);
            }

            if (model.FileNumber.HasValue())
            {
                query = query.Where(x => x.FileNumber.ToString() == model.FileNumber);
            }


            return await query.Select(x=> new FindOneModelResult
            {
                CreateBy = x.CreateBy,
                CreateDate = x.CreateDate,
                DeleteBy = x.DeleteBy,
                DeleteDate = x.DeleteDate,
                Extension = x.Extension,
                FileName = x.FileName,
                FileNumber = x.FileNumber,
                FileSize = x.FileSize,
                FileType = x.FileType,
                Status = x.Status,
                Url = x.Url,
                ParentId = x.ParentId
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> SynFile(SynFileModel model)
        {
            var listFileOld = new List<Guid>();
            var listFileNew = new List<Guid>();

            if (model.DataOld != null)
            {
                var objecJson = JToken.FromObject(model.DataOld);
                listFileOld = GetFile(objecJson);
            }
            if (model.DataNew != null)
            {
                var objecJson = JToken.FromObject(model.DataNew);
                listFileNew = GetFile(objecJson);
            }

            var listCreate = listFileNew.Where(x => !listFileOld.Contains(x));
            var listDelete = listFileOld.Where(x => !listFileNew.Contains(x));

            if (listCreate.Count() > 0)
            {
                await _context.FileStorage.Where(x => listCreate.Contains(x.FileNumber))
                     .UpdateFromQueryAsync(x => new FileStorage { Status = 2 });
            }
            if (listDelete.Count() > 0)
            {
                await _context.FileStorage.Where(x => listDelete.Contains(x.FileNumber))
                   .DeleteFromQueryAsync();
            }
            return true;
        }

        #region Private function

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

        #endregion
    }
}
