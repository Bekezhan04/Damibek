using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Damibek.Models
{
    public class Message : ModelBase, IMessage
    {

        [Display(Name="Представитель")]
        public string name { get; set; }
        [Display(Name="E-mail")]
        public string email { get; set; }
        [Display(Name="Номер телефона")]
        public string phone { get; set; }
        [Display(Name="Сообщение")]
        public string message { get; set; }

        public string to { get; set; }
    }
}