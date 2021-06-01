using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Rental;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Rental
{
    public class RentalReadByIdQueryHandler : PagilaBaseQueryHandler<RentalReadByIdQuery, RentalResult>
    {
        public override SimpleResponse<RentalResult> Handle(RentalReadByIdQuery query)
        {
            var response = new SimpleResponse<RentalResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var RentalEntList = connection.Select<RentalEntity>(p => p.RentalId == query.Id)?.ToList() ?? new List<RentalEntity>();
                        response.Data = new RentalResult
                        {
                            Rental = (RentalEntList.Select(p => Map<RentalEntity, RentalViewModel>(p)).ToList() ?? new List<RentalViewModel>()).FirstOrDefault()
                        };
                        response.ResponseCode = response.Data != null ? 1 : 0;
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