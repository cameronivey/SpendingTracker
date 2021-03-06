﻿@ModelType EditTransactionViewModel

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
                @Html.DropDownListFor(Function(m) Model.CategoryId, Constants.Category_SelectList, New With {Key .class = "form-control", .style = "float: left; width: 120px"})<br />
            </div>

            @Html.TextBoxFor(Function(m) Model.Description, New With {Key .class = "form-control", .maxlength = "20", .style = "width: 200px"})<br />
            @Html.TextBoxFor(Function(m) Model.Vendor, New With {Key .class = "form-control", .maxlength = "20", .style = "width: 200px"})<br />

            @Html.TextBoxFor(Function(m) Model.Cost, New With {Key .class = "form-control", .maxlength = "7", .style = "width: 80px"})<br />

            <button type="submit" class="btn btn-primary">Save Transaction</button><br /><br />
    </fieldset>
    End Using

<button class="btn btn-danger" onclick="deleteTransaction(@Model.Id)" >Delete Transaction</button>

