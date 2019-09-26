using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;

namespace Dashboard_CreateChoroplethMap {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1() {
            InitializeComponent();

            Dashboard dashboard = new Dashboard();

            DashboardSqlDataSource dataSource = new DashboardSqlDataSource();
            CustomSqlQuery sqlQuery = new CustomSqlQuery("Countries", "select * from Countries");
            dataSource.ConnectionParameters = new Access97ConnectionParameters(@"..\..\Data\countriesDB.mdb", "", "");
            dataSource.Queries.Add(sqlQuery);

            ChoroplethMapDashboardItem choroplethMap = new ChoroplethMapDashboardItem();
            choroplethMap.DataSource = dataSource;
            choroplethMap.DataMember = "Countries";

            choroplethMap.Area = ShapefileArea.WorldCountries;

            choroplethMap.AttributeName = "NAME";
            choroplethMap.AttributeDimension = new Dimension("Country");

            ValueMap populationMap = new ValueMap(new Measure("Population"));
            choroplethMap.Maps.Add(populationMap);

            dashboard.Items.Add(choroplethMap);
            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
