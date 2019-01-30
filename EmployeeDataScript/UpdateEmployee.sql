CREATE PROCEDURE UpdateEmployee          
(          
   @EmpId INTEGER ,        
   @Name VARCHAR(20),         
   @City VARCHAR(20),        
   @Department VARCHAR(20),        
   @Gender VARCHAR(6)        
)          
AS         
BEGIN          
   UPDATE Employee           
   SET Name=@Name,          
   City=@City,          
   Department=@Department,        
   Gender=@Gender          
   WHERE EmployeeId=@EmpId          
END

