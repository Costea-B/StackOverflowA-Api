using System.Text.Json.Serialization;

namespace Core.Enums
{
     //  JOB ENUM CAN ACCEPT DIFFERENT VALUES FROM THE DEFINED ONES, for example 4, 5, 20 can be casted to enum and no exception is thrown
     [JsonConverter(typeof(JsonStringEnumConverter))]
     public enum Job
    {
        SoftwareEngineer,
        Racist,
        Retarded
    }
}
