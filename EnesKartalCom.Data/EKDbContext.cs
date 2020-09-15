using EnesKartalCom.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnesKartalCom.Data
{
    public class EKDbContext : DbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppUserLog> AppUserLog { get; set; }
    }
}
