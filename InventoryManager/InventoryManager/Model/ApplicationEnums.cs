using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Model
{
    public static class ApplicationEnums
    {
        public enum MainMenuChoices
        {
            addProduct = 1,
            viewProduct = 2,
            searchProduct = 3,
            editProduct = 4,
            deleteProduct = 5,
            exit = 6,
        }

        public enum EditChoice
        {
            productId = 1,
            productName = 2,
            productPrice = 3,
            productQuantity = 4,
        }
        public enum Tasks
        {
            Add = 1,
            View = 2,
            Search = 3,
            Edit = 4,
            Delete = 5,
        }
    }
}
