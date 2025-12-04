using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_v2.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private ISender _sender = null!;

        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
