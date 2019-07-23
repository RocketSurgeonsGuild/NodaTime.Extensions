using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rocket.Surgery.AspNetCore.Mvc.Conventions;
using Rocket.Surgery.AspNetCore.Mvc.Views;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NodaTime.Serialization.JsonNet;
using NodaTime;
using Rocket.Surgery.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;

[assembly: Convention(typeof(AspNetCoreConvention))]

namespace Rocket.Surgery.AspNetCore.Mvc.Conventions
{
    /// <summary>
    /// AspNetCoreConvention.
    /// </summary>
    /// <seealso cref="IServiceConvention" />
    public class AspNetCoreConvention : IServiceConvention
    {
        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Register(IServiceConventionContext context)
        {
            context.Services.Configure<MvcNewtonsoftJsonOptions>(options =>
            {
                options.SerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
                options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy(), true));
            });
        }
    }
}
