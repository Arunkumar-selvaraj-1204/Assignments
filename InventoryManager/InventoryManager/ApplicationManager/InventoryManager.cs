using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.IOManager;
using InventoryManager.Model;
namespace InventoryManager.ApplicationManager
{
    internal class InventoryManager
    {
        public void AddProduct()
        {
            OutputManager.PrintCurrentTask("ADD");
            Product product = InputManager.GetProductDetails();
        }
    }
}
