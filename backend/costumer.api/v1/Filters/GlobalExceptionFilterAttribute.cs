using costumer.api.v1.Filters.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace costumer.api.v1.Filters
{
	public class GlobalExceptionFilterAttribute : Attribute, IExceptionFilter
	{
		public GlobalExceptionFilterAttribute() { }

		public void OnException(ExceptionContext context)
		{
			context.Result = new BadRequestObjectResult(
				new DefaultError(false,
					new ErrorsResponse[]
					{
						new ErrorsResponse("188",
							"Erro durante a execução ",
							DateTime.Now)
					}
				)
			);
		}
	}
}
