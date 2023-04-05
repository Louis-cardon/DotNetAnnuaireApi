﻿using Microsoft.EntityFrameworkCore;

namespace DotNetAnnuaireApi.Models
{
    public class AnnuaireContext : DbContext
    {
        public AnnuaireContext(DbContextOptions<AnnuaireContext> options)
            : base(options)
        {
        }

        public DbSet<Site> Sites { get; set; }
        //public DbSet<Service> Services { get; set; }
        //public DbSet<Salarie> Salaries { get; set; }
    }
}
