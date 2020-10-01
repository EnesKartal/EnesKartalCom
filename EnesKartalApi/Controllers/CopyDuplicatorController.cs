using EnesKartalApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace EnesKartalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CopyDuplicatorController : Controller
    {
        readonly EagleDbContext db;
        public CopyDuplicatorController(EagleDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<string> CopyDuplicatorSerials(string key)
        {
            return db.CopyDuplicatorLicence.Select(p=>p.Ip).ToList();
        }
    }
}