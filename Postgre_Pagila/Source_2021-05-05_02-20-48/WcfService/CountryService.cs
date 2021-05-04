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
    public class CountryService : ICountryService
    {
        private ICountryBusiness iCountryBusiness;

        public CountryService()
        {
            this.iCountryBusiness =
                SimpleIoC.Instance.GetInstance<ICountryBusiness>();
        }

        public SimpleResponse<CountryDto> Create(CountryDto dto)
        {
            var response = new SimpleResponse<CountryDto>();

            try
            {
                var model = SimpleMapper.Map<CountryDto, CountryViewModel>(dto);
                var resp = iCountryBusiness.Create(model);
                response = new SimpleResponse<CountryDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<CountryViewModel, CountryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<CountryDto> Read(int countryId)
        {
            var response = new SimpleResponse<CountryDto>();

            try
            {
                var resp  = iCountryBusiness.Read(countryId);
                var isNullOrDef = resp.Data == null || resp.Data == default(CountryViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<CountryViewModel, CountryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(CountryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CountryDto, CountryViewModel>(dto);
                response = iCountryBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(CountryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CountryDto, CountryViewModel>(dto);
                response = iCountryBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int countryId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iCountryBusiness.Delete(countryId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<CountryDto>> ReadAll()
        {
            var response = new SimpleResponse<List<CountryDto>>();

            try
            {
                var resp = iCountryBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<CountryViewModel, CountryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<CountryDto>();
            return response;
        }
    }
}