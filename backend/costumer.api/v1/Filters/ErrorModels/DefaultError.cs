using System;

namespace costumer.api.v1.Filters.ErrorModels
{
	public class DefaultError
	{
		public bool Success { get; set; }
		public ErrorsResponse[] Errors { get; set; }

		public DefaultError(bool success, ErrorsResponse[] errors)
		{
			Success = success;
			Errors = errors;
		}
	}

	public class ErrorsResponse
	{
		public string Code { get; set; }
		public string Message { get; set; }
		public DateTime timesTamp { get; set; }

		public ErrorsResponse(string code, string message, DateTime timesTamp)
		{
			Code = code;
			Message = message;
			this.timesTamp = timesTamp;
		}
	}
}
