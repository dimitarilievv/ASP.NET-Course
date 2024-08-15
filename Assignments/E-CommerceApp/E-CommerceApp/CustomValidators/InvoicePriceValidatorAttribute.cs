using System.ComponentModel.DataAnnotations;
using System.Reflection;
using E_CommerceApp.Models;

namespace E_CommerceApp.CustomValidators
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "InvoicePrice doesn't match with the total cost of the specified products in the order.";
        public InvoicePriceValidatorAttribute() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
               PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
               if(OtherProperty != null)
                {
                    List<Product> products = (List<Product>)OtherProperty.GetValue(validationContext.ObjectInstance);
                    double totalPrice = 0;
                    products.ForEach(p =>
                    {
                        totalPrice += p.Price * p.Quantity;
                    });
                    double actualPrice = (double)value;
                    if (totalPrice > 0)
                    {
                        if (totalPrice != actualPrice)
                        {
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice), new string[] { nameof(validationContext.MemberName) });
                        }
                    }
                    else
                    {
                        return new ValidationResult("No products found to validate invoice price", new string[] { nameof(validationContext.MemberName) });
                    }
                    return ValidationResult.Success;
                }
                return null;
            }
            return null;
        }
    }
}
