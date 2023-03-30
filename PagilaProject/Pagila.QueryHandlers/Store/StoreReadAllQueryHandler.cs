using Pagila.Entity;
using Pagila.Query.Store;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Store
{
    /// <summary>
    /// The store read all query handler.
    /// </summary>
    public class StoreReadAllQueryHandler : PagilaBaseQueryHandler<StoreReadAllQuery, StoreList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<StoreList> Handle(StoreReadAllQuery query)
        {
            var response = new SimpleResponse<StoreList>();

            using (var database = GetDatabase())
            {
                var StoreEntList = database.GetAll<StoreEntity>();
                response.Data = new StoreList
                {
                    Stores = StoreEntList.Select(p => Map<StoreEntity, StoreViewModel>(p)).ToList() ?? new List<StoreViewModel>()
                };
                response.ResponseCode = response.Data?.Stores?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}