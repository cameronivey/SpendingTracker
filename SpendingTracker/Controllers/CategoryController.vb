Imports System.Web.Script.Serialization
Imports SpendingTracket.DataAccessLayer

Namespace Controllers
    Public Class CategoryController
        Inherits Controller

        Private context As AppContext = New AppContext()
        Private totalsCalculator As TotalsCalculatorService = New TotalsCalculatorService()
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

        Function All() As ActionResult
            Return View()
        End Function
    End Class
End Namespace