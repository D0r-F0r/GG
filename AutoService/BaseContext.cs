using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService
{
    internal class BaseContext
    {
        private static КAdEntities _getContext;

        public static КAdEntities GetContext()
        {
            if (_getContext == null)
                _getContext = new КAdEntities();

            return _getContext;
        }
    }
}
