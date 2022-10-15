using AutoMapper;
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
    private readonly IMapper _mapper;
    public EmailController(ISendEmailService sendEmailService,
        ILogger<EmailController> logger, IMapper mapper)
    {
        _sendEmailService = sendEmailService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult Post([FromBody] MailDto dto)
    {
        _logger.LogInformation("Input model: " + dto);

        Mail mail = _mapper.Map<Mail>(dto);

        _sendEmailService.Send(mail);

        return Ok();
    }

    [HttpGet("Test")]
    public string GetTest()
    {
        return "Serivce running";
    }
}
