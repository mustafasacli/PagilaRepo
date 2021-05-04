using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/InventoryService")]
    public interface IInventoryService
    {
        [OperationContract]
        SimpleResponse<InventoryDto> Create(InventoryDto dto);

        [OperationContract]
        SimpleResponse<InventoryDto> Read(int inventoryId);

        [OperationContract]
        SimpleResponse Update(InventoryDto dto);

        [OperationContract]
        SimpleResponse Delete(InventoryDto dto);

        [OperationContract]
        SimpleResponse Delete(int inventoryId);

        [OperationContract]
        SimpleResponse<List<InventoryDto>> ReadAll();
    }
}