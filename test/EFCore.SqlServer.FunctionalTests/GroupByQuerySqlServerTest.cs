// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Specification.Tests;
using Microsoft.EntityFrameworkCore.Specification.Tests.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.Specification.Tests.TestUtilities.Xunit;
using Microsoft.EntityFrameworkCore.SqlServer.FunctionalTests.Utilities;
using Xunit;
using Xunit.Abstractions;

#if !NET452
using System.Threading;
#endif

namespace Microsoft.EntityFrameworkCore.SqlServer.FunctionalTests
{
    public class GroupByQuerySqlServerTest : GroupByQueryTestBase<NorthwindQuerySqlServerFixture>
    {
        public GroupByQuerySqlServerTest(NorthwindQuerySqlServerFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            Fixture.TestSqlLoggerFactory.Clear();
            //Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
        }

        public override void GroupBy_anonymous()
        {
            base.GroupBy_anonymous();

            AssertSql(
                @"SELECT [c].[City], [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[City]");
        }

        public override void GroupBy_anonymous_with_where()
        {
            base.GroupBy_anonymous_with_where();

            AssertSql(
                @"SELECT [c].[City], [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[Country] IN (N'Argentina', N'Austria', N'Brazil', N'France', N'Germany', N'USA')
ORDER BY [c].[City]");
        }

        public override void GroupBy_anonymous_subquery_Key()
        {
//            base.GroupBy_anonymous_subquery_Key();

//            AssertSql(
//                @"SELECT [c].[City], [c].[CustomerID]
//FROM [Customers] AS [c]");
        }

        public override void GroupBy_anonymous_subquery_Element()
        {
//            base.GroupBy_anonymous_subquery_Element();

//            AssertSql(
//                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
//FROM [Customers] AS [c]
//ORDER BY [c].[CustomerID]");
        }

        public override void GroupBy_nested_order_by_enumerable()
        {
            base.GroupBy_nested_order_by_enumerable();

            AssertSql(
                @"SELECT [c0].[Country], [c0].[CustomerID]
FROM [Customers] AS [c0]
ORDER BY [c0].[Country]");
        }

        public override void GroupBy_join_default_if_empty_anonymous()
        {
            base.GroupBy_join_default_if_empty_anonymous();

            AssertSql(
                @"SELECT [order0].[OrderID], [order0].[CustomerID], [order0].[EmployeeID], [order0].[OrderDate], [orderDetail0].[OrderID], [orderDetail0].[ProductID], [orderDetail0].[Discount], [orderDetail0].[Quantity], [orderDetail0].[UnitPrice]
FROM [Orders] AS [order0]
LEFT JOIN [Order Details] AS [orderDetail0] ON [order0].[OrderID] = [orderDetail0].[OrderID]
ORDER BY [order0].[OrderID]");
        }

        public override void GroupBy_simple()
        {
            base.GroupBy_simple();

            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[CustomerID]");
        }

        public override void Distinct_GroupBy()
        {
            base.Distinct_GroupBy();

//            AssertSql(
//                @"SELECT DISTINCT [o].[CustomerID], COUNT(*)
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]
//ORDER BY [o].[CustomerID]");
        }

        public override void GroupBy_Distinct()
        {
            base.GroupBy_Distinct();

//            AssertSql(
//                @"SELECT DISTINCT [o].[CustomerID]
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_key_selector_DateTimeOffset_Property()
        {
            base.GroupBy_with_key_selector_DateTimeOffset_Property();

//            AssertSql(
//                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], DATEPART(month, [o].[OrderDate])
//FROM [Orders] AS [o]
//WHERE [o].[OrderDate] IS NOT NULL
//ORDER BY DATEPART(month, [o].[OrderDate])");
        }

        public override void OrderBy_GroupBy()
        {
            base.OrderBy_GroupBy();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void Select_GroupBy()
        {
            base.Select_GroupBy();

            AssertSql(
                @"SELECT [o].[OrderID] AS [Order], [o].[CustomerID] AS [Customer]
FROM [Orders] AS [o]
ORDER BY [o].[CustomerID]");
        }

        public override void Select_GroupBy_SelectMany()
        {
            base.Select_GroupBy_SelectMany();

            AssertSql(
                @"SELECT [o0].[OrderID] AS [Order], [o0].[CustomerID] AS [Customer]
FROM [Orders] AS [o0]
ORDER BY [o0].[OrderID]");
        }

        public override void GroupBy_with_orderby()
        {
            base.GroupBy_with_orderby();

            AssertSql(
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
ORDER BY [o0].[CustomerID]");
        }

        public override void GroupBy_with_orderby_and_anonymous_projection()
        {
            base.GroupBy_with_orderby_and_anonymous_projection();

            AssertSql(
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
ORDER BY [o0].[CustomerID]");
        }

        public override void GroupBy_with_orderby_take_skip_distinct()
        {
            base.GroupBy_with_orderby_take_skip_distinct();

            AssertSql(
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
ORDER BY [o0].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_entity_with_projection_Average()
        {
            base.GroupBy_with_element_selector_entity_with_projection_Average();

//            AssertSql(
//                @"SELECT AVG(CAST([o].[OrderID] AS float))
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_entity_with_projection_Count()
        {
            base.GroupBy_with_element_selector_entity_with_projection_Count();

//            AssertSql(
//                @"SELECT COUNT(*)
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_entity_with_projection_LongCount()
        {
            base.GroupBy_with_element_selector_entity_with_projection_LongCount();

//            AssertSql(
//                @"SELECT COUNT_BIG(*)
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_entity_with_projection_Max()
        {
            base.GroupBy_with_element_selector_entity_with_projection_Max();

//            AssertSql(
//                @"SELECT MAX([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_entity_with_projection_Min()
        {
            base.GroupBy_with_element_selector_entity_with_projection_Min();

//            AssertSql(
//                @"SELECT MIN([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_entity_with_projection_Sum()
        {
            base.GroupBy_with_element_selector_entity_with_projection_Sum();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_Sum_Where()
        {
            base.GroupBy_Sum_Where();

            AssertSql(
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
ORDER BY [o0].[CustomerID]");
        }

        public override void GroupBy_Sum_Min_Max_Avg()
        {
            base.GroupBy_Sum_Min_Max_Avg();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID]), MIN([o].[OrderID]), MAX([o].[OrderID]), AVG(CAST([o].[OrderID] AS float))
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_result_selector()
        {
            base.GroupBy_with_result_selector();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID]), MIN([o].[OrderID]), MAX([o].[OrderID]), AVG(CAST([o].[OrderID] AS float))
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_property()
        {
            base.GroupBy_with_element_selector_property();

//            AssertSql(
//                @"SELECT [o0].[CustomerID], [o0].[OrderID]
//FROM [Orders] AS [o0]
//ORDER BY [o0].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_property_with_projection_Average()
        {
            base.GroupBy_with_element_selector_property_with_projection_Average();

//            AssertSql(
//                @"SELECT AVG(CAST([o].[OrderID] AS float))
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_property_with_projection_Max()
        {
            base.GroupBy_with_element_selector_property_with_projection_Max();

//            AssertSql(
//                @"SELECT MAX([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_property_with_projection_Min()
        {
            base.GroupBy_with_element_selector_property_with_projection_Min();

//            AssertSql(
//                @"SELECT MIN([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_property_with_projection_Sum()
        {
            base.GroupBy_with_element_selector_property_with_projection_Sum();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_property_with_projection_Sum_Max()
        {
            base.GroupBy_with_element_selector_property_with_projection_Sum_Max();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID]), MAX([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_binary_with_projection_Average()
        {
            base.GroupBy_with_element_selector_binary_with_projection_Average();

//            AssertSql(
//                @"SELECT AVG(CAST([o].[OrderID] * [o].[EmployeeID] AS float))
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_binary_with_projection_Max()
        {
            base.GroupBy_with_element_selector_binary_with_projection_Max();

//            AssertSql(
//                @"SELECT MAX([o].[OrderID] * [o].[EmployeeID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_binary_with_projection_Min()
        {
            base.GroupBy_with_element_selector_binary_with_projection_Min();

//            AssertSql(
//                @"SELECT MIN([o].[OrderID] * [o].[EmployeeID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_element_selector_binary_with_projection_Sum()
        {
            base.GroupBy_with_element_selector_binary_with_projection_Sum();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID] * [o].[EmployeeID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID]");
        }

        public override void GroupBy_with_key_selector_anonymous_multipart()
        {
            base.GroupBy_with_key_selector_anonymous_multipart();

//            AssertSql(
//                @"SELECT SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID], [o].[OrderDate]");
        }

        public override void GroupBy_with_key_selector_anonymous_multipart_with_projection_whole()
        {
            base.GroupBy_with_key_selector_anonymous_multipart_with_projection_whole();

//            AssertSql(
//                @"SELECT [o].[CustomerID], [o].[OrderDate], SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID], [o].[OrderDate]");
        }

        public override void GroupBy_with_key_selector_anonymous_multipart_with_projection_split()
        {
            base.GroupBy_with_key_selector_anonymous_multipart_with_projection_split();

//            AssertSql(
//                @"SELECT [o].[CustomerID], [o].[OrderDate], SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID], [o].[OrderDate]");
        }

        public override void GroupBy_with_key_selector_anonymous_nested_with_projection_whole()
        {
            base.GroupBy_with_key_selector_anonymous_nested_with_projection_whole();

//            AssertSql(
//                @"SELECT [o].[CustomerID], [o].[OrderDate], SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID], [o].[OrderDate]");
        }

        public override void GroupBy_with_key_selector_anonymous_nested_with_projection_split()
        {
            base.GroupBy_with_key_selector_anonymous_nested_with_projection_split();

//            AssertSql(
//                @"SELECT [o].[CustomerID], [o].[OrderDate], SUM([o].[OrderID])
//FROM [Orders] AS [o]
//GROUP BY [o].[CustomerID], [o].[OrderDate]");
        }

        public override void GroupBy_in_subquery_as_left_side_of_Join()
        {
            base.GroupBy_in_subquery_as_left_side_of_Join();

//            AssertSql(
//                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [c].[ContactName]
//FROM (
//    SELECT [o].[CustomerID], MAX([o].[OrderID]) AS [c]
//    FROM [Orders] AS [o]
//    GROUP BY [o].[CustomerID]
//) AS [t]
//INNER JOIN [Customers] AS [c] ON [t].[CustomerID] = [c].[CustomerID]
//INNER JOIN [Orders] AS [o0] ON [t].[c] = [o0].[OrderID]");
        }

        public override void GroupBy_in_subquery_as_right_side_of_Join()
        {
            base.GroupBy_in_subquery_as_right_side_of_Join();

            // In GroupBy_in_subquery_as_left_side_of_Join, the MAX aggregation is
            // for some reason optimized out into the join key selector, while in this
            // query, it is not. Because of this, the extra columns ([t].[CustomerID] and [t].[c])
            // appear because they must be present in order for the shaper to operate correctly.

//            AssertSql(
//                @"SELECT [t].[CustomerID], [t].[c], [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [c].[ContactName]
//FROM [Customers] AS [c]
//INNER JOIN (
//    SELECT [o].[CustomerID], MAX([o].[OrderID]) AS [c]
//    FROM [Orders] AS [o]
//    GROUP BY [o].[CustomerID]
//) AS [t] ON [c].[CustomerID] = [t].[CustomerID]
//INNER JOIN [Orders] AS [o0] ON [t].[c] = [o0].[OrderID]");
        }

        public override void GroupBy_in_subquery_as_right_side_of_Join_aggregate_result_operator_as_key()
        {
            base.GroupBy_in_subquery_as_right_side_of_Join_aggregate_result_operator_as_key();

//            AssertSql(
//                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [c].[ContactName]
//FROM [Customers] AS [c]
//INNER JOIN (
//    SELECT [o].[CustomerID], MAX([o].[OrderID]) AS [c]
//    FROM [Orders] AS [o]
//    GROUP BY [o].[CustomerID]
//) AS [t] ON [c].[CustomerID] = [t].[CustomerID]
//INNER JOIN [Orders] AS [o0] ON [t].[c] = [o0].[OrderID]");
        }

        public override void Join_GroupBy()
        {
            base.Join_GroupBy();

//            AssertSql(
//                @"SELECT [c].[Country], SUM([o].[OrderID])
//FROM [Customers] AS [c]
//INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
//GROUP BY [c].[Country]");
        }

        public override void GroupJoin_GroupBy()
        {
            base.GroupJoin_GroupBy();

            AssertSql(
                @"SELECT [c0].[CustomerID], [c0].[Address], [c0].[City], [c0].[CompanyName], [c0].[ContactName], [c0].[ContactTitle], [c0].[Country], [c0].[Fax], [c0].[Phone], [c0].[PostalCode], [c0].[Region], [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Customers] AS [c0]
LEFT JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
ORDER BY [c0].[CustomerID]");
        }

        public override void GroupJoin_SelectMany_DefaultIfEmpty_GroupBy()
        {
            base.GroupJoin_SelectMany_DefaultIfEmpty_GroupBy();

            AssertSql(
                @"SELECT [c0].[CustomerID], [c0].[Address], [c0].[City], [c0].[CompanyName], [c0].[ContactName], [c0].[ContactTitle], [c0].[Country], [c0].[Fax], [c0].[Phone], [c0].[PostalCode], [c0].[Region], [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Customers] AS [c0]
LEFT JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
ORDER BY [c0].[CustomerID]");
        }

        private void AssertSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

        private void AssertContainsSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected, assertOrder: false);

        protected override void ClearLog()
            => Fixture.TestSqlLoggerFactory.Clear();
    }
}