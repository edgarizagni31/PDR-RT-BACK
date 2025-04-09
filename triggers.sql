CREATE TRIGGER Salary_Update
ON Employees
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        DECLARE @EmployeeId INT, 
                @OldSalary DECIMAL(10, 2),
                @NewSalary DECIMAL(10, 2);

        SELECT @EmployeeId = Id, @NewSalary = Salary FROM inserted;
        SELECT @OldSalary = Salary FROM deleted;

        INSERT INTO SalaryHistory (EmployeeId, OldSalary, NewSalary, UpdatedAt)
        VALUES (@EmployeeId, @OldSalary, @NewSalary, GETDATE());
    END
END;

GO;

CREATE TRIGGER Insert_Employee
ON Employees
AFTER INSERT
AS
BEGIN
    DECLARE @Action VARCHAR(50), @OldValue NVARCHAR(MAX), @NewValue NVARCHAR(MAX);

    SET @Action = 'INSERT';

    SET @NewValue = (SELECT * FROM inserted FOR JSON PATH);

    INSERT INTO Audit (Action, TableName, OldValue, NewValue, Timestamp)
    VALUES (@Action, 'Employees', NULL, @NewValue, GETDATE());
END;


GO;

CREATE TRIGGER Update_Employee
ON Employees
AFTER UPDATE
AS
BEGIN
    DECLARE @Action VARCHAR(50), @OldValue NVARCHAR(MAX), @NewValue NVARCHAR(MAX);

    SET @Action = 'UPDATE';

    SET @OldValue = (SELECT * FROM deleted FOR JSON PATH);
    SET @NewValue = (SELECT * FROM inserted FOR JSON PATH);

    INSERT INTO Audit (Action, TableName, OldValue, NewValue, Timestamp)
    VALUES (@Action, 'Employees', @OldValue, @NewValue, GETDATE());
END;

SELECT * FROM Audit;

GO;

CREATE TRIGGER Delete_Employee
ON Employees
AFTER DELETE
AS
BEGIN
    DECLARE @Action VARCHAR(50), @OldValue NVARCHAR(MAX), @NewValue NVARCHAR(MAX);

    SET @Action = 'DELETE';

  
    SET @OldValue = (SELECT * FROM deleted FOR JSON PATH);
    SET @NewValue = NULL;  

    INSERT INTO Audit (Action, TableName, OldValue, NewValue, Timestamp)
    VALUES (@Action, 'Employees', @OldValue, @NewValue, GETDATE());
END;
