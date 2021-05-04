using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/StoreService")]
    public interface IStoreService
    {
        [OperationContract]
        SimpleResponse<StoreDto> Create(StoreDto dto);

        [OperationContract]
        SimpleResponse<StoreDto> Read(int storeId);

        [OperationContract]
        SimpleResponse Update(StoreDto dto);

        [OperationContract]
        SimpleResponse Delete(StoreDto dto);

        [OperationContract]
        SimpleResponse Delete(int storeId);

        [OperationContract]
        SimpleResponse<List<StoreDto>> ReadAll();
    }
}