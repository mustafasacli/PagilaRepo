using Pagila.Entity;
using Pagila.Query.Address;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Address
{
    /// <summary>
    /// The address read by id query handler.
    /// </summary>
    public class AddressReadByIdQueryHandler : PagilaBaseQueryHandler<AddressReadByIdQuery, AddressResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<AddressResult> Handle(AddressReadByIdQuery query)
        {
            var response = new SimpleResponse<AddressResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var actorEntList = database.Select<AddressEntity>(p => p.AddressId == query.Id)?.ToList() ?? new List<AddressEntity>();
                response.Data = new AddressResult
                {
                    Address = (actorEntList.Select(p => new AddressViewModel
                    {
                        AddressId = p.AddressId,
                        Address = p.Address,
                        Address2 = p.Address2,
                        District = p.District,
                        CityId = p.CityId,
                        PostalCode = p.PostalCode,
                        Phone = p.Phone,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<AddressViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}