using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Collections.Generic; // If using lists or collections


namespace RTWErrorNotification.Models
{
    public class CandidateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ErrorMessage { get; set; }
    }
}