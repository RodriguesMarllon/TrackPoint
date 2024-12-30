using Domain.InterfacesRepositories.Abstract;
using System.Globalization;
using System.Reflection;

namespace Infrastructure.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository
        where T : class
    {
        //public async Task<List<IDictionary<string, object>>> GetAllModeledColumnFiltered(List<string> columnsToShow, string orderByColumnName, string orderByColumnType, string dateFormat, string? searchString = "", List<string>? columnsToSearch = null)
        //{
        //    var modeledData = await GetAllModeledToFilter();

        //    if (!string.IsNullOrEmpty(searchString) && columnsToSearch?.Count > 0)
        //    {
        //        modeledData = SearchByProperty(modeledData, searchString, columnsToSearch);
        //    }

        //    var filteredData = FilterColumns(modeledData, columnsToShow);

        //    var orderedData = OrderData(filteredData, orderByColumnName, orderByColumnType);

        //    FormatDateFields(orderedData, dateFormat);

        //    return orderedData;
        //}

        //public abstract Task<List<T>> GetAllModeledToFilter();

        public List<T> SearchByProperty(List<T> list,  string searchString, List<string> properties)
        {
            var results = new List<T>();

            foreach (var item in list)
            {
                bool found = false;

                foreach (var property in properties)
                {
                    var propInfo = typeof(T).GetProperty(property, BindingFlags.Public | BindingFlags.Instance);

                    if (propInfo != null && propInfo.PropertyType == typeof(string))
                    {
                        var value = propInfo.GetValue(item)?.ToString();

                        if (value != null && value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public List<IDictionary<string, object>> FilterColumns(List<T> data, List<string> columnsToShow)
        {
            var result = new List<IDictionary<string, object>>();

            foreach (var item in data)
            {
                var dict = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

                var properties = item.GetType().GetProperties();

                foreach (var column in columnsToShow)
                {
                    var prop = properties.FirstOrDefault(p => p.Name.Equals(column, StringComparison.OrdinalIgnoreCase));
                    if (prop != null)
                    {
                        dict[column] = prop.GetValue(item);
                    }
                }

                result.Add(dict);
            }

            return result;
        }

        public List<IDictionary<string, object>> OrderData(List<IDictionary<string, object>> data, string orderByColumnName, string orderByColumnType)
        {
            if (string.IsNullOrEmpty(orderByColumnName) || string.IsNullOrEmpty(orderByColumnType))
                return data;

            if (orderByColumnType.ToUpper() == "DESC")
            {
                return data.OrderByDescending(d => d.ContainsKey(orderByColumnName) ? d[orderByColumnName]?.ToString() : null, StringComparer.OrdinalIgnoreCase).ToList();
            }

            return data.OrderBy(d => d.ContainsKey(orderByColumnName) ? d[orderByColumnName]?.ToString() : null, StringComparer.OrdinalIgnoreCase).ToList();
        }

        public void FormatDateFields(List<IDictionary<string, object>> data, string dateFormat)
        {
            foreach (var dict in data)
            {
                var keysToRemove = new List<string>();
                foreach (var key in dict.Keys.ToList())
                {
                    if (dict[key] is DateTime dateTimeValue)
                    {
                        dict[key] = dateTimeValue.ToString(dateFormat, CultureInfo.InvariantCulture);
                    }
                }
            }
        }
    }
}
