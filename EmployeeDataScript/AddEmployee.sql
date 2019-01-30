CREATE PROCEDURE AddEmployee         
(        
    @Name VARCHAR(20),         
    @City VARCHAR(20),        
    @Department VARCHAR(20),        
    @Gender VARCHAR(6)        
)        
AS         
BEGIN         
    INSERT INTO Employee (Name,City,Department, Gender)         
    VALUES (@Name,@City,@Department, @Gender)         
END
