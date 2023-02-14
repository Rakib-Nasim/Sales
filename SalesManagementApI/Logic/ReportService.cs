using AspNetCore.Reporting;
using Dapper;
using SalesManagementApI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApI.Logic
{
    public interface IReportService
    {
        byte[] GenerateReportAsync(int id);
    }

    public class ReportService : IReportService
    {
        public byte[] GenerateReportAsync(int id)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("SalesManagementApI.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}Report\\{1}.rdlc", fileDirPath, "UserDetails");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);


            IEnumerable<OrderDetails> dataset = new List<OrderDetails>();
            using (var conn = new SqlConnection("Server=DESKTOP-IN1JKER;Database=SalesDB;Trusted_Connection=True;Encrypt=false"))
            {
                var peram = new
                {
                    id
                };

                dataset = conn.Query<OrderDetails>("GetOrder", param: peram, commandType: CommandType.StoredProcedure).ToList();
            }

            report.AddDataSource("DataSet",dataset);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var result = report.Execute(RenderType.Pdf,1, parameters);

            return result.MainStream;            
        }

    }
}
