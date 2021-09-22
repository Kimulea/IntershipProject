using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloomcoding.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {

    }
}
