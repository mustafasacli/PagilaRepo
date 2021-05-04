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
    public class RentalService : IRentalService
    {
        private IRentalBusiness iRentalBusiness;

        public RentalService()
        {
            this.iRentalBusiness =
                SimpleIoC.Instance.GetInstance<IRentalBusiness>();
        }

        public SimpleResponse<RentalDto> Create(RentalDto dto)
        {
            var response = new SimpleResponse<RentalDto>();

            try
            {
                var model = SimpleMapper.Map<RentalDto, RentalViewModel>(dto);
                var resp = iRentalBusiness.Create(model);
                response = new SimpleResponse<RentalDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<RentalViewModel, RentalDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<RentalDto> Read(int rentalId)
        {
            var response = new SimpleResponse<RentalDto>();

            try
            {
                var resp  = iRentalBusiness.Read(rentalId);
                var isNullOrDef = resp.Data == null || resp.Data == default(RentalViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<RentalViewModel, RentalDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(RentalDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<RentalDto, RentalViewModel>(dto);
                response = iRentalBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(RentalDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<RentalDto, RentalViewModel>(dto);
                response = iRentalBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int rentalId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iRentalBusiness.Delete(rentalId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<RentalDto>> ReadAll()
        {
            var response = new SimpleResponse<List<RentalDto>>();

            try
            {
                var resp = iRentalBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<RentalViewModel, RentalDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<RentalDto>();
            return response;
        }
    }
}