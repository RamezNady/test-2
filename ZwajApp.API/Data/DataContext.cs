using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Mobels;

namespace ZwajApp.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }


        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}