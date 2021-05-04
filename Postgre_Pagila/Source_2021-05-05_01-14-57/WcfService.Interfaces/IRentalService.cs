using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/RentalService")]
    public interface IRentalService
    {
        [OperationContract]
        SimpleResponse<RentalDto> Create(RentalDto dto);

        [OperationContract]
        SimpleResponse<RentalDto> Read(int rentalId);

        [OperationContract]
        SimpleResponse Update(RentalDto dto);

        [OperationContract]
        SimpleResponse Delete(RentalDto dto);

        [OperationContract]
        SimpleResponse Delete(int rentalId);

        [OperationContract]
        SimpleResponse<List<RentalDto>> ReadAll();
    }
}