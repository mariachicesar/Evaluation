using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBISEvaluation.Models.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {
            this.IsSuccessful = true;
        }
    }
}
