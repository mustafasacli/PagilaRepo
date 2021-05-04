using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/CityService")]
    public interface ICityService
    {
        [OperationContract]
        SimpleResponse<CityDto> Create(CityDto dto);

        [OperationContract]
        SimpleResponse<CityDto> Read(int cityId);

        [OperationContract]
        SimpleResponse Update(CityDto dto);

        [OperationContract]
        SimpleResponse Delete(CityDto dto);

        [OperationContract]
        SimpleResponse Delete(int cityId);

        [OperationContract]
        SimpleResponse<List<CityDto>> ReadAll();
    }
}