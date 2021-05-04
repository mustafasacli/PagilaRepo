using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/LanguageService")]
    public interface ILanguageService
    {
        [OperationContract]
        SimpleResponse<LanguageDto> Create(LanguageDto dto);

        [OperationContract]
        SimpleResponse<LanguageDto> Read(int languageId);

        [OperationContract]
        SimpleResponse Update(LanguageDto dto);

        [OperationContract]
        SimpleResponse Delete(LanguageDto dto);

        [OperationContract]
        SimpleResponse Delete(int languageId);

        [OperationContract]
        SimpleResponse<List<LanguageDto>> ReadAll();
    }
}