using Pagila.Entity;
using Pagila.Query.Staff;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Staff
{
    /// <summary>
    /// The staff read by id query handler.
    /// </summary>
    public class StaffReadByIdQueryHandler : PagilaBaseQueryHandler<StaffReadByIdQuery, StaffResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<StaffResult> Handle(StaffReadByIdQuery query)
        {
            var response = new SimpleResponse<StaffResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var StaffEntList = database.Select<StaffEntity>(p => p.StaffId == query.Id)?.ToList() ?? new List<StaffEntity>();
                response.Data = new StaffResult
                {
                    Staff = (StaffEntList.Select(p => Map<StaffEntity, StaffViewModel>(p)).ToList() ?? new List<StaffViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}