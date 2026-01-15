using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Notenverwaltung.API.DataAccess.Models;
using Notenverwaltung.Shared.Dtos.UserDtos;

namespace Notenverwaltung.API.DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) :
        base(options)
        { }
        public DbSet<User> Users { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}
