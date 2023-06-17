using EmailSerivce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSerivce.Application.Commands;

public interface ISendEmailService
{
    public void Send(IEnumerable<Mail> mail);
    public void Send(Mail mail);
}
