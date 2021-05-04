using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/CategoryService")]
    public interface ICategoryService
    {
        [OperationContract]
        SimpleResponse<CategoryDto> Create(CategoryDto dto);

        [OperationContract]
        SimpleResponse<CategoryDto> Read(int categoryId);

        [OperationContract]
        SimpleResponse Update(CategoryDto dto);

        [OperationContract]
        SimpleResponse Delete(CategoryDto dto);

        [OperationContract]
        SimpleResponse Delete(int categoryId);

        [OperationContract]
        SimpleResponse<List<CategoryDto>> ReadAll();
    }
}