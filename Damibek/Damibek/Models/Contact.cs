﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Damibek.Models
{
    public class Contact: ModelBase
    {
        public Message message { get; set; }
    }
}