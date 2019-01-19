using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using GAM.Infrastructure.IComm.IDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GAM.Infrastructure.EntityFarmeworkCore
{
    public class EfCoreContext: DbContext, IUnitOfWork
    {
        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(builder.GetConnectionString("SqlConn"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
