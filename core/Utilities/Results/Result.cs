using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        private string carDelede;

        public Result(bool success, string message):this(success)
        {
            Message = message;
            
        }
        public Result(bool success)
        {
            Success = success;
        }

        public Result()
        {
        }

        public Result(string carDelede)
        {
            this.carDelede = carDelede;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
