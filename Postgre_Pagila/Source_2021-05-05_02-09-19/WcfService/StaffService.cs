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
    public class StaffService : IStaffService
    {
        private IStaffBusiness iStaffBusiness;

        public StaffService()
        {
            this.iStaffBusiness =
                SimpleIoC.Instance.GetInstance<IStaffBusiness>();
        }

        public SimpleResponse<StaffDto> Create(StaffDto dto)
        {
            var response = new SimpleResponse<StaffDto>();

            try
            {
                var model = SimpleMapper.Map<StaffDto, StaffViewModel>(dto);
                var resp = iStaffBusiness.Create(model);
                response = new SimpleResponse<StaffDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<StaffViewModel, StaffDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<StaffDto> Read(int staffId)
        {
            var response = new SimpleResponse<StaffDto>();

            try
            {
                var resp  = iStaffBusiness.Read(staffId);
                var isNullOrDef = resp.Data == null || resp.Data == default(StaffViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<StaffViewModel, StaffDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(StaffDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<StaffDto, StaffViewModel>(dto);
                response = iStaffBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(StaffDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<StaffDto, StaffViewModel>(dto);
                response = iStaffBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int staffId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iStaffBusiness.Delete(staffId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<StaffDto>> ReadAll()
        {
            var response = new SimpleResponse<List<StaffDto>>();

            try
            {
                var resp = iStaffBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<StaffViewModel, StaffDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<StaffDto>();
            return response;
        }
    }
}