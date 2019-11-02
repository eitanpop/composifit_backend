using Composifit.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composifit.Controllers
{
    public class BaseController : Controller
    {
        protected string UserId => User.GetUsername();

    }
}
