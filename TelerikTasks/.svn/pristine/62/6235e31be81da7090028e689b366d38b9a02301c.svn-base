SELECT e.LastName EmpLastName,
       m.EmployeeID MgrID, m.LastName MgrLastName
FROM Employees e LEFT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID
