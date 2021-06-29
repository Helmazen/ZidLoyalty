using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class ResponseModel
    {
        public  int code { get; set; }
        public  string messsage { get; set; }
        public List<object> errors { get; set; }
        public object data { get; set; }
    } 
}
