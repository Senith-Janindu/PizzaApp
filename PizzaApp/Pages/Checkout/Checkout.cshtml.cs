using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaApp.Data;
using PizzaApp.Models;

namespace PizzaApp.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {        
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string ImageTitle { get; set; }

        private readonly ApplicationDbContext _context;

        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            if (String.IsNullOrWhiteSpace(PizzaName)){
                PizzaName = "Custom";            
            }
            if (String.IsNullOrWhiteSpace(ImageTitle)) {
                ImageTitle = "Create";
            }

            PizzaOrder pizzaOrder = new PizzaOrder();

            pizzaOrder.PizzaName = ImageTitle;
            pizzaOrder.BasePrize = PizzaPrice;

            _context.PizzaOrders.Add(pizzaOrder);
            _context.SaveChanges();

        }
    }
}
