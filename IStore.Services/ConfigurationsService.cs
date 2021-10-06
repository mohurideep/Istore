using IStore.Database;
using IStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IStore.Services
{
    public class ConfigurationsService
    {
        private readonly IStoreContext _storeContext;

        public ConfigurationsService(IStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Config GetConfig(string key)
        { 
            return _storeContext.Configurations.Find(key);
        }
    }
}
