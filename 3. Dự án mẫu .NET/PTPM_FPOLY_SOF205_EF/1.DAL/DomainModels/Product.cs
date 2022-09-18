using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.DomainModels
{
    //Bước 1: Đặt Tên Cho Bảng
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {

        }
        //thêm Attribute Key Để định nghĩa khóa chính
        [Key]
        public Guid MaHangHoa { get; set; }
        //thêm độ dài cho tên
        [StringLength(50)]
        public string TenHangHoa { get; set; }
        public double DonGiaNhap { get; set; }
        public double DonGiaBan { get; set; }
        //trường hợp chúng ta cần thêm thuộc tính mới
        public bool Status { get; set; }

        //khai báo khóa ngoại
        [Column("IDNhaSanXuat")]
        //thêm ? để được phép null
        public Guid? IdnhaSanXuat { get; set; }
        //
        [ForeignKey(nameof(IdnhaSanXuat))]
        [InverseProperty(nameof(NhaSanXuat.Products))]
        public virtual NhaSanXuat IdnhaSanXuatNavigation { get; set; }

    }
}
