using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAndGenerics.Task5.GenericCollectionImplementation;

namespace CollectionAndGenerics.Task5
{
    /// <summary>
    /// Class to implement task5
    /// </summary>
    public class GenericCollections
    {
        /// <summary>
        /// Invoke all the collections
        /// </summary>
        public void ExecuteGenericOperations()
        {
            Console.WriteLine("Generic List operations");
            new ListImplementation().Run();
            Console.WriteLine("Generic Stack operations");
            new StackImplementation().Run();
            Console.WriteLine("Generic Queue operations");
            new QueueImplementation().Run();
            Console.WriteLine("Generic Dictionary operations");
            new DictionaryImplementation().Run();
        }
    }
}
