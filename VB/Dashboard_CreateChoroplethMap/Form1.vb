Imports System.Windows.Forms
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Namespace Dashboard_CreateChoroplethMap
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            ' Creates a new dashboard and a data source for this dashboard.
            Dim dashboard As New Dashboard()

            Dim dataSource As New DashboardSqlDataSource()
            Dim sqlQuery As New CustomSqlQuery("Countries", "select * from Countries")
            dataSource.ConnectionParameters = New Access97ConnectionParameters("..\..\Data\countriesDB.mdb", "", "")
            dataSource.Queries.Add(sqlQuery)

            ' Creates a choropleth map dashboard item and specifies its data source.
            Dim choroplethMap As New ChoroplethMapDashboardItem()
            choroplethMap.DataSource = dataSource
            choroplethMap.DataMember = "Countries"

            ' Loads the map of the world.
            choroplethMap.Area = ShapefileArea.WorldCountries

            ' Specifies a binding between the required map attribute and the data source field.
            choroplethMap.AttributeName = "NAME"
            choroplethMap.AttributeDimension = New Dimension("Country")

            ' Creates a ValueMap object with a measure that provides data for color map shapes.
            ' Then, adds this object to the Maps collection of the choropleth map dashboard item.
            Dim populationMap As New ValueMap(New Measure("Population"))
            choroplethMap.Maps.Add(populationMap)

            ' Adds the choropleth map dashboard item to the dashboard and opens this
            ' dashboard in the Dashboard Viewer.
            dashboard.Items.Add(choroplethMap)
            dashboardViewer1.Dashboard = dashboard
        End Sub
    End Class
End Namespace
