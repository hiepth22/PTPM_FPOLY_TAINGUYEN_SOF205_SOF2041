using _1.DAL.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace _1.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<TestingObejct> TestingObejcts { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        //cofigure chuỗi kết nối vào db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //lưu ý chỉ cần thay tên  ở Data Source= tên servername ở máy tính của bạn và phần catalog là tên đb bạn muốn đặt
                optionsBuilder.UseSqlServer("Data Source=TANA\\SQLEXPRESS;Initial Catalog=TestingCF;Persist Security Info=True;User ID=thuyen;Password=123");
            }
        }

    }
}
