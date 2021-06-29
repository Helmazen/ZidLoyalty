using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZidLoyalty.Integration
{
    public class StoreIntegration
    {
        public static object getStoreFromZed(long StoreId)
        {

            if  (StoreId < 3) return new { };

            return null;

        }
    }
}
