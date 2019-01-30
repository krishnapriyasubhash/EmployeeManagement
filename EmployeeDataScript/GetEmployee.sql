CREATE PROCEDURE GetEmployee    
(
 @EmpId INTEGER   
)
AS         
BEGIN      
    SELECT *      
    FROM Employee   
    WHERE EmployeeId= @EmpId
END
