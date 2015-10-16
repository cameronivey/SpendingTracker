@ModelType AddSavingsViewModel

@Using (Html.BeginForm("Add", "Savings"))

    @<div class="form-group">
        <label>Date:</label>  
        @Html.TextBoxFor(Function(Model) Model.DateOfTransaction, New With {Key .class = "form-control", .id = "datepicker"})
    </div>

    @<div Class="form-group" style="float: left">
        <label>Type:</label>
        @Html.DropDownListFor(Function(Model) Model.Type, Constants.SavingsTransactionType_SelectList, New With {Key .class = "form-control", .style = "float:left"})
    </div>

    @<div Class="form-group" style="clear: both">
        <label>Description:</label>        
         @Html.TextBoxFor(Function(Model) Model.Description, New With {Key .class = "form-control", .maxlength = "50", .style = "width: 400px", .placeholder = "Description"})
    </div>

    @<div Class="form-group" style="clear: both">
        <Label>Amount</label>
        @Html.TextBoxFor(Function(m) Model.Amount, New With {Key .class = "form-control", .maxlength = "7", .style = "width: 80px", .placeholder = "$$$"})
    </div>

    @<button type="submit" class="btn btn-success">Add</button>

End Using