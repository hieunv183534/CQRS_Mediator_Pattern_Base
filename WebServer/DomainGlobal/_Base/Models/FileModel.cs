using Microsoft.AspNetCore.Http;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOM.DomainGlobal._Base.Models
{
    public class FileModel
    {
        public string FileUrl { get; set; }

        public List<IFormFile> FileByte { get; set; }

        [OpenApiIgnore]
        public List<string> FileOld
        {
            get
            {
                return FileUrl != null ? System.Text.Json.JsonSerializer.Deserialize<List<string>>(FileUrl) : new List<string>();
            }
        }
    }
}
