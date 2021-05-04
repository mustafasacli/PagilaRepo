using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/FilmService")]
    public interface IFilmService
    {
        [OperationContract]
        SimpleResponse<FilmDto> Create(FilmDto dto);

        [OperationContract]
        SimpleResponse<FilmDto> Read(int filmId);

        [OperationContract]
        SimpleResponse Update(FilmDto dto);

        [OperationContract]
        SimpleResponse Delete(FilmDto dto);

        [OperationContract]
        SimpleResponse Delete(int filmId);

        [OperationContract]
        SimpleResponse<List<FilmDto>> ReadAll();
    }
}