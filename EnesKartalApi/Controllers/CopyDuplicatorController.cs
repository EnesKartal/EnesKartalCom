using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EnesKartalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CopyDuplicatorController : Controller
    {
        [HttpGet]
        public List<string> CopyDuplicatorSerials(string key)
        {
            if (key == "EagleCopyDuplicator17")
                return new List<string>() { "Eagle" };
            else
                return new List<string>() { }; ;
        }
    }
}