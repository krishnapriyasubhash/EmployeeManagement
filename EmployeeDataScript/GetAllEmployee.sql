
CREATE PROCEDURE GetAllEmployees      
AS         
BEGIN      
    SELECT *      
    FROM Employee   
    ORDER BY EmployeeId 
END
