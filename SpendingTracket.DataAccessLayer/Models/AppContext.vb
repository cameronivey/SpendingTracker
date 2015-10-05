﻿Imports System.Data.Entity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports SpendingTracker.Domain

Public Class AppContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("SpendingTrackerDatabaseLocal", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As AppContext
        Return New AppContext()
    End Function

    Public Property Transactions As DbSet(Of Transaction)
    Public Property Categories As DbSet(Of Category)

End Class
