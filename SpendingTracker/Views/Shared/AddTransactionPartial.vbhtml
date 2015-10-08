@ModelType AddTransactionViewModel

<div class="form-group" style="float: left">
    @Html.LabelFor(Function(m) m.Year)
    @Html.DropDownListFor(Function(m) m.Year, Constants.Year_List, New With {Key .class = "form-control", .style = "float:left", .id = "tYear"})
</div>

<div class="form-group" style="float: left">
    @Html.LabelFor(Function(m) Model.Month)
    @Html.DropDownListFor(Function(m) Model.Month, Constants.Month_List, New With {Key .class = "form-control", .style = "float: left", .id = "tMonth"})
</div>

<div class="form-group" style="clear: both">
    <label style="float: left">Category</label><br />
    @Html.DropDownListFor(Function(m) Model.CategoryId, Constants.Category_SelectList, New With {Key .class = "form-control", .style = "clear: both; width: 120px", .id = "tCategoryId"})
</div>

<div class="form-group">
    <label>Description</label>
    @Html.TextBoxFor(Function(m) Model.Description, New With {Key .class = "form-control", .maxlength = "20", .style = "width: 200px", .placeholder = "Description", .id = "tDescription"})
</div>

<div class="form-group">
    <label>Cost</label>
    @Html.TextBoxFor(Function(m) Model.Cost, New With {Key .class = "form-control", .maxlength = "7", .style = "width: 80px", .placeholder = "$$$", .id = "tCost"})
</div>

