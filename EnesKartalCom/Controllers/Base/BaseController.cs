using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnesKartalCom.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnesKartalCom.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public EKDbContext dbContext;
        public BaseController(EKDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}