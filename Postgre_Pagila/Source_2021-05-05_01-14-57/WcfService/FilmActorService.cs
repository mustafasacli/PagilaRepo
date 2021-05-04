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
    public class FilmActorService : IFilmActorService
    {
        private IFilmActorBusiness iFilmActorBusiness;

        public FilmActorService()
        {
            this.iFilmActorBusiness =
                SimpleIoC.Instance.GetInstance<IFilmActorBusiness>();
        }

        public SimpleResponse<FilmActorDto> Create(FilmActorDto dto)
        {
            var response = new SimpleResponse<FilmActorDto>();

            try
            {
                var model = SimpleMapper.Map<FilmActorDto, FilmActorViewModel>(dto);
                var resp = iFilmActorBusiness.Create(model);
                response = new SimpleResponse<FilmActorDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<FilmActorViewModel, FilmActorDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<FilmActorDto> Read(int actorId, int filmId)
        {
            var response = new SimpleResponse<FilmActorDto>();

            try
            {
                var resp  = iFilmActorBusiness.Read(actorId, filmId);
                var isNullOrDef = resp.Data == null || resp.Data == default(FilmActorViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<FilmActorViewModel, FilmActorDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(FilmActorDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<FilmActorDto, FilmActorViewModel>(dto);
                response = iFilmActorBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(FilmActorDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<FilmActorDto, FilmActorViewModel>(dto);
                response = iFilmActorBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int actorId, int filmId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iFilmActorBusiness.Delete(actorId, filmId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<FilmActorDto>> ReadAll()
        {
            var response = new SimpleResponse<List<FilmActorDto>>();

            try
            {
                var resp = iFilmActorBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<FilmActorViewModel, FilmActorDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<FilmActorDto>();
            return response;
        }
    }
}