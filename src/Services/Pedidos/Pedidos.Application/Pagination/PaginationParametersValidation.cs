using System;
using System.Collections;
using System.Linq;
using System.Reflection;


namespace Pedidos.Application.Pagination
{
    public class PaginationParametersValidation
    {
        private const int MinimumPageIndex = 1;
        private const int MinimumPageSize = 20;

        public static int ValidatedPageIndex(int pageIndex)
        {
            return pageIndex < MinimumPageIndex ? MinimumPageIndex : pageIndex;
        }

        public static int ValidatedPageSize(int pageSize)
        {
            return pageSize < MinimumPageSize ? MinimumPageSize : pageSize;
        }

        public static string ValidatedSortProperty(string sort, Type objType)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                var properties = sort.Split('.');
                var tipoPropriedade = objType;

                foreach (var prop in properties)
                {
                    var propertyInfo = tipoPropriedade.GetMember(prop)
                        .Where(x => x is PropertyInfo)
                        .Cast<PropertyInfo>().FirstOrDefault();

                    if (propertyInfo != null)
                    {
                        tipoPropriedade = propertyInfo.PropertyType;

                        if (tipoPropriedade.GetInterfaces().Contains(typeof(IEnumerable)) && tipoPropriedade != typeof(string))
                        {
                            tipoPropriedade = tipoPropriedade.IsGenericType ?
                                tipoPropriedade.GetGenericArguments()[0] : tipoPropriedade.GetElementType();
                        }
                    }
                    else return string.Empty;
                }
            }

            return sort;
        }
    }
}