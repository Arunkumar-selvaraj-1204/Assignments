namespace ShapeHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShapeGenerator generator = new ShapeGenerator();
            bool isExit = false;
            while (!isExit)
            {
                int userChoice = ConsoleInputManager.GetChoice();
                switch (userChoice)
                {
                    case 1:
                        generator.CreateRectangle();
                        break;
                    case 2:
                        generator.CreateCircle();
                        break;
                    case 3:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;
                }
            }
        }
    }
}
