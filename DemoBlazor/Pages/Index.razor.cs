using System.IO;
using System.Data;
using FastReport;
using FastReport.Web.Blazor;

namespace DemoBlazor.Pages
{
    public partial class Index
    {
        const string DEFAULT_REPORT = "Simple List.frx";
        readonly string directory;

        DataSet DataSet { get; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            var report = Report.FromFile(
                Path.Combine(
                    directory,
                    string.IsNullOrEmpty(ReportName) ? DEFAULT_REPORT : ReportName));

            // Registers the user dataset
            report.RegisterData(DataSet, "NorthWind");

            // Create new WebReport object
            MyWebReport = new WebReport
            {
                Report = report,
            };
        }

        public Index()
        {
            directory = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    Path.Combine("Reports"));

            DataSet = new DataSet();
            DataSet.ReadXml(Path.Combine(directory, "nwind.xml"));
        }
    }
}
