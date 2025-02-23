using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MvcPractice.Models
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = "An error occurred while processing your request.",
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
