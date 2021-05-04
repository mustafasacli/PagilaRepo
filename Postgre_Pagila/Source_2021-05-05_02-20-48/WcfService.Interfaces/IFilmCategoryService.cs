using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/FilmCategoryService")]
    public interface IFilmCategoryService
    {
        [OperationContract]
        SimpleResponse<FilmCategoryDto> Create(FilmCategoryDto dto);

        [OperationContract]
        SimpleResponse<FilmCategoryDto> Read(int filmId, int categoryId);

        [OperationContract]
        SimpleResponse Update(FilmCategoryDto dto);

        [OperationContract]
        SimpleResponse Delete(FilmCategoryDto dto);

        [OperationContract]
        SimpleResponse Delete(int filmId, int categoryId);

        [OperationContract]
        SimpleResponse<List<FilmCategoryDto>> ReadAll();
    }
}