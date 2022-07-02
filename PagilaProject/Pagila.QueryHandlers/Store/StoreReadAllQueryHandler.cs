using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Store;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Store
{
    public class StoreReadAllQueryHandler : PagilaBaseQueryHandler<StoreReadAllQuery, StoreList>
    {
        public override SimpleResponse<StoreList> Handle(StoreReadAllQuery query)
        {
            var response = new SimpleResponse<StoreList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var StoreEntList = connection.GetAll<StoreEntity>();
                    response.Data = new StoreList
                    {
                        Stores = StoreEntList.Select(p => Map<StoreEntity, StoreViewModel>(p)).ToList() ?? new List<StoreViewModel>()
                    };
                    response.ResponseCode = response.Data?.Stores?.Count ?? 0;
                    response.RCode = response.ResponseCode.ToString();
                }
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }
    }
}