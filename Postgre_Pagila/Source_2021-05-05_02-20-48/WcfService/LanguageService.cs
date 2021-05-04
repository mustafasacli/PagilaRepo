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
    public class LanguageService : ILanguageService
    {
        private ILanguageBusiness iLanguageBusiness;

        public LanguageService()
        {
            this.iLanguageBusiness =
                SimpleIoC.Instance.GetInstance<ILanguageBusiness>();
        }

        public SimpleResponse<LanguageDto> Create(LanguageDto dto)
        {
            var response = new SimpleResponse<LanguageDto>();

            try
            {
                var model = SimpleMapper.Map<LanguageDto, LanguageViewModel>(dto);
                var resp = iLanguageBusiness.Create(model);
                response = new SimpleResponse<LanguageDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<LanguageViewModel, LanguageDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<LanguageDto> Read(int languageId)
        {
            var response = new SimpleResponse<LanguageDto>();

            try
            {
                var resp  = iLanguageBusiness.Read(languageId);
                var isNullOrDef = resp.Data == null || resp.Data == default(LanguageViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<LanguageViewModel, LanguageDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(LanguageDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<LanguageDto, LanguageViewModel>(dto);
                response = iLanguageBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(LanguageDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<LanguageDto, LanguageViewModel>(dto);
                response = iLanguageBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int languageId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iLanguageBusiness.Delete(languageId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<LanguageDto>> ReadAll()
        {
            var response = new SimpleResponse<List<LanguageDto>>();

            try
            {
                var resp = iLanguageBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<LanguageViewModel, LanguageDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<LanguageDto>();
            return response;
        }
    }
}