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
    public class AddressService : IAddressService
    {
        private IAddressBusiness iAddressBusiness;

        public AddressService()
        {
            this.iAddressBusiness =
                SimpleIoC.Instance.GetInstance<IAddressBusiness>();
        }

        public SimpleResponse<AddressDto> Create(AddressDto dto)
        {
            var response = new SimpleResponse<AddressDto>();

            try
            {
                var model = SimpleMapper.Map<AddressDto, AddressViewModel>(dto);
                var resp = iAddressBusiness.Create(model);
                response = new SimpleResponse<AddressDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<AddressViewModel, AddressDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<AddressDto> Read(int addressId)
        {
            var response = new SimpleResponse<AddressDto>();

            try
            {
                var resp  = iAddressBusiness.Read(addressId);
                var isNullOrDef = resp.Data == null || resp.Data == default(AddressViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<AddressViewModel, AddressDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(AddressDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<AddressDto, AddressViewModel>(dto);
                response = iAddressBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(AddressDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<AddressDto, AddressViewModel>(dto);
                response = iAddressBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int addressId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iAddressBusiness.Delete(addressId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<AddressDto>> ReadAll()
        {
            var response = new SimpleResponse<List<AddressDto>>();

            try
            {
                var resp = iAddressBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<AddressViewModel, AddressDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<AddressDto>();
            return response;
        }
    }
}