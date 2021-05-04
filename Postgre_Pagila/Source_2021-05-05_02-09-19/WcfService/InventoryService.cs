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
    public class InventoryService : IInventoryService
    {
        private IInventoryBusiness iInventoryBusiness;

        public InventoryService()
        {
            this.iInventoryBusiness =
                SimpleIoC.Instance.GetInstance<IInventoryBusiness>();
        }

        public SimpleResponse<InventoryDto> Create(InventoryDto dto)
        {
            var response = new SimpleResponse<InventoryDto>();

            try
            {
                var model = SimpleMapper.Map<InventoryDto, InventoryViewModel>(dto);
                var resp = iInventoryBusiness.Create(model);
                response = new SimpleResponse<InventoryDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<InventoryViewModel, InventoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<InventoryDto> Read(int inventoryId)
        {
            var response = new SimpleResponse<InventoryDto>();

            try
            {
                var resp  = iInventoryBusiness.Read(inventoryId);
                var isNullOrDef = resp.Data == null || resp.Data == default(InventoryViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<InventoryViewModel, InventoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(InventoryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<InventoryDto, InventoryViewModel>(dto);
                response = iInventoryBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(InventoryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<InventoryDto, InventoryViewModel>(dto);
                response = iInventoryBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int inventoryId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iInventoryBusiness.Delete(inventoryId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<InventoryDto>> ReadAll()
        {
            var response = new SimpleResponse<List<InventoryDto>>();

            try
            {
                var resp = iInventoryBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<InventoryViewModel, InventoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<InventoryDto>();
            return response;
        }
    }
}