using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.DataTableBuilders
{
    class DataTableBuilderFactory
    {
        public Dictionary<EntityType, Func<IDataTableBuilder>> serviceCreators { get; private set; }
        public DataTableBuilderFactory()
        {
            serviceCreators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IDataTableBuilder).IsAssignableFrom(t) && t.IsInterface == false)
                .Select(t => new Func<IDataTableBuilder>(() => Activator.CreateInstance(t) as IDataTableBuilder))
                .ToDictionary(f => f().EntityType);
        }

        public IDataTableBuilder GetInstance(EntityType entityType)
        {
            return serviceCreators[entityType]();
        }
    }
}
