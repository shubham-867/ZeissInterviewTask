using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeissInterviewTask.ModalClasses
{
   public class LoginRequest
    {
        
            /// <summary>
            /// Gets or sets the value of the username
            /// </summary>
            public required string Username { get; set; }
            /// <summary>
            /// Gets or sets the value of the password
            /// </summary>
            public required string Password { get; set; }
        
    }
}
