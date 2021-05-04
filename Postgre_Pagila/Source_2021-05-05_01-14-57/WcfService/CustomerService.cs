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
    public class CustomerService : ICustomerService
    {
        private ICustomerBusiness iCustomerBusiness;

        public CustomerService()
        {
            this.iCustomerBusiness =
                SimpleIoC.Instance.GetInstance<ICustomerBusiness>();
        }

        public SimpleResponse<CustomerDto> Create(CustomerDto dto)
        {
            var response = new SimpleResponse<CustomerDto>();

            try
            {
                var model = SimpleMapper.Map<CustomerDto, CustomerViewModel>(dto);
                var resp = iCustomerBusiness.Create(model);
                response = new SimpleResponse<CustomerDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<CustomerViewModel, CustomerDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<CustomerDto> Read(int customerId)
        {
            var response = new SimpleResponse<CustomerDto>();

            try
            {
                var resp  = iCustomerBusiness.Read(customerId);
                var isNullOrDef = resp.Data == null || resp.Data == default(CustomerViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<CustomerViewModel, CustomerDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(CustomerDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CustomerDto, CustomerViewModel>(dto);
                response = iCustomerBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(CustomerDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CustomerDto, CustomerViewModel>(dto);
                response = iCustomerBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int customerId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iCustomerBusiness.Delete(customerId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<CustomerDto>> ReadAll()
        {
            var response = new SimpleResponse<List<CustomerDto>>();

            try
            {
                var resp = iCustomerBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<CustomerViewModel, CustomerDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<CustomerDto>();
            return response;
        }
    }
}