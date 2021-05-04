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
    public class FilmCategoryService : IFilmCategoryService
    {
        private IFilmCategoryBusiness iFilmCategoryBusiness;

        public FilmCategoryService()
        {
            this.iFilmCategoryBusiness =
                SimpleIoC.Instance.GetInstance<IFilmCategoryBusiness>();
        }

        public SimpleResponse<FilmCategoryDto> Create(FilmCategoryDto dto)
        {
            var response = new SimpleResponse<FilmCategoryDto>();

            try
            {
                var model = SimpleMapper.Map<FilmCategoryDto, FilmCategoryViewModel>(dto);
                var resp = iFilmCategoryBusiness.Create(model);
                response = new SimpleResponse<FilmCategoryDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<FilmCategoryViewModel, FilmCategoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<FilmCategoryDto> Read(int filmId, int categoryId)
        {
            var response = new SimpleResponse<FilmCategoryDto>();

            try
            {
                var resp  = iFilmCategoryBusiness.Read(filmId, categoryId);
                var isNullOrDef = resp.Data == null || resp.Data == default(FilmCategoryViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<FilmCategoryViewModel, FilmCategoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(FilmCategoryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<FilmCategoryDto, FilmCategoryViewModel>(dto);
                response = iFilmCategoryBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(FilmCategoryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<FilmCategoryDto, FilmCategoryViewModel>(dto);
                response = iFilmCategoryBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int filmId, int categoryId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iFilmCategoryBusiness.Delete(filmId, categoryId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<FilmCategoryDto>> ReadAll()
        {
            var response = new SimpleResponse<List<FilmCategoryDto>>();

            try
            {
                var resp = iFilmCategoryBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<FilmCategoryViewModel, FilmCategoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<FilmCategoryDto>();
            return response;
        }
    }
}