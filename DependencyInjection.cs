using ContentManagement.DataAccess.ContentRepository;
using ContentManagement.DataAccess.Wrapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentManagement
{
    public static class DependencyInjection
    {

        public static void Register(IServiceCollection service)
        {
            service.AddScoped<IContentRepository, ContentRepository>();
            service.AddScoped<IWrapper, Wrapper>();

        }

    }
}
