using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Staff;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Staff
{
    public class StaffReadAllQueryHandler : PagilaBaseQueryHandler<StaffReadAllQuery, StaffList>
    {
        public override SimpleResponse<StaffList> Handle(StaffReadAllQuery query)
        {
            var response = new SimpleResponse<StaffList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var StaffEntList = connection.GetAll<StaffEntity>();
                    response.Data = new StaffList
                    {
                        Staffs = StaffEntList.Select(p => Map<StaffEntity, StaffViewModel>(p)).ToList() ?? new List<StaffViewModel>()
                    };
                    response.ResponseCode = response.Data?.Staffs?.Count ?? 0;
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