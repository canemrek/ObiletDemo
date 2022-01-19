using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.CommonModels
{
    public class Response<T> where T:class
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
