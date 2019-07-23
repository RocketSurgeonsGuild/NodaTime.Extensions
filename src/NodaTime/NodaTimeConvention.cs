using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using NodaTime.TimeZones;
using Rocket.Surgery.Extensions.NodaTime;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Extensions.DependencyInjection;

[assembly: Convention(typeof(NodaTimeConvention))]

namespace Rocket.Surgery.Extensions.NodaTime
{
    public class NodaTimeConvention : IServiceConvention
    {
        public void Register(IServiceConventionContext context)
        {
            context.Services.AddSingleton<IClock>(SystemClock.Instance);
            context.Services.AddSingleton<IDateTimeZoneProvider, DateTimeZoneCache>();
            context.Services.AddSingleton<IDateTimeZoneSource>(TzdbDateTimeZoneSource.Default);
        }
    }
}
