using System.Text.Json.Serialization;

namespace DotNetCoreWebApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
        Knight = 1,
        Mage = 2,
        Healer = 3
    }
}