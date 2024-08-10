using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineStore_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_Models.ViewModels
{
    public class ShoppingCartVM
    {
        [ValidateNever]
        public IEnumerable<ShoppingCart> shoppingCarts { get; set; }

        public OrderHeader OrderHeader { get; set; }
    }
}
