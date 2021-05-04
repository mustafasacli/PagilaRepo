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
    public class StoreService : IStoreService
    {
        private IStoreBusiness iStoreBusiness;

        public StoreService()
        {
            this.iStoreBusiness =
                SimpleIoC.Instance.GetInstance<IStoreBusiness>();
        }

        public SimpleResponse<StoreDto> Create(StoreDto dto)
        {
            var response = new SimpleResponse<StoreDto>();

            try
            {
                var model = SimpleMapper.Map<StoreDto, StoreViewModel>(dto);
                var resp = iStoreBusiness.Create(model);
                response = new SimpleResponse<StoreDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<StoreViewModel, StoreDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<StoreDto> Read(int storeId)
        {
            var response = new SimpleResponse<StoreDto>();

            try
            {
                var resp  = iStoreBusiness.Read(storeId);
                var isNullOrDef = resp.Data == null || resp.Data == default(StoreViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<StoreViewModel, StoreDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(StoreDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<StoreDto, StoreViewModel>(dto);
                response = iStoreBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(StoreDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<StoreDto, StoreViewModel>(dto);
                response = iStoreBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int storeId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iStoreBusiness.Delete(storeId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<StoreDto>> ReadAll()
        {
            var response = new SimpleResponse<List<StoreDto>>();

            try
            {
                var resp = iStoreBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<StoreViewModel, StoreDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<StoreDto>();
            return response;
        }
    }
}