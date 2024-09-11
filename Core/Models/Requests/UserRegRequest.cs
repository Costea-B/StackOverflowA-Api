using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Requests
{
    public class UserRegRequest
    {
        // TODO: in loc de string.empty se poate de incercat required keyword sau attribute
        public string FullName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Job JobTitle { get; set; }
    }
}
