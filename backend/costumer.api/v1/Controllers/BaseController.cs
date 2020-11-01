using costumer.api.Application.Exceptions;
using costumer.api.v1.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace costumer.api.v1.Controllers
{
	[Route("custumer/[controller]")]
	[ServiceFilter(typeof(GlobalExceptionFilterAttribute))]
	public class BaseController : Controller
	{
		private readonly ExceptionNotificationHandler _notifications;

		protected IEnumerable<ExceptionNotification> Notifications => _notifications.GetNotifications();

		protected BaseController(ExceptionNotificationHandler notifications)
		{
			_notifications = notifications;
		}

		protected bool IsValidOperation()
		{
			return (!_notifications.HasNotifications());
		}

		protected new IActionResult Response(int statusCode, object result = null)
		{
			if (IsValidOperation())
			{
				return StatusCode(statusCode, new
				{
					success = true,
					data = result
				});
			}

			return BadRequest(new
			{
				success = false,
				errors = _notifications.GetNotifications()
			});
		}
	}
}
