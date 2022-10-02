using AutoMapper;
using EmailService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmailService.Api.Controllers
{
    public class BaseController : Controller
    {
        protected MailDto DeserializeObject(PostDto postDto)
        {
            MailDto mailDto;
            try
            {
                mailDto = JsonConvert.DeserializeObject<MailDto>(postDto.Value);

                return mailDto;
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }
    }
}
