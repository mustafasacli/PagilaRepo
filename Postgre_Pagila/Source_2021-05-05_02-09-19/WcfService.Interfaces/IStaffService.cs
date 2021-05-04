using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/StaffService")]
    public interface IStaffService
    {
        [OperationContract]
        SimpleResponse<StaffDto> Create(StaffDto dto);

        [OperationContract]
        SimpleResponse<StaffDto> Read(int staffId);

        [OperationContract]
        SimpleResponse Update(StaffDto dto);

        [OperationContract]
        SimpleResponse Delete(StaffDto dto);

        [OperationContract]
        SimpleResponse Delete(int staffId);

        [OperationContract]
        SimpleResponse<List<StaffDto>> ReadAll();
    }
}