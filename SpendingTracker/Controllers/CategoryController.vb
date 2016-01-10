Imports System.Web.Script.Serialization
Imports SpendingTracket.DataAccessLayer

Namespace Controllers
    Public Class CategoryController
        Inherits Controller

        Private context As AppContext = New AppContext()
        Private totalsCalculator As TotalsCalculator = New TotalsCalculator()
        Private Serializer As JavaScriptSerializer = New JavaScriptSerializer()

        ' GET: Category
        Function Index(viewModel As CategoryViewModel) As ActionResult
            If viewModel.CategoryName Is Nothing Then
                viewModel.CategoryName = context.Categories.SingleOrDefault(Function(c) c.Name = "Food").Name
            End If

            If viewModel.Year = 0 Then
                viewModel.Year = DateTime.Now.Year
            End If

            Dim category = context.Categories.SingleOrDefault(Function(c) c.Name = viewModel.CategoryName)

            For Each mon In Constants.MonthName_List
                viewModel.MonthTotals.Add(mon, totalsCalculator.GetTotalCost(category, mon, viewModel.Year))
            Next

            viewModel.Total = totalsCalculator.GetTotalCost(category, viewModel.Year)

            Dim dataList = New List(Of Decimal)
            Dim monthList = New List(Of String)
            For Each mon In Constants.MonthName_List
                Dim amt = totalsCalculator.GetTotalCost(mon, viewModel.Year)
                If amt > 0 Then
                    monthList.Add(mon)
                    dataList.Add(totalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = viewModel.CategoryName), mon, viewModel.Year))
                End If
            Next

            viewModel.LabelsJavascriptString = Serializer.Serialize(monthList.ToArray)
            viewModel.DataJavascriptString = Serializer.Serialize(dataList.ToArray)

            Return View(viewModel)
        End Function

        Function All(viewModel As AllGraphsViewModel) As ActionResult
            If viewModel.Year = 0 Then
                viewModel.Year = DateTime.Now.Year
            End If

            Dim incomeDataList = New List(Of Decimal)
            Dim totalSpentDataList = New List(Of Decimal)
            Dim monthList = New List(Of String)
            For Each mon In Constants.MonthName_List
                Dim amt = totalsCalculator.GetTotalCost(mon, viewModel.Year)
                If amt > 0 Then
                    monthList.Add(mon)
                    incomeDataList.Add(totalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = "Income"), mon, viewModel.Year))
                    totalSpentDataList.Add(totalsCalculator.GetTotalCost(mon, viewModel.Year))
                End If
            Next

            viewModel.LabelsJsString = Serializer.Serialize(monthList.ToArray)
            viewModel.Income_DataJsString = Serializer.Serialize(incomeDataList.ToArray)
            viewModel.TotalSpent_DataJsString = Serializer.Serialize(totalSpentDataList.ToArray)

            Return View(viewModel)
        End Function

        <HttpPost()>
        Function GetChartData(category As String, year As Integer) As ActionResult
            Dim viewModel = New ChartDataViewModel()

            Dim dataList = New List(Of Decimal)
            Dim labelList = New List(Of String)

            For Each mon In Constants.MonthName_List
                Dim amt = totalsCalculator.GetTotalCost(mon, year)
                If amt > 0 Then
                    labelList.Add(mon)
                    dataList.Add(totalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = category), mon, year))
                End If
            Next

            viewModel.Labels = labelList.ToArray
            viewModel.Data = dataList.ToArray

            Return Json(viewModel)
        End Function

        <HttpPost()>
        Function GetTotalSpentChartData(year As Integer) As ActionResult
            Dim viewModel = New ChartDataViewModel()

            Dim dataList = New List(Of Decimal)
            Dim labelList = New List(Of String)

            For Each mon In Constants.MonthName_List
                Dim amt = totalsCalculator.GetTotalCost(mon, year)
                If amt > 0 Then
                    labelList.Add(mon)
                    dataList.Add(totalsCalculator.GetTotalCost(mon, year))
                End If
            Next

            viewModel.Labels = labelList.ToArray
            viewModel.Data = dataList.ToArray

            Return Json(viewModel)
        End Function

        <HttpPost()>
        Function GetTotalSpentWithoutNeedsChartData(year As Integer) As ActionResult
            Dim viewModel = New ChartDataViewModel()

            Dim dataList = New List(Of Decimal)
            Dim labelList = New List(Of String)

            For Each mon In Constants.MonthName_List
                Dim amt = totalsCalculator.GetTotalCost(mon, year)
                If amt > 0 Then
                    labelList.Add(mon)
                    dataList.Add(totalsCalculator.GetTotalCost(mon, year) - totalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = "Needs"), mon, year))
                End If
            Next

            viewModel.Labels = labelList.ToArray
            viewModel.Data = dataList.ToArray

            Return Json(viewModel)
        End Function

        <HttpPost()>
        Function GetNetIncomeChartData(year As Integer) As ActionResult
            Dim viewModel = New ChartDataViewModel()

            Dim dataList = New List(Of Decimal)
            Dim labelList = New List(Of String)

            For Each mon In Constants.MonthName_List
                Dim amt = totalsCalculator.GetTotalCost(mon, year)
                If amt > 0 Then
                    labelList.Add(mon)
                    dataList.Add(totalsCalculator.GetTotalCost(context.Categories.SingleOrDefault(Function(c) c.Name = "Income"), mon, year) - totalsCalculator.GetTotalCost(mon, year))
                End If
            Next

            viewModel.Labels = labelList.ToArray
            viewModel.Data = dataList.ToArray

            Return Json(viewModel)
        End Function
    End Class
End Namespace