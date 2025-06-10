using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGenerics.Task6
{
    /// <summary>
    /// Class implements task6
    /// </summary>
    public class UnderstandingCollections
    {
        private UnderstandIEnumerable _understandIEnumerable;
        private UnderstandingReadOnlyCollection _understandReadOnlyCollection;

        /// <summary>
        /// Constructor initialize value
        /// </summary>
        public UnderstandingCollections()
        {
            _understandIEnumerable = new UnderstandIEnumerable();
            _understandReadOnlyCollection = new UnderstandingReadOnlyCollection();
        }

        /// <summary>
        /// Invoke all methods
        /// </summary>
        public void ExecuteTask6()
        {
            _understandIEnumerable.ExecuteIEnumerableOperations();
            _understandReadOnlyCollection.ExecuteReadOnlyCollectionOperations();
        }
    }
}
