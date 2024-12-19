using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum UserStatus
{
    Undefined,
    WaitingApprove,
    Approved,
    Deleted,
}