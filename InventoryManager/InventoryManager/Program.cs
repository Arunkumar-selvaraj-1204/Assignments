using InventoryManager.ApplicationManager;
namespace InventoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppInteraction appInteraction = new AppInteraction();
            appInteraction.DisplayInitialMenu();
        }
    }
}
