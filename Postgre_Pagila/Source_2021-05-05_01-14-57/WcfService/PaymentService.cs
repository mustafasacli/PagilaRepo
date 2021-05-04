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
    public class PaymentService : IPaymentService
    {
        private IPaymentBusiness iPaymentBusiness;

        public PaymentService()
        {
            this.iPaymentBusiness =
                SimpleIoC.Instance.GetInstance<IPaymentBusiness>();
        }

        public SimpleResponse<PaymentDto> Create(PaymentDto dto)
        {
            var response = new SimpleResponse<PaymentDto>();

            try
            {
                var model = SimpleMapper.Map<PaymentDto, PaymentViewModel>(dto);
                var resp = iPaymentBusiness.Create(model);
                response = new SimpleResponse<PaymentDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<PaymentViewModel, PaymentDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<PaymentDto>> ReadAll()
        {
            var response = new SimpleResponse<List<PaymentDto>>();

            try
            {
                var resp = iPaymentBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<PaymentViewModel, PaymentDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<PaymentDto>();
            return response;
        }
    }
}