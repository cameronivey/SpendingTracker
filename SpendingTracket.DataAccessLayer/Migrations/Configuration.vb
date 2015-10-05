Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports SpendingTracker.Domain

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of AppContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
        End Sub

        Protected Overrides Sub Seed(context As AppContext)
            context.Transactions.Add(New Transaction() With {.Description = "sample", .Cost = 1})

            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})

            context.Categories.AddOrUpdate(
                Function(c) c.Name,
                New Category() With {.Name = "Food"},
                New Category() With {.Name = "Alcohol / Bars"},
                New Category() With {.Name = "Entertainment"},
                New Category() With {.Name = "Shopping"},
                New Category() With {.Name = "Needs"},
                New Category() With {.Name = "Other"})

        End Sub

    End Class

End Namespace
