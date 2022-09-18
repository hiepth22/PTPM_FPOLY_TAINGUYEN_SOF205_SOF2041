using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.DomainModels
{
    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {

        public NhaSanXuat()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("IDNhaSanXuat")]
        public Guid IdnhaSanXuat { get; set; }
        [StringLength(50)]
        public string MaNhaSanXuat { get; set; }
        [StringLength(50)]
        public string TenNhaSanXuat { get; set; }
        public int? TrangThai { get; set; }

        [InverseProperty(nameof(Product.IdnhaSanXuatNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
