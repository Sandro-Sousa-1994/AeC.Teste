using AeC.Teste.Web.Services.Interfaces;
using System.Reflection;
using System.Text;

namespace AeC.Teste.Web.Services
{
    public class CsvService : ICsvService
    {
        public byte[] GenerateCsv<T>(IEnumerable<T> data) where T : class
        {
            if (data == null || !data.Any())
                return Encoding.UTF8.GetBytes("");

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
            var sb = new StringBuilder();

            var headerRow = string.Join(",", properties.Select(p => EscapeCsvValue(p.Name)));
            sb.AppendLine(headerRow);

            foreach (var item in data)
            {
                var values = properties.Select(p => EscapeCsvValue(p.GetValue(item)?.ToString() ?? ""));
                var dataRow = string.Join(",", values);
                sb.AppendLine(dataRow);
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "\"\"";

            if (value.Contains("\"") || value.Contains(",") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }
    }
}
