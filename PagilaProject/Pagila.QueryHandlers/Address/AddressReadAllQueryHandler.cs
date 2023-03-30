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
    /// The address read all query handler.
    /// </summary>
    public class AddressReadAllQueryHandler : PagilaBaseQueryHandler<AddressReadAllQuery, AddressList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<AddressList> Handle(AddressReadAllQuery query)
        {
            var response = new SimpleResponse<AddressList>();

            using (var database = GetDatabase())
            {
                var actorEntList = database.GetAll<AddressEntity>();
                response.Data = new AddressList
                {
                    Addresses = actorEntList.Select(p => new AddressViewModel
                    {
                        AddressId = p.AddressId,
                        Address = p.Address,
                        Address2 = p.Address2,
                        District = p.District,
                        CityId = p.CityId,
                        PostalCode = p.PostalCode,
                        Phone = p.Phone,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<AddressViewModel>()
                };
                response.ResponseCode = response.Data?.Addresses?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}