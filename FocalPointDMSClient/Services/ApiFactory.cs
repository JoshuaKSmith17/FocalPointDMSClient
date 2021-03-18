using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Services
{
    class ApiFactory
    {   
        public Dictionary<EntityType, Func<IApiServiceStrategy>> serviceCreators { get; private set; }
        public ApiFactory()
        {
            serviceCreators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof (IApiServiceStrategy).IsAssignableFrom(t) && t.IsInterface == false)
                .Select(t => new Func<IApiServiceStrategy>(() => Activator.CreateInstance(t) as IApiServiceStrategy))
                .ToDictionary(f => f().EntityType);
        }
        
        public IApiServiceStrategy GetInstance(EntityType entityType)
        {
            return serviceCreators[entityType]();
        }
    }
}
