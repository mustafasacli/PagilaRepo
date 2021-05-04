using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/FilmActorService")]
    public interface IFilmActorService
    {
        [OperationContract]
        SimpleResponse<FilmActorDto> Create(FilmActorDto dto);

        [OperationContract]
        SimpleResponse<FilmActorDto> Read(int actorId, int filmId);

        [OperationContract]
        SimpleResponse Update(FilmActorDto dto);

        [OperationContract]
        SimpleResponse Delete(FilmActorDto dto);

        [OperationContract]
        SimpleResponse Delete(int actorId, int filmId);

        [OperationContract]
        SimpleResponse<List<FilmActorDto>> ReadAll();
    }
}