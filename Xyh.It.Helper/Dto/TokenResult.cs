﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xyh.It.Helper.Dto
{
    public class TokenResult
    {
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public string Token_Type { get; set; }
    }
}
