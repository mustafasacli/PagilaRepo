using Pagila.Dtos;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pagila.WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://127.0.0.1:8081/ActorService")]
    public interface IActorService
    {
        [OperationContract]
        SimpleResponse<ActorDto> Create(ActorDto dto);

        [OperationContract]
        SimpleResponse<ActorDto> Read(int actorId);

        [OperationContract]
        SimpleResponse Update(ActorDto dto);

        [OperationContract]
        SimpleResponse Delete(ActorDto dto);

        [OperationContract]
        SimpleResponse Delete(int actorId);

        [OperationContract]
        SimpleResponse<List<ActorDto>> ReadAll();
    }
}