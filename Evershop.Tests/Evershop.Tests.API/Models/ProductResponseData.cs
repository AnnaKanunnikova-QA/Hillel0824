using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evershop.Tests.API.Models
{
    internal class ProductResponseData
    {
        [JsonProperty("data")]
        public ProductData Data { get; set; }
        internal class ProductData
        {
            [JsonProperty("uuid")]
            public string Uuid { get; set; }
            [JsonProperty("product_description_id")]
            public string ProductDescriptionId { get; set; }
        }
    }
}
