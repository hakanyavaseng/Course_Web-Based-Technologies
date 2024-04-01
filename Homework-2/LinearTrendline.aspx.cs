using dotnetCHARTING;
using System;
using System.Drawing;
using System.Linq;

namespace Homework_2
{
    public partial class LinearTrendline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Demonstrates how to create a Linear trendline calculation with prediction.

            Chart.Type = ChartType.Combo;
            Chart.Title = "WEB BASED TECH HW2-HAKAN_YAVAS";
            Chart.Width = 750;
            Chart.Height = 300;
            Chart.TempDirectory = "temp";
            Chart.Debug = false;
            Chart.XAxis.Scale = Scale.Range;
            Chart.DefaultSeries.Type = SeriesType.Line;
            Chart.DefaultSeries.Line.Width = 2;
            Chart.DefaultSeries.DefaultElement.Transparency = 45;
            Chart.LegendBox.Visible = false;
            Chart.DefaultSeries.DefaultElement.Marker.Type = ElementMarkerType.None;
            Chart.YAxis.DefaultTick.Label.Text = "$%valueB";
            // Js settings
            Chart.JS.Enabled = true;
            Chart.XAxis.Crosshair = new AxisTick();

            string str = "xx";
            Annotation an = new Annotation(str);
            an.Position = new Point(60, 40);
            an.DynamicSize = false;
            an.Label.Font = new Font("Tahoma", 12);
            an.Background.Color = Color.Transparent;
            an.Line.Color = Color.Transparent;
            Chart.Annotations.Add(an);

            // Create Series Collection
            SeriesCollection sc = new SeriesCollection();

            // Load data from CSV
            string[] lines = System.IO.File.ReadAllLines(Server.MapPath("~/Excels/linear-fit-data.csv"));
            if (sc.Count == 0) // Ensure there's at least one series in the collection
                sc.Add(new Series());
            foreach (string line in lines.Skip(1)) // Skip header line
            {
                string[] parts = line.Split(',');
                double xValue = double.Parse(parts[0]);
                double yValue = double.Parse(parts[1]);
                Element element = new Element();
                element.XValue = xValue; // Assign x-value
                element.YValue = yValue; // Assign y-value
                sc[0].Elements.Add(element);
            }

            // Get a trend line from series 1. Because only the SeriesCollection Calculate method returns a series a
            // SeriesCollection is instantiated and the method is used.
            Series trend = sc.Calculate("Series 1 Trend", Calculation.TrendLineLinear, 20);
            // Split the trend series into 2 series: trendActual and trendPredict
            Series trendActual = new Series();
            trendActual.Type = SeriesType.Line;
            Series trendPredict = new Series();
            // Set the type to line
            trendPredict.Type = SeriesType.Line;
            trendPredict.Line.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            trendPredict.DefaultElement.Color = Color.Red;

            for (int i = 0; i < sc[0].Elements.Count; i++)
            {
                trend.Elements[i].XValue = sc[0].Elements[i].XValue;
                trend.Elements[i].YValue = sc[0].Elements[i].YValue;
                trendActual.Elements.Add(trend.Elements[i]);
            }

            // Assuming the last data point in the CSV is the last point of prediction
            Element last = trend.Elements[trend.Elements.Count - 1].Clone();
            last.XValue = 10; // Set x-value for the last point of prediction
            trendPredict.Elements.Add(last);

            // Add the trend lines to the collection.
            sc.Add(trendActual);
            sc.Add(trendPredict);

            // Add the collection.
            Chart.SeriesCollection.Add(sc);
        }
    }
}
