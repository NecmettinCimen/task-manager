using System;
using Microsoft.AspNetCore.Http;

namespace TaskManager.Models
{
    public static class AppHttpContext
    {
        private static IServiceProvider services;

        /// <summary>
        ///     Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get => services;
            set
            {
                if (services != null) throw new Exception("Can't set once a value has already been set.");
                services = value;
            }
        }

        /// <summary>
        ///     Provides static access to the current HttpContext
        /// </summary>
        public static HttpContext Current
        {
            get
            {
                var httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }
    }
}