using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBISEvaluation.Models.Responses
{
    public class ItemResponse<T> : SuccessResponse, IItemResponse
    {
        public List<T> Item { get; set; }
        object IItemResponse.Item { get { return this.Item; } }

    }
}