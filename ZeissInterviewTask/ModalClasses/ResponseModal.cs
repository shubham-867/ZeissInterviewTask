using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeissInterviewTask.ModalClasses
{
    public class ResponseModal
    {
        /// <summary>
        /// Gets or sets the value of the success
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the value of the error message
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the username
        /// </summary>
        public string? Username { get; set; }
    }
}
