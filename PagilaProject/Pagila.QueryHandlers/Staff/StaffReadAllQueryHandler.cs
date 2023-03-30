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
    /// The staff read all query handler.
    /// </summary>
    public class StaffReadAllQueryHandler : PagilaBaseQueryHandler<StaffReadAllQuery, StaffList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<StaffList> Handle(StaffReadAllQuery query)
        {
            var response = new SimpleResponse<StaffList>();

            using (var database = GetDatabase())
            {
                var StaffEntList = database.GetAll<StaffEntity>();
                response.Data = new StaffList
                {
                    Staffs = StaffEntList.Select(p => Map<StaffEntity, StaffViewModel>(p)).ToList() ?? new List<StaffViewModel>()
                };
                response.ResponseCode = response.Data?.Staffs?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}