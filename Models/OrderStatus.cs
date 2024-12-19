using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum OrderStatus 
{
    Unknown,
    Pending,
    Delivering,
    Delivered,
    Cancelled,
    Deleted
}