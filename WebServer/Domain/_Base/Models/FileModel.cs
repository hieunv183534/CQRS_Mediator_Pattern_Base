using Microsoft.AspNetCore.Http;
using NSwag.Annotations;
using System.Collections.Generic;

namespace NOM.Domain._Base.Models
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