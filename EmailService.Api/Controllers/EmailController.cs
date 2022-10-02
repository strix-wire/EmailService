using EmailSerivce.Application.Commands;
using EmailSerivce.Domain;
using EmailService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmailService.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmailController : BaseController
{
    private readonly ILogger<EmailController> _logger;
    private readonly ISendEmailService _sendEmailService;
    public EmailController(ISendEmailService sendEmailService,
        ILogger<EmailController> logger)
    {
        _sendEmailService = sendEmailService;
        _logger = logger;
    }

    [HttpPost]
    public ActionResult Post([FromBody] PostDto postDto)
    {
        _logger.LogInformation("Input model: " + postDto.Value);
        MailDto mailDto = DeserializeObject(postDto);
        
        Mail mail = new() { Body = mailDto.Body,
        FromAddress = mailDto.FromAddress, FromName = mailDto.FromName,
        Subject = mailDto.Subject, ToAddress = mailDto.ToAddress, ToName = mailDto.ToName };

        _sendEmailService.Send(mail);

        return Ok();
    }

    [HttpGet("Test")]
    public string GetTest()
    {
        return "Serivce running";
    }
}
