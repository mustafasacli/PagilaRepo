using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/CustomerService")]
    public interface ICustomerService
    {
        [OperationContract]
        SimpleResponse<CustomerDto> Create(CustomerDto dto);

        [OperationContract]
        SimpleResponse<CustomerDto> Read(int customerId);

        [OperationContract]
        SimpleResponse Update(CustomerDto dto);

        [OperationContract]
        SimpleResponse Delete(CustomerDto dto);

        [OperationContract]
        SimpleResponse Delete(int customerId);

        [OperationContract]
        SimpleResponse<List<CustomerDto>> ReadAll();
    }
}