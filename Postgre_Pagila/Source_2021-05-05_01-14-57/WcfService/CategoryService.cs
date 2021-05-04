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
    public class CategoryService : ICategoryService
    {
        private ICategoryBusiness iCategoryBusiness;

        public CategoryService()
        {
            this.iCategoryBusiness =
                SimpleIoC.Instance.GetInstance<ICategoryBusiness>();
        }

        public SimpleResponse<CategoryDto> Create(CategoryDto dto)
        {
            var response = new SimpleResponse<CategoryDto>();

            try
            {
                var model = SimpleMapper.Map<CategoryDto, CategoryViewModel>(dto);
                var resp = iCategoryBusiness.Create(model);
                response = new SimpleResponse<CategoryDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<CategoryViewModel, CategoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<CategoryDto> Read(int categoryId)
        {
            var response = new SimpleResponse<CategoryDto>();

            try
            {
                var resp  = iCategoryBusiness.Read(categoryId);
                var isNullOrDef = resp.Data == null || resp.Data == default(CategoryViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<CategoryViewModel, CategoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(CategoryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CategoryDto, CategoryViewModel>(dto);
                response = iCategoryBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(CategoryDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<CategoryDto, CategoryViewModel>(dto);
                response = iCategoryBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int categoryId)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iCategoryBusiness.Delete(categoryId);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<CategoryDto>> ReadAll()
        {
            var response = new SimpleResponse<List<CategoryDto>>();

            try
            {
                var resp = iCategoryBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<CategoryViewModel, CategoryDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<CategoryDto>();
            return response;
        }
    }
}