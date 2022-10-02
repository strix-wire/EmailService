using EmailSerivce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSerivce.Application.Commands
{
    internal class MimeKitSendMailValidation
    {
        /// <summary>
        /// Checks the integrity of the model
        /// </summary>
        /// <param name="mail"></param>
        /// <returns>false: model is wrong
        /// true: model is correct</returns>
        public bool CheckMail(Mail mail)
        {
            if (mail == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(mail.Subject) || string.IsNullOrWhiteSpace(mail.FromName) ||
                string.IsNullOrWhiteSpace(mail.ToAddress) || string.IsNullOrWhiteSpace(mail.FromAddress) ||
                string.IsNullOrWhiteSpace(mail.FromAddress) || string.IsNullOrWhiteSpace(mail.Body))
            {
                return false;
            }

            return true;
        }
    }
}
