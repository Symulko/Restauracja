using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.UI.Interfaces.ViewModel.Email
{
    public interface IEmailOptionsViewModel
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string EmailFrom { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
