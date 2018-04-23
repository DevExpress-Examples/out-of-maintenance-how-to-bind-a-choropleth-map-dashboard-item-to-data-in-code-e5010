using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace Dashboard_CreateChoroplethMap {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // Creates a new dashboard and a data source for this dashboard.
            Dashboard dashboard = new Dashboard();

            DashboardSqlDataSource dataSource = new DashboardSqlDataSource();
            CustomSqlQuery sqlQuery = new CustomSqlQuery("Countries", "select * from Countries");
            dataSource.ConnectionParameters = new Access97ConnectionParameters(@"..\..\Data\countriesDB.mdb", "", "");
            dataSource.Queries.Add(sqlQuery);

            // Creates a choropleth map dashboard item and specifies its data source.
            ChoroplethMapDashboardItem choroplethMap = new ChoroplethMapDashboardItem();
            choroplethMap.DataSource = dataSource;
            choroplethMap.DataMember = "Countries";

            // Loads the map of the world.
            choroplethMap.Area = ShapefileArea.WorldCountries;

            // Specifies a binding between the required map attribute and the data source field.
            choroplethMap.AttributeName = "NAME";
            choroplethMap.AttributeDimension = new Dimension("Country");

            // Creates a ValueMap object with a measure that provides data for color map shapes.
            // Then, adds this object to the Maps collection of the choropleth map dashboard item.
            ValueMap populationMap = new ValueMap(new Measure("Population"));
            choroplethMap.Maps.Add(populationMap);

            // Adds the choropleth map dashboard item to the dashboard and opens this
            // dashboard in the Dashboard Viewer.
            dashboard.Items.Add(choroplethMap);
            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
