using System.Text.Json.Serialization;

namespace DemoCQRS.Domain.Users;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserStatus
{
    Active, 
    Inactive
}
