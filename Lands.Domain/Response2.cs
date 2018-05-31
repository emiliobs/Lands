using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Domain
{
    public class Response2
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
