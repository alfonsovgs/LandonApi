using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LandonApi.Models
{
    public class Link
    {
        public const string DefaultMethod = "GET";

        public static Link To(string routeName, object routeValue = null) => new Link
        {
            RouteName = routeName,
            RouteValues = routeValue,
            Method = DefaultMethod,
            Relations = null,
        };

        [JsonProperty(Order = -4)]
        public string Href { get; set; }
        [JsonProperty(Order = -3, PropertyName = "rel", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Relations { get; set; }
        [JsonProperty(Order = -2, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(DefaultMethod)]
        public string Method { get; set; }

        [JsonIgnore]
        public string RouteName { get; set; }
        [JsonIgnore]
        public object RouteValues { get; set; }
    }
}
