using AutoMapper;
using EmailSerivce.Application.Common.Mappings;
using EmailSerivce.Domain;

namespace EmailService.Api.Models;

public class MailDto : IMapWith<Mail>
{
    public string FromName { get; set; }
    public string FromAddress { get; set; }
    public string ToName { get; set; }
    public string ToAddress { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<MailDto, Mail>()
            .ForMember(mailDto => mailDto.FromName,
                opt => opt.MapFrom(mail => mail.FromName))
            .ForMember(mailDto => mailDto.FromAddress,
                opt => opt.MapFrom(mail => mail.FromAddress))
            .ForMember(mailDto => mailDto.ToName,
                opt => opt.MapFrom(mail => mail.ToName))
            .ForMember(mailDto => mailDto.ToAddress,
                opt => opt.MapFrom(mail => mail.ToAddress))
            .ForMember(mailDto => mailDto.Subject,
                opt => opt.MapFrom(mail => mail.Subject))
            .ForMember(mailDto => mailDto.Body,
                opt => opt.MapFrom(mail => mail.Body));
    }
}
