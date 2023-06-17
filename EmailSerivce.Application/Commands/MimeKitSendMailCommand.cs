using EmailSerivce.Domain;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EmailSerivce.Application.Commands;

public class MimeKitSendMailCommand : ISendEmailService
{
    private readonly ILogger<MimeKitSendMailCommand> _logger;
    private readonly MimeKitSendMailValidation _mimeKitSendMailValidation = new();
    private static string _senderMail = (string)Properties.Settings.Default["senderMail"];
    public MimeKitSendMailCommand(ILogger<MimeKitSendMailCommand> logger)
    {
        _logger = logger;
    }

    public void Send(Mail mail)
    {
        try
        {
            bool isModelCorrect = _mimeKitSendMailValidation.CheckMail(mail);
            if (!isModelCorrect)
            {
                _logger.LogError("Model is uncorrent!");

                return;
            }

            var mimeMessage = CreateMimeMessage(mail);
            SendMimeKit(mimeMessage, mail);
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
        }
    }

    public void Send(IEnumerable<Mail> mail)
    {
        
    }

    private void SendMimeKit(MimeMessage mimeMessage, Mail mail)
    {
        using (var smtpClient = new SmtpClient())
        {
            smtpClient.Connect("smtp.mail.ru", 465, true);
            smtpClient.Authenticate(_senderMail, "3qDNyUS4WAR4SQBSqDJH");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
        }

        _logger.LogInformation("Сообщение отправлено: " + mail.ToString());
    }

    private MimeMessage CreateMimeMessage(Mail mail)
    {
        MimeMessage mimeMessage = new();
        mimeMessage.From.Add(new MailboxAddress(mail.FromName, _senderMail));
        mimeMessage.To.Add(new MailboxAddress(mail.ToName, mail.ToAddress));
        mimeMessage.Subject = mail.Subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = "<div style=\"color: red;\">" + "Message from mail: " + mail.FromAddress + "\n" + mail.Body + "</div>"
        };
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        return mimeMessage;
    }

}
