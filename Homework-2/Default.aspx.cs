using dotnetCHARTING;
using OfficeOpenXml;
using System;
using System.Drawing;
using System.IO;

namespace Homework_2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeCharts();
            }
        }

        private void InitializeCharts()
        {
            // Initialize Chart1
            InitializeChart(Chart1, "~/Excels/bar-data.xlsx", "Sayfa1");
        }

        private void InitializeChart(Chart chart, string filePath, string sheetName)
        {
            // Set the chart type
            chart.Type = ChartType.ComboHorizontal;

            // Set the default series type
            chart.DefaultSeries.Type = SeriesType.Bar;

            // Set the x-axis label
            chart.XAxis.Label.Text = "Models";

            // Set the y-axis label
            chart.YAxis.Label.Text = "Accuracy (%)";

            // Set the directory where the images will be stored
            chart.TempDirectory = "temp";

            // Set the chart size
            chart.Width = 600;
            chart.Height = 350;

            // Load data from Excel and add to chart
            LoadDataFromExcel(chart, filePath, sheetName);
        }

        private void LoadDataFromExcel(Chart chart, string filePath, string sheetName)
        {
            // Load Excel file
            FileInfo fileInfo = new FileInfo(Server.MapPath(filePath));
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName]; // Update sheet name accordingly

                // Loop through rows and columns to populate chart
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Assuming data starts from second row
                {
                    string modelName = worksheet.Cells[row, 1].Value.ToString();
                    double positiveAccuracy = Convert.ToDouble(worksheet.Cells[row, 2].Value);
                    double negativeAccuracy = Convert.ToDouble(worksheet.Cells[row, 3].Value);

                    // Add series to chart
                    Series series = new Series();
                    series.Name = modelName;
                    series.Elements.Add(new Element("Positive", positiveAccuracy));
                    series.Elements.Add(new Element("Negative", negativeAccuracy));

                    chart.SeriesCollection.Add(series);
                }
            }
        }






    }
}
