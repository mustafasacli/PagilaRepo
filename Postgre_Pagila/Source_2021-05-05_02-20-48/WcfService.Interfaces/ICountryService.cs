using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/CountryService")]
    public interface ICountryService
    {
        [OperationContract]
        SimpleResponse<CountryDto> Create(CountryDto dto);

        [OperationContract]
        SimpleResponse<CountryDto> Read(int countryId);

        [OperationContract]
        SimpleResponse Update(CountryDto dto);

        [OperationContract]
        SimpleResponse Delete(CountryDto dto);

        [OperationContract]
        SimpleResponse Delete(int countryId);

        [OperationContract]
        SimpleResponse<List<CountryDto>> ReadAll();
    }
}