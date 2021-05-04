using Pagila.Business.Interfaces;
using Pagila.Context;
using Pagila.Entity;
using Pagila.ViewModel;
using SimpleFileLogging;
using SimpleInfra.Common.Core;
using SimpleInfra.Common.Response;
using SimpleInfra.Business.Core;
using SimpleInfra.Mapping;
using SimpleInfra.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pagila.Business
{
    /// <summary>
    /// Defines the <see cref="LanguageBusiness"/>.
    /// </summary>
    public class LanguageBusiness : SimpleBaseBusiness, ILanguageBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageBusiness"/> class.
        /// </summary>
        public LanguageBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for LanguageViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="LanguageViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{LanguageViewModel}"/>.</returns>
        public SimpleResponse<LanguageViewModel> Create(LanguageViewModel model)
        {
            var response = new SimpleResponse<LanguageViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<LanguageViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicDbContext())
                {
                    var entity = Map<LanguageViewModel, Language>(model);
                    context.Language.Add(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Ekleme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// The Reads for LanguageViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{LanguageViewModel}"/>.</returns>
        public SimpleResponse<LanguageViewModel> Read(int languageId)
        {
            var response = new SimpleResponse<LanguageViewModel>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Language
                        .AsNoTracking()
                        .SingleOrDefault(q => q.LanguageId == languageId);

                    if (entity == null || entity == default(Language))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Language, LanguageViewModel>(entity);
                    response.ResponseCode = 1;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Updates entity for LanguageViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="LanguageViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(LanguageViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse
                    {
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicDbContext())
                {
                    var entity = context.Language.SingleOrDefault(q => q.LanguageId == model.LanguageId);
                    if (entity == null || entity == default(Language))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Language.Attach(entity);
                    // context.Entry(entity).State = EntityState.Modified;
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes entity for LanguageViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="LanguageViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(LanguageViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Language.FirstOrDefault(q => q.LanguageId == model.LanguageId);
                    if (entity == null || entity == default(Language))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Language.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(int languageId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Language.SingleOrDefault(q => q.LanguageId == languageId);
                    if (entity == null || entity == default(Language))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Language.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Reads All records for LanguageViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{LanguageViewModel}}"/>.</returns>
        public SimpleResponse<List<LanguageViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<LanguageViewModel>>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entities = context.Language
                        .AsNoTracking()
                        .ToList() ?? new List<Language>();

                    response.Data = MapList<Language, LanguageViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<LanguageViewModel>();
            return response;
        }
    }
}