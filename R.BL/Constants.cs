using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.BL
{
    public static class Constants
    {
        public static class ErrorMessages
        {
            public const string NotFound = "{0} with id = {1} not found";
            public static string BuildNotFoundMessage(string entity, int id) => string.Format(NotFound, entity, id);
        }
    }
}
