using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSerivce.Domain;

public class Mail
{
    public string FromName { get; set; }
    public string FromAddress { get; set; }
    public string ToName { get; set; }
    public string ToAddress { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public override string ToString()
    {
        return FromName + " " + FromAddress + " " + ToName + " " 
            + ToAddress + " " + Subject + " " + Body;
    }
}

