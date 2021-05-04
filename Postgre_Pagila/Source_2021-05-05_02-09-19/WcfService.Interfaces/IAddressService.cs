using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/AddressService")]
    public interface IAddressService
    {
        [OperationContract]
        SimpleResponse<AddressDto> Create(AddressDto dto);

        [OperationContract]
        SimpleResponse<AddressDto> Read(int addressId);

        [OperationContract]
        SimpleResponse Update(AddressDto dto);

        [OperationContract]
        SimpleResponse Delete(AddressDto dto);

        [OperationContract]
        SimpleResponse Delete(int addressId);

        [OperationContract]
        SimpleResponse<List<AddressDto>> ReadAll();
    }
}