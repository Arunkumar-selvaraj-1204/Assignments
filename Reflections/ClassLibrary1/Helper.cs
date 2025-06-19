namespace ReflectionHelper
{
    public class Helper
    {
        public string internalName;

        public string Name { get; set; }

        public int age { get; set; }

        public event EventHandler WorkCompleted;

        public Helper()
        {
            internalName = "Default";
            Name = "DefaultName";
            age = 1;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public void DoWork()
        {
            Console.WriteLine("Doing some work...");
            OnWorkCompleted();
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
