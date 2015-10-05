Imports SpendingTracket.DataAccessLayer

Namespace Controllers
    Public Class CategoryController
        Inherits Controller

        ' GET: Category
        Function Index() As ActionResult
            Dim context = New AppContext()

            Dim viewModel = New CategoriesViewModel
            With viewModel
                .Categories = context.Categories.ToList
            End With

            Return View(viewModel)
        End Function
    End Class
End Namespace