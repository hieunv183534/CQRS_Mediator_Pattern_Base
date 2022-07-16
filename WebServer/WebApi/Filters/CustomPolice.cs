using Microsoft.AspNetCore.Authorization;

namespace NOM.WebApi.Filters
{
    public class CustomPolice : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public CustomPolice(string Name)
        {
            this.Name = Name;
        }
    }
}