using System.ComponentModel.DataAnnotations;
using E_CommerceApp.CustomValidators;
namespace E_CommerceApp.Models
{
    public class Order
    {
        [Display(Name = "Order Number")]
        public int? OrderNo { get; set; }
        [Required(ErrorMessage ="{0} can't be blank")]
        [Display(Name ="Order Date")]
        //custom validator
        [MinimumDateValidator("2000-01-01",ErrorMessage= "Order Date should be greater than or equal to 2000")]
        public DateTime? OrderDate { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]

        [Display(Name = "Invoice Price")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be a valid number")]
        [InvoicePriceValidator]
        public double? InvoicePrice { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
