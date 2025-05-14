using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LanguageIntegratedQuery
{
    internal class QueryBuilder<T, T2>
    {
        List<Func<T, bool>> FilterQueries = new List<Func<T, bool>>();
        List<Func<T, object>> SortQueries = new List<Func<T, object>>();
        Func<T, T2, bool> joinQuery;
        private IEnumerable<T> _primaryList { get; set; }
        private IEnumerable<T2> _secondaryList { get; set; }
        public IEnumerable<T> queryResult { get; set; }

        public QueryBuilder(IEnumerable<T> primaryList, IEnumerable<T2> secondaryList)
        {
            _secondaryList = secondaryList;
            _primaryList = primaryList;
        }

        /// <summary>
        /// Adds lambda function to the filterQueries list.
        /// </summary>
        /// <param name="filterCondition">Filter condition</param>
        /// <returns>Instance of this class.</returns>
        public QueryBuilder<T, T2> Filter(Func<T, bool> filterCondition)
        {
            FilterQueries.Add(filterCondition);
            return this;
        }

        /// <summary>
        /// Adds lambda function to the SortQueries list.
        /// </summary>
        /// <typeparam name="TKey">Return type of the lambda function</typeparam>
        /// <param name="keySelector">The key used to sort the list.</param>
        /// <returns>Instance of this class.</returns>
        public QueryBuilder<T, T2> SortBy<TKey>(Func<T, TKey> keySelector) where TKey : class  
        {
            SortQueries.Add(keySelector);
            return this;
        }

        /// <summary>
        /// Assigns joinCondition to joinQuery
        /// </summary>
        /// <param name="joinCondition">Join condition</param>
        /// <returns>Instance of this class.</returns>
        public QueryBuilder<T, T2> Join(Func<T, T2, bool> joinCondition)
        {
            joinQuery = joinCondition;
            return this;
        }

        /// <summary>
        /// Executes all filterQueries and SortQueries. If join is not null then joins with secondaryList.
        /// </summary>
        /// <returns>result of the query</returns>
        public IEnumerable<object> Execute()
        {
            queryResult = _primaryList;
            foreach (var filterQuery in FilterQueries)
            {
                queryResult = queryResult.Where(filterQuery);
            }
            foreach(var sortQuery in SortQueries)
            {
                queryResult =  queryResult.OrderBy(sortQuery);
            }
            if(joinQuery is not null)
            {
                var joinResult = (from source in queryResult
                              from source2 in _secondaryList
                              where (joinQuery(source, source2))
                              select new Tuple<T, T2>(source, source2)).ToList();
                joinQuery = null;
                return joinResult;
            }
            FilterQueries.Clear();
            SortQueries.Clear();
            return queryResult.Cast<object>();
        }
    }

}
