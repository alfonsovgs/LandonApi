using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LandonApi.Models
{
    public class ApiError
    {
        private ModelStateDictionary modelState;

        public ApiError(ModelStateDictionary modelState)
        {
            Message = "Invalid parameters.";
            Detail = modelState
                .FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors
                .FirstOrDefault().ErrorMessage;
        }

        public string Message { get; set; }

        public string Detail { get; set; }
    }
}
