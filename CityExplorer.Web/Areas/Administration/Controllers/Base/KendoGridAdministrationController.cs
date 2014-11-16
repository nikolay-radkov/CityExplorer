﻿namespace CityExplorer.Web.Areas.Administration.Controllers.Base
{
    using System.Collections;
    using System.Web.Mvc;

    using CityExplorer.Data;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using System.Data.Entity;
    using AutoMapper;
    using CityExplorer.Web.Areas.Administration.ViewModels.Base;
    using CityExplorer.Data.Contracts;
    using System.Linq;

    public abstract class KendoGridAdministrationController : AdminController
    {
        public KendoGridAdministrationController(ICityExplorerData data)
            : base(data)
        {
        }

        protected abstract IQueryable<T> GetData<T>() where T : class;

        protected abstract T GetById<T>(object id) where T : class;

        [HttpPost]
        public virtual ActionResult Read<TModel, TViewModel>([DataSourceRequest]DataSourceRequest request)
            where TModel : AuditInfo
            where TViewModel : AdministrationViewModel
        {
            var result =
                this.GetData<TModel>()
               .ToDataSourceResult(request, o => Mapper.Map<TViewModel>(o));

            return this.Json(result);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : AuditInfo
            where TViewModel : AdministrationViewModel
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                Mapper.Map<TViewModel, TModel>(model, dbModel);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);
                model.ModifiedOn = dbModel.ModifiedOn;
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dbModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}