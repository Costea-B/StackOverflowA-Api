using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Job
    {
         Student,
         Teacher,
         FinanceManager,
         Engineer,
         BusinessAnalyst,
         Nurse,
         Architect,
         Writer,
         Electrician,
         Accountant,
         GraphicDesigner
     }
}
