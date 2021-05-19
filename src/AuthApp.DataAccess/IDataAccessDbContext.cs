using AuthApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.DataAccess
{
    public interface IDataAccessDbContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
