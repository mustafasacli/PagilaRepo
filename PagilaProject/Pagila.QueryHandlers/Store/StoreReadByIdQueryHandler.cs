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
    /// The store read by id query handler.
    /// </summary>
    public class StoreReadByIdQueryHandler : PagilaBaseQueryHandler<StoreReadByIdQuery, StoreResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<StoreResult> Handle(StoreReadByIdQuery query)
        {
            var response = new SimpleResponse<StoreResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var StoreEntList = database.Select<StoreEntity>(p => p.StoreId == query.Id)?.ToList() ?? new List<StoreEntity>();
                response.Data = new StoreResult
                {
                    Store = (StoreEntList.Select(p => Map<StoreEntity, StoreViewModel>(p)).ToList() ?? new List<StoreViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}