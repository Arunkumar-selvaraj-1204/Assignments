using InventoryManager.ApplicationManager;
namespace InventoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppService appInteraction = new AppService();
            appInteraction.DisplayInitialMenu();
        }
    }
}
