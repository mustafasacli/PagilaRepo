using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/PaymentService")]
    public interface IPaymentService
    {
        [OperationContract]
        SimpleResponse<PaymentDto> Create(PaymentDto dto);

        [OperationContract]
        SimpleResponse<List<PaymentDto>> ReadAll();
    }
}