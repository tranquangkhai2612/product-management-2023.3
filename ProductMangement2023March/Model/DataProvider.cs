using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangement2023March.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }
        public ShopManagement2023MarchEntities DB { get; set; }
        private DataProvider()
        {
            DB = new ShopManagement2023MarchEntities();
        }
    }
}
