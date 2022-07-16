using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NOM.DomainGlobal.Services
{
    public class VmapService : IVmapService
    {
        private IHttpClientFactory _http;

        public VmapService(IHttpClientFactory http)
        {
            _http = http;
        }

        public async Task<(string vPostCode, double? Lat, double? Long)> GetVmap(string address)
        {
            var url = $"https://maps.vnpost.vn/api/search?api-version=1.1&apikey=457756595ea907a5ed7dbc62fdda85852a1736e04f258c47&text={address}";

            var client = _http.CreateClient();

            var response = await client.GetStringAsync(url);
            var body = response.JsonToObject();
            if (body.ContainsKey("code") && body.Value<string>("code") != "OK")
            {
                return (null, null, null);
            }

            if (!body.ContainsKey("data"))
            {
                return (null, null, null);
            }

            var data = body.Value<JObject>("data");

            if (!data.ContainsKey("features"))
            {
                return (null, null, null);
            }
            var features = data.Value<JArray>("features");
            if (features.Count == 0)
            {
                return (null, null, null);
            }

            if (!features[0].Value<JObject>().ContainsKey("geometry"))
            {
                return (null, null, null);
            }
            var geometry = features[0].Value<JObject>("geometry");
            var coordinates = geometry.Value<JArray>("coordinates");

            var Lat = coordinates[0].Value<double>();
            var Long = coordinates[1].Value<double>();

            var properties = features[0].Value<JObject>("properties");
            var vpostCode = properties.Value<string>("smartcode");

            return (vpostCode, Lat, Long);
        }
    }
}
