using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Controllers
{
    class ControllerFactory
    {
        public Dictionary<EntityType, Func<IDataTableProvider>> serviceCreators { get; private set; }
        public ControllerFactory()
        {
            serviceCreators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IDataTableProvider).IsAssignableFrom(t) && t.IsInterface == false)
                .Select(t => new Func<IDataTableProvider>(() => Activator.CreateInstance(t) as IDataTableProvider))
                .ToDictionary(f => f().EntityType);
        }

        public IDataTableProvider GetInstance(EntityType entityType)
        {
            return serviceCreators[entityType]();
        }
    }
}
