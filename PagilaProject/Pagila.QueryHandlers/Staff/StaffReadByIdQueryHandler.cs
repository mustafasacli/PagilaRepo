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
    public class StaffReadByIdQueryHandler : PagilaBaseQueryHandler<StaffReadByIdQuery, StaffResult>
    {
        public override SimpleResponse<StaffResult> Handle(StaffReadByIdQuery query)
        {
            var response = new SimpleResponse<StaffResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var StaffEntList = connection.Select<StaffEntity>(p => p.StaffId == query.Id)?.ToList() ?? new List<StaffEntity>();
                    response.Data = new StaffResult
                    {
                        Staff = (StaffEntList.Select(p => Map<StaffEntity, StaffViewModel>(p)).ToList() ?? new List<StaffViewModel>()).FirstOrDefault()
                    };
                    response.ResponseCode = response.Data != null ? 1 : 0;
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