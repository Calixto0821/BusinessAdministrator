--DDL DOCUMENT (PROCEDURES) DATABASE BUSINESS ADMINISTRATOR
--PROCEDURES
USE BUSINESS_ADMINISTRATOR
--LOGIN
CREATE PROCEDURE checkAdministratorUser
AS
SELECT * FROM USERS WHERE user_type=1
GO

CREATE PROCEDURE User_Login @User varchar(30), @Password varchar(30)
AS
SELECT U.document,(U.first_name+' '+U.last_name) AS 'Full name', E.nickname, E.password
FROM USERS AS U
INNER JOIN EMPLOYEES AS E ON U.document = E.document_user
WHERE
(E.nickname=@User COLLATE SQL_Latin1_General_CP1_CS_AS or 
 U.document=@User COLLATE SQL_Latin1_General_CP1_CS_AS)
 AND E.password= @Password COLLATE SQL_Latin1_General_CP1_CS_AS
GO



--DISPLAY
CREATE PROCEDURE displayDataEmployees 
AS
SELECT
U.id AS 'ID USER',
E.id AS 'ID EMPLOYEES',
(U.first_name +' '+ U.last_name) AS 'FULL NAME',
U.document AS 'DOCUMENT',
U.email AS 'EMAIL',
U.cellphone_number AS 'CELLPHONE NUMBER'
FROM USERS as U
INNER JOIN EMPLOYEES AS E ON U.document = E.document_user
WHERE U.user_type = 3 AND E.status = 1
GO

CREATE PROCEDURE displayDataClients
AS
SELECT
U.id AS 'ID USER',
C.id AS 'ID CLIENT',
(U.first_name +' '+ U.last_name) AS 'FULL NAME',
U.document AS 'DOCUMENT',
U.email AS 'EMAIL',
U.cellphone_number AS 'CELLPHONE NUMBER',
C.balance AS 'SALDO',
C.debt AS 'DEUDA'
FROM USERS AS U
INNER JOIN CLIENTS AS C ON U.document = C.document_user
WHERE U.user_type = 2 AND C.status = 1
GO

CREATE PROCEDURE displayDataDealers
AS
SELECT
D.id AS 'ID',
D.name AS 'NAME',
D.number_cellphone AS 'CELLPHONE',
D.number_phone AS 'PHONE',
D.contact_email AS 'EMAIL',
D.web AS 'WEB',
D.address AS 'ADDRESS'
FROM DEALERS AS D
WHERE D.status = 1
GO

CREATE PROCEDURE displayDataServices
AS
SELECT 
S.id AS 'ID',
S.name AS 'NAME',
S.reference AS 'REFERENCE',
S.barcode AS 'BARCODE',
S.price AS 'PRICE',
S.description AS 'DESCRIPTION'
FROM SERVICES AS S
WHERE S.status = 1
GO

CREATE PROCEDURE displayDataProducts
AS
SELECT
P.id AS 'ID',
P.reference AS 'REFERENCE',
P.barcode AS 'BARCODE',
P.name AS 'NAME',
P.price AS 'PRICE',
P.stock AS 'STOCK',
P.description AS 'DESCRIPTION'
FROM PRODUCTS AS P
WHERE P.status = 1
GO

CREATE PROCEDURE displayDataLines
AS
SELECT
L.id AS 'ID',
L.name AS 'NAME'
FROM LINES AS L
WHERE L.status = 1
GO

CREATE PROCEDURE displayDataBrands
AS
SELECT
B.id AS 'ID',
B.name AS 'NAME'
FROM BRANDS AS B
WHERE B.status = 1
GO

CREATE PROCEDURE getDataClientBalance @UserID INT
AS
SELECT
U.id AS 'ID USER',
C.balance AS 'BALANCE',
C.debt AS 'DEBT'
FROM CLIENTS AS C
INNER JOIN USERS AS U ON U.document = C.document_user
WHERE C.status = 1 AND U.id = @UserID
GO
 

--DELETE

CREATE PROCEDURE deleteClient @Document VARCHAR(15)
AS
UPDATE CLIENTS SET status = 0 WHERE document_user = @Document
GO

CREATE PROCEDURE deleteEmployee @Document VARCHAR(15)
AS
UPDATE EMPLOYEES SET status = 0 WHERE document_user = @Document
GO

CREATE PROCEDURE deleteDealer @ID INT
AS
UPDATE DEALERS SET status = 0 WHERE id = @ID
GO

CREATE PROCEDURE deleteLine @ID INT
AS
UPDATE LINES SET status = 0 WHERE id = @ID
GO

CREATE PROCEDURE deleteBrand @ID INT
AS
UPDATE BRANDS SET status = 0 WHERE id = @ID
GO


CREATE PROCEDURE deleteProduct @ID INT
AS
UPDATE PRODUCTS SET status = 0 WHERE id = @ID
GO



 --DISPLAY DELETE ITEMS

CREATE PROCEDURE displayDataDeletedClients
AS
SELECT
U.id AS 'ID USER',
C.id AS 'ID CLIENT',
(U.first_name +' '+ U.last_name) AS 'FULL NAME',
U.document AS 'DOCUMENT',
U.email AS 'EMAIL',
U.cellphone_number AS 'CELLPHONE NUMBER'
FROM USERS AS U
INNER JOIN CLIENTS AS C ON U.document = C.document_user
WHERE C.status = 0
GO

CREATE PROCEDURE displayDataDeletedEmployees 
AS
SELECT
U.id AS 'ID USER',
E.id AS 'ID EMPLOYEES',
(U.first_name +' '+ U.last_name) AS 'FULL NAME',
U.document AS 'DOCUMENT',
U.email AS 'EMAIL',
U.cellphone_number AS 'CELLPHONE NUMBER'
FROM USERS as U
INNER JOIN EMPLOYEES AS E ON U.document = E.document_user
WHERE E.status = 0
GO
