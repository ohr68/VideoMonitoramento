CREATE PROCEDURE usp_Server_GetAll
AS 
SET NOCOUNT ON 
SELECT S.Id, S.Name, S.IP, S.Port
FROM Server S

GO

CREATE PROCEDURE usp_Server_GetById
@sid UNIQUEIDENTIFIER
AS 
SET NOCOUNT ON
SELECT S.Id, S.Name, S.IP, S.Port
FROM Server S
WHERE S.Id = @sid

GO

CREATE PROCEDURE usp_Video_GetAllServerVideos
@serverId UNIQUEIDENTIFIER
AS 
SELECT V.Id, V.Description, V.FileData, V.SizeInBytes, V.RegistrationDate, V.ServerId
FROM Video V
INNER JOIN Server S ON V.ServerId = S.Id
WHERE V.ServerId = @serverId

GO

CREATE PROCEDURE usp_Video_GetById
@sid UNIQUEIDENTIFIER
AS 
SELECT V.Id, V.Description, V.FileData, V.SizeInBytes, V.RegistrationDate, V.ServerId
FROM Video V
WHERE V.Id = @sid

GO