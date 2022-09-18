using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.DAL.DomainModels
{
    [Table("TestingObejct")]
    public partial class TestingObejct
    {
        [Key]
        public Guid Id { get; set; }
        public int value { get; set; }
    }
}
