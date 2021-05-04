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
    public class FilmService : IFilmService
    {
        private IFilmBusiness iFilmBusiness;

        public FilmService()
        {
            this.iFilmBusiness =
                SimpleIoC.Instance.GetInstance<IFilmBusiness>();
        }

        public SimpleResponse<FilmDto> Create(FilmDto dto)
        {
            var response = new SimpleResponse<FilmDto>();

            try
            {
                var model = SimpleMapper.Map<FilmDto, FilmViewModel>(dto);
                var resp = iFilmBusiness.Create(model);
                response = new SimpleResponse<FilmDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<FilmViewModel, FilmDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<FilmDto> Read(int filmId)
        {
            var response = new SimpleResponse<FilmDto>();

            try
            {
                var resp  = iFilmBusiness.Read(filmId);
                var isNullOrDef = resp.Data == null || resp.Data == default(FilmViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<FilmViewModel, FilmDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(FilmDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<FilmDto, FilmViewModel>(dto);
                response = iFilmBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(FilmDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<FilmDto, FilmViewModel>(dto);
                response = iFilmBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int filmId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iFilmBusiness.Delete(filmId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<FilmDto>> ReadAll()
        {
            var response = new SimpleResponse<List<FilmDto>>();

            try
            {
                var resp = iFilmBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<FilmViewModel, FilmDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<FilmDto>();
            return response;
        }
    }
}