USE Test

CREATE TABLE Customer (
	CustomerId INT Identity(1,1) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(200) NOT NULL,
	LastName NVARCHAR(200) NOT NULL,
	Contact NVARCHAR(20) NOT NULL,
	Deleted BIT NOT NULL DEFAULT 0
)
