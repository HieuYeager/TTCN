using System.Data.Entity;
using Hotel_Mng.Models;

namespace Hotel_Mng.DAL
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext() : base("HotelDBConnection") { }

        public DbSet<Account> Accounts { get; set; }
        // Thêm các DbSet khác sau (Customer, Staff, Rooms,...)
    }
}
