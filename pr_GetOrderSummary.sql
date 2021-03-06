
CREATE PROCEDURE pr_GetOrderSummary
	@StartDate DateTime,
    @EndDate DateTime,
    @EmployeeID int = NULL,
    @CustomerID nchar(5) = NULL
AS
BEGIN

SELECT MAX(TitleOfCourtesy + ' ' + FirstName + ' ' + LastName) as EmployeeFullName,
      MAX(s.CompanyName) as 'Shipper CompanyName',
      MAX(c.CompanyName) as 'Customer CompanyName',
      COUNT(*) as NumberOfOrders,
      MAX(o.OrderDate) as 'Date',
      SUM(o.Freight) as TotalFreightCost,
      SUM(od.NumberOfDifferentProducts) as NumberOfDifferentProducts,
      SUM(od.TotalOrderValue) as TotalOrderValue
FROM Orders o
      INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID
      INNER JOIN Customers c ON o.CustomerID = c.CustomerID
      INNER JOIN Shippers s on o.ShipperID = s.ShipperID
      JOIN ( SELECT OrderID, 
                   SUM(UnitPrice*Quantity-Discount) as TotalOrderValue,
                   COUNT(DISTINCT ProductID) as NumberOfDifferentProducts
                   FROM OrderDetails GROUP BY OrderID
                  ) od ON o.OrderID = od.OrderID
WHERE OrderDate >= @StartDate
AND OrderDate <= @EndDate
AND o.EmployeeID = ISNULL(@EmployeeID, o.EmployeeID)
AND o.CustomerID = ISNULL(@CustomerID, o.CustomerID)
GROUP BY DATEPART(day, OrderDate), o.EmployeeID, o.CustomerID, o.ShipperID

END
GO
