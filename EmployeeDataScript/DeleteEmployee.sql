CREATE PROCEDURE  DeleteEmployee         
(          
   @EmpId int          
)          
AS         
BEGIN             
   DELETE FROM Employee WHERE EmployeeId=@EmpId          
END



