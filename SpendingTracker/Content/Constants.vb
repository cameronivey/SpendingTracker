﻿Imports SpendingTracker.Domain

Public Class Constants
    Public Shared Property Month_List As IEnumerable(Of SelectListItem) = New List(Of SelectListItem) From
                {
                    New SelectListItem() With {.Value = "January", .Text = "January"},
                    New SelectListItem() With {.Value = "February", .Text = "February"},
                    New SelectListItem() With {.Value = "March", .Text = "March"},
                    New SelectListItem() With {.Value = "April", .Text = "April"},
                    New SelectListItem() With {.Value = "May", .Text = "May"},
                    New SelectListItem() With {.Value = "June", .Text = "June"},
                    New SelectListItem() With {.Value = "July", .Text = "July"},
                    New SelectListItem() With {.Value = "August", .Text = "August"},
                    New SelectListItem() With {.Value = "September", .Text = "September"},
                    New SelectListItem() With {.Value = "October", .Text = "October"},
                    New SelectListItem() With {.Value = "November", .Text = "November"},
                    New SelectListItem() With {.Value = "December", .Text = "December"}
                }

    Public Shared Property Year_List As IEnumerable(Of SelectListItem) = New List(Of SelectListItem) From
                {
                    New SelectListItem() With {.Value = "2015", .Text = "2015"},
                    New SelectListItem() With {.Value = "2016", .Text = "2016"}
                }

    Public Shared Property SavingsTransactionType_SelectList As IEnumerable(Of SelectListItem) = New List(Of SelectListItem) From
               {
                   New SelectListItem() With {.Value = SavingsTransactionType.Deposit, .Text = "Deposit"},
                   New SelectListItem() With {.Value = SavingsTransactionType.Withdrawal, .Text = "Withdrawal"}
               }

    Public Shared Property Category_SelectList As IEnumerable(Of SelectListItem) = New List(Of SelectListItem) From
               {
                   New SelectListItem() With {.Value = "1", .Text = "Food"},
                   New SelectListItem() With {.Value = "2", .Text = "Alcohol / Bars"},
                   New SelectListItem() With {.Value = "3", .Text = "Entertainment"},
                   New SelectListItem() With {.Value = "4", .Text = "Shopping"},
                   New SelectListItem() With {.Value = "5", .Text = "Needs"},
                   New SelectListItem() With {.Value = "6", .Text = "Other"},
                   New SelectListItem() With {.Value = "10", .Text = "Income"}
               }

    Public Shared Property Category_List As List(Of String) = New List(Of String) From
        {
            "Food", "AlcoholBars", "Entertainment", "Shopping", "Needs", "Other"
        }

    Public Shared Property MonthName_List As List(Of String) = New List(Of String) From
       {
           "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
       }

    Public Shared Property CurrentStaticBills As Dictionary(Of Object, Object) = New Dictionary(Of Object, Object) From
        {
            {"Rent", 848},
            {"Parking", 100},
            {"Car", 270},
            {"Phone", 50},
            {"Cable", 35}
        }

    Public Shared Property CurrentPayCheckAmount As Decimal = 2145.4

End Class
