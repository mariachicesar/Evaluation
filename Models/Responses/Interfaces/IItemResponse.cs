using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBISEvaluation.Models.Responses
{
    public interface IItemResponse
    {
        //bool IsSuccesful { get; set; }
        string TransactionId { get; set; }
        object Item { get; }
    }
}