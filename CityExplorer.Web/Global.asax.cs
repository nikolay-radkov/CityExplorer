namespace CityExplorer.Web
{
    using CityExplorer.Web.Infrastructure.Mapping;
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableDateTimeBinder());
           
            ViewEnginesConfiguration.RegisterViewEngines(ViewEngines.Engines);

            AutoMapperConfig.Execute();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public class DateTimeBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

                //var date = value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
                var date = DateTime.Parse(value.AttemptedValue, CultureInfo.InvariantCulture);

                return date;
            }
        }
        public class NullableDateTimeBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (value != null)
                {
                    var date = value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
                    return date;
                }
                return null;
            }
        }
    }
}
