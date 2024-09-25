using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD_App_PureTech_Task.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]      
        public int Prod_Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? Prod_Name { get; set; }
        [Required]    
        public decimal Prod_price { get; set; }
        [Required]
        public string? Prod_Description { get; set; }
        public string? Prod_imageUrl { get; set; }
    }
}
