using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class Result<T>
    {
        private StringBuilder _error;
        public bool existeError { get { return _error.Length > 0; } }
        public int code { set; get; }
        public string message
        {
            set { _error.AppendLine(value); }
            get { return _error.ToString(); }
        }
        public T data { set; get; }
        public Result()
        {
            code = 200;
            _error = new StringBuilder();
        }
        public Result(int code)
        {
            code = code;
            _error = new StringBuilder();
        }
        public void SetError(int code, string message)
        {
            this._error.AppendLine(message);
            this.code = code;
        }
        public void AssignError<J>(Result<J> result)
        {
            if (!string.IsNullOrEmpty(result.message.Trim()))
            {
                this._error.Append(result.message);
                this.code = result.code;
            }
        }
        public void AssignObject(Result<T> result)
        {
            if (string.IsNullOrEmpty(result.message.Trim()))
            {
                this.data = result.data;
            }
            else
            {
                this._error.Append(result.message);
                this.code = result.code;
            }
        }
    }
}
