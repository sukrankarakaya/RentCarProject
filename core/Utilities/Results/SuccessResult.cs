using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public object CarUpdate { get; }

        public SuccessResult(string message): base(true,message)
        {

        }
        public SuccessResult() : base(true)
        {

        }

        public SuccessResult(object carUpdate)
        {
            CarUpdate = carUpdate;
        }
    }
}
