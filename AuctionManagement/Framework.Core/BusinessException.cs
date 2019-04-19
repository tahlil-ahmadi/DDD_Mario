﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core
{
    public class BusinessException : Exception
    {
        public long Code { get; private set; }
        public BusinessException(long code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
