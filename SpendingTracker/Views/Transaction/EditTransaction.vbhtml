@ModelType EditTransactionViewModel

@Code
    ViewData("Title") = "EditTransaction"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2 class="page-header">Edit Transaction</h2>
    @Using (Html.BeginForm("EditTransaction", "Transaction"))
        @<fieldset>
            <div class="form-group" style="float: left">
                @Html.LabelFor(Function(m) Model.Year)
                @Html.DropDownListFor(Function(m) Model.Year, Constants.Year_List, New With {Key .class = "form-control", .style = "float:left"})
            </div>

             <div class="form-group" style="float: left">
                 @Html.LabelFor(Function(m) Model.Month)
                 @Html.DropDownListFor(Function(m) Model.Month, Constants.Month_List, New With {Key .class = "form-control", .style = "float: left"})
            </div>
                 
            <div class="form-group" style="clear: both">
                @Html.DropDownListFor(Function(m) Model.CategoryId, Constants.Category_List, New With {Key .class = "form-control", .style = "float: left; width: 120px"})<br />

                @*<select name="category" class="form-control" id="categorySelect">
                    @For Each category In Model.Categories
                        @<option value="@category.Id">@category.Name</option>
                    Next
                </select>*@
            </div>

            @Html.TextBoxFor(Function(m) Model.Description, New With {Key .class = "form-control", .maxlength = "20", .style = "width: 200px"})<br />
            @*<input name="description" class="form-control" type="text" maxlength="20" placeholder="Description" style="width: 200px" /><br />*@

            @Html.TextBoxFor(Function(m) Model.Cost, New With {Key .class = "form-control", .maxlength = "7", .style = "width: 80px"})<br />

            @*<input name="cost" class="form-control" type="text" maxlength="7" placeholder="$$$" style="width: 80px" /><br />*@

            <button type="submit" class="btn btn-primary">Save Transaction</button><br /><br />
    </fieldset>
    End Using

<button class="btn btn-danger" onclick="deleteTransaction(@Model.Id)" >Delete Transaction</button>

