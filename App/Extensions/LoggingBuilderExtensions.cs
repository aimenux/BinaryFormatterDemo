using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Extensions
{
    public static class LoggingBuilderExtensions
    {
        public static void AddNonGenericLogger(this ILoggingBuilder loggingBuilder)
        {
            var categoryName = typeof(Program).Namespace;
            var services = loggingBuilder.Services;
            services.AddSingleton(serviceProvider =>
            {
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                return loggerFactory.CreateLogger(categoryName);
            });
        }
    }
}
