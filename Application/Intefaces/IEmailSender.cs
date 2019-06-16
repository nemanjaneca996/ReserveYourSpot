using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Intefaces
{
    public interface IEmailSender
    {
        string ToEmail { get; set; }
        string Body { get; set; }
        string Subject { get; set; }

        void Send();
    }
}
