using System;
using System.Collections.Generic;
using System.Text;

namespace MoFang.MobileSite.Core.Model
{
    public class ResponseModel
    {
        public ResponseModel(string message,bool _success, int _code)
        {
            Message = message;
            Success = _success;
            Code = _code;
        }
        public bool Success { get; set; }
        public int Code { get; set; }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;//一旦修改了Message就相当于Success false了哈
                Success = false;
            }
        }
    }
}
