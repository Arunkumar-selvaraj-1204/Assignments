using System.Threading.Tasks;
using CollectionAndGenerics.Task1;
using CollectionAndGenerics.Task2;
using CollectionAndGenerics.Task3;
using CollectionAndGenerics.Task4;
namespace CollectionAndGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkingWithList workingWithList = new WorkingWithList();
            workingWithList.ExecuteListOperations();

            Stacks stacks = new Stacks();
            stacks.ExecuteStackOperations();

            Queues queues = new Queues();
            queues.ExecuteQueueOperations();

            Dictionaries dictionaries = new Dictionaries();
            dictionaries.ExecuteDictionaryOperations();
        }
    }
}
