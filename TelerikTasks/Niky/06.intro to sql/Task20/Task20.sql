SELECT e.*, m.FirstName as ManagerName
FROM Employees e, Employees m 
WHERE e.ManagerID = m.EmployeeID
