SELECT e.FirstName, a.AddressText, m.FirstName as ManagerName
FROM Employees e, Employees m, Addresses a 
WHERE e.ManagerID = m.EmployeeID and e.AddressID = a.AddressID
