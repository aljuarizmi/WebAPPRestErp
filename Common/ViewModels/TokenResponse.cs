﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public long ExpirationTime { get; set; }
    }
}
