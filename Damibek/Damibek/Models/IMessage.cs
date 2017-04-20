using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damibek.Models
{
    interface IMessage
    {
        string name { get; set; }
        string email { get; set; }
        string phone { get; set; }
        string message { get; set; }

    }
}
