using Prism.Events;
using Restaurant.UI.Data;
using Restaurant.UI.Event;
using Restaurant.UI.Helpers;
using Restaurant.UI.Interfaces;
using Restaurant.UI.Interfaces.ViewModel.Email;
using System;
using System.Net;
using System.Security;

namespace Restaurant.UI.ViewModel.Email
{
    public class EmailOptionsViewModel : BindableBase, IEmailOptionsViewModel
    {
        private IEmailSender _emailSender;
        private IEventAggregator _eventAggregator;
        public EmailOptionsViewModel(IEmailSender emailSender,
            IEventAggregator eventAggregator)
        {
            _emailSender = emailSender;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SendOrderEmailEvent>()
              .Subscribe(OnSendOrderEmail);
        }

        private async void OnSendOrderEmail(string orderBody)
        {
            if (EmailTo != null && 
                EmailFrom != null && 
                Subject!=null && 
                orderBody!= null && 
                Password != null && 
                Host != null)
            {
                await _emailSender
                    .SendEmailAsync(EmailFrom, EmailTo, Subject, orderBody, Password, Host, Port);
            }
        }

        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string EmailFrom { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
