using Pagila.Dtos;
using Pagila.Business.Interfaces;
using Pagila.WcfService.Interfaces;
using Pagila.ViewModel;
using SimpleFileLogging;
using SimpleInfra.Business.Core;
using SimpleInfra.Common.Core;
using SimpleInfra.IoC;
using SimpleInfra.Common.Response;
using SimpleInfra.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Pagila.WcfService
{
    public class ActorService : IActorService
    {
        private IActorBusiness iActorBusiness;

        public ActorService()
        {
            this.iActorBusiness =
                SimpleIoC.Instance.GetInstance<IActorBusiness>();
        }

        public SimpleResponse<ActorDto> Create(ActorDto dto)
        {
            var response = new SimpleResponse<ActorDto>();

            try
            {
                var model = SimpleMapper.Map<ActorDto, ActorViewModel>(dto);
                var resp = iActorBusiness.Create(model);
                response = new SimpleResponse<ActorDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<ActorViewModel, ActorDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ActorDto> Read(int actorId)
        {
            var response = new SimpleResponse<ActorDto>();

            try
            {
                var resp  = iActorBusiness.Read(actorId);
                var isNullOrDef = resp.Data == null || resp.Data == default(ActorViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<ActorViewModel, ActorDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ActorDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ActorDto, ActorViewModel>(dto);
                response = iActorBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ActorDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ActorDto, ActorViewModel>(dto);
                response = iActorBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int actorId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iActorBusiness.Delete(actorId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ActorDto>> ReadAll()
        {
            var response = new SimpleResponse<List<ActorDto>>();

            try
            {
                var resp = iActorBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<ActorViewModel, ActorDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<ActorDto>();
            return response;
        }
    }
}