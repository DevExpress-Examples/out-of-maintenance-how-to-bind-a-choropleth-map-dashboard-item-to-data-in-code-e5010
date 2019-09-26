Imports System.Windows.Forms
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Namespace Dashboard_CreateChoroplethMap
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()

			Dim dashboard As New Dashboard()

			Dim dataSource As New DashboardSqlDataSource()
			Dim sqlQuery As New CustomSqlQuery("Countries", "select * from Countries")
			dataSource.ConnectionParameters = New Access97ConnectionParameters("..\..\Data\countriesDB.mdb", "", "")
			dataSource.Queries.Add(sqlQuery)

			Dim choroplethMap As New ChoroplethMapDashboardItem()
			choroplethMap.DataSource = dataSource
			choroplethMap.DataMember = "Countries"

			choroplethMap.Area = ShapefileArea.WorldCountries

			choroplethMap.AttributeName = "NAME"
			choroplethMap.AttributeDimension = New Dimension("Country")

			Dim populationMap As New ValueMap(New Measure("Population"))
			choroplethMap.Maps.Add(populationMap)

			dashboard.Items.Add(choroplethMap)
			dashboardViewer1.Dashboard = dashboard
		End Sub
	End Class
End Namespace
