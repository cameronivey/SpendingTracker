@ModelType CategoriesViewModel

@Code
    ViewData("Title") = "Categories"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Categories</h2>

<table>
    <tr>
        <th>Name</th>
        <th># of Transactions</th>
        </tr>
    
    @For Each category In Model.Categories
        @<tr>
            <td>@category.Name</td>
            <td align="center">@category.Transactions.Count</td>
        </tr>
    Next
</table>

