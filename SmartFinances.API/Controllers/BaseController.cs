using Microsoft.AspNetCore.Mvc;

namespace SmartFinances.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;

        protected BaseController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected string CurrentUserId => _contextAccessor.HttpContext?.User?.FindFirst("uid").Value;
    }
}
