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

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class UploadCommandHandler : IRequestHandler<UploadCommand, List<UploadCommandResult>>
    {
        private IMapper _mapper;
        private FileCloudDbContext _context;
        private IUserService _user;

        public UploadCommandHandler(FileCloudDbContext context, IMapper mapper, IUserService user)
        {
            _mapper = mapper;
            _context = context;
            _user = user;
        }

        public async Task<List<UploadCommandResult>> Handle(UploadCommand request, CancellationToken cancellationToken)
        {
            var result = new List<UploadCommandResult>();
            var listData = new List<FileStorage>();
            foreach (var file in request.File)
            {
                if (!request.RootDirectory.HasValue())
                {
                    // Default folder
                    request.RootDirectory = "Root";
                }
                // check thu muc
                var folder = await _context.FileStorage.FirstOrDefaultAsync(x => x.FileName == request.RootDirectory && x.FileType == (int)FileCloudType.Folder);
                if (folder == null)
                {
                    folder = new FileStorage
                    {
                        Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode)),
                        CreateBy = _user.GetUserInfo().UserName,
                        CreateDate = DateTime.Now,
                        FileName = request.RootDirectory,
                        RootDirectory = request.RootDirectory,
                        FileNumber = Guid.NewGuid(),
                        Status = 2,
                        FileType = (int)FileCloudType.Folder
                    };
                    folder.ParentTag = $",{folder.Id},";
                    await _context.FileStorage.AddAsync(folder);
                    await _context.SaveChangesAsync();
                }

                var data = new FileStorage();
                // sinh mã nếu db không dùng identity
                data.Id = Provider.Sql.CreateDoubleID(Convert.ToInt32(_user.GetUserInfo().PostCode));
                data.Url = $"/api/file/dowload?id={data.Id}";
                data.CreateBy = _user.GetUserInfo().UserName;
                data.CreateDate = DateTime.Now;
                data.Extension = Path.GetExtension(file.FileName);
                data.FileName = file.FileName;
                data.FileNumber = Guid.NewGuid();
                data.FileSize = file.Length;
                data.RootDirectory = request.RootDirectory;
                data.ParentId = folder.Id;
                data.ParentTag = $"{folder.ParentTag}{data.Id},";
                data.Status = 1; //file tạm
                data.FileType = (int) FileCloudType.File;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    data.FileStreamData = memoryStream.ToArray();
                }
                listData.Add(data);
                result.Add(new UploadCommandResult {
                    FileNumber = data.FileNumber.ToString(),
                    FileName = data.FileName,
                    FileExtension = data.Extension,
                    FileUrl = data.Url,
                    FileSize = data.FileSize
                });
            }
            await _context.FileStorage.AddRangeAsync(listData);
            await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
