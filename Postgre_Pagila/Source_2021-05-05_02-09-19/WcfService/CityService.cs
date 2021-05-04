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
    public class CityService : ICityService
    {
        private ICityBusiness iCityBusiness;

        public CityService()
        {
            this.iCityBusiness =
                SimpleIoC.Instance.GetInstance<ICityBusiness>();
        }

        public SimpleResponse<CityDto> Create(CityDto dto)
        {
            var response = new SimpleResponse<CityDto>();

            try
            {
                var model = SimpleMapper.Map<CityDto, CityViewModel>(dto);
                var resp = iCityBusiness.Create(model);
                response = new SimpleResponse<CityDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<CityViewModel, CityDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<CityDto> Read(int cityId)
        {
            var response = new SimpleResponse<CityDto>();

            try
            {
                var resp  = iCityBusiness.Read(cityId);
                var isNullOrDef = resp.Data == null || resp.Data == default(CityViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<CityViewModel, CityDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(CityDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CityDto, CityViewModel>(dto);
                response = iCityBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(CityDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CityDto, CityViewModel>(dto);
                response = iCityBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int cityId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iCityBusiness.Delete(cityId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<CityDto>> ReadAll()
        {
            var response = new SimpleResponse<List<CityDto>>();

            try
            {
                var resp = iCityBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<CityViewModel, CityDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<CityDto>();
            return response;
        }
    }
}