﻿

CREATE TABLE [dbo].[User]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
	UserCode VARCHAR(10), 
	UserName VARCHAR(50),
	PASSWORD VARCHAR(250)
)
GO
