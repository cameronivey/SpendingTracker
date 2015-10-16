@ModelType EditSavingsViewModel

@Code
    ViewData("Title") = "EditSavingsTransaction"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2 class="page-header">Edit Savings Transaction</h2>

@Using (Html.BeginForm("Edit", "Savings"))
    @<fieldset>
        <div class="form-group">
            <label>Date:</label>
            @Html.TextBoxFor(Function(m) Model.DateOfTransaction, New With {Key .class = "form-control", .id = "datepicker"})
        </div>

        <div class="form-group" style="float: left">
            <label>Type:</label>
            @Html.DropDownListFor(Function(m) Model.Type, Constants.SavingsTransactionType_SelectList, New With {Key .class = "form-control", .style = "float:left"})
        </div>

        <div class="form-group" style="clear: both">
            <label>Description:</label>
            @Html.TextBoxFor(Function(m) Model.Description, New With {Key .class = "form-control", .maxlength = "50", .style = "width: 400px", .placeholder = "Description"})
        </div>

        <div class="form-group" style="clear: both">
            <label>Amount</label>
            @Html.TextBoxFor(Function(m) Model.Amount, New With {Key .class = "form-control", .maxlength = "7", .style = "width: 80px", .placeholder = "$$$"})
        </div>

        @Html.TextBoxFor(Function(m) Model.Id, New With {Key .style = "display: none"})

        <button type="submit" class="btn btn-primary">Save Changes</button>

    </fieldset>
End Using

