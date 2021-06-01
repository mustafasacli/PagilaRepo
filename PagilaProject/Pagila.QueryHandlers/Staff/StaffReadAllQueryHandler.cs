using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Staff;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Staff
{
    public class StaffReadAllQueryHandler : PagilaBaseQueryHandler<StaffReadAllQuery, StaffList>
    {
        public override SimpleResponse<StaffList> Handle(StaffReadAllQuery query)
        {
            var response = new SimpleResponse<StaffList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var StaffEntList = connection.GetAll<StaffEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
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
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }
    }
}