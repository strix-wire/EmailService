using EmailSerivce.Domain;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSerivce.Application.Commands;

public class MimeKitSendMailCommand : ISendEmailService
{
    private readonly ILogger<MimeKitSendMailCommand> _logger;
    private readonly SmtpClient _smtpClient = new();

    public MimeKitSendMailCommand(ILogger<MimeKitSendMailCommand> logger)
    {
        _logger = logger;
    }

    public void Send(Mail mail)
    {
        try
        {
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
        _smtpClient.Connect("smtp.mail.ru", 465, true);
        _smtpClient.Authenticate("vasily_pavlov_98@mail.ru", "3qDNyUS4WAR4SQBSqDJH");
        _smtpClient.Send(mimeMessage);
        _smtpClient.Disconnect(true);

        _logger.LogInformation("Сообщение отправлено: " + mail.ToString());
    }

    private MimeMessage CreateMimeMessage(Mail mail)
    {
        MimeMessage mimeMessage = new();
        mimeMessage.From.Add(new MailboxAddress(mail.FromName, mail.FromAddress));
        mimeMessage.To.Add(new MailboxAddress(mail.ToName, mail.ToAddress));
        mimeMessage.Subject = mail.Subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = "<div style=\"color: red;\">" + mail.Body + "</div>"
        };
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        return mimeMessage;
    }

}
