USE BUSINESS_ADMINISTRATOR

--SELECT CLIENTS WITH INFORMATION
SELECT
U.id AS 'ID USER',
C.id AS 'ID CLIENT',
(U.first_name + U.last_name) AS 'FULL NAME',
U.document AS 'DOCUMENT',
U.email AS 'EMAIL',
U.cellphone_number AS 'CELLPHONE NUMBER'
FROM USERS AS U
INNER JOIN CLIENTS AS C ON U.document = C.document_user
EXEC displayDataClients

--SELECT EMPLOYEES WITH INFORMATION
SELECT
U.id AS 'ID USER',
E.id AS 'ID EMPLOYEES',
(U.first_name + U.last_name) AS 'FULL NAME',
U.document AS 'DOCUMENT',
U.email AS 'EMAIL',
U.cellphone_number AS 'CELLPHONE NUMBER'
FROM USERS as U
INNER JOIN EMPLOYEES AS E ON U.document = E.document_user --Une los registros de las dos tablas que tiene valores en iguales
EXEC displayDataEmployees

--SELECT USERS WITH ALL DATA
SELECT * 
FROM USERS AS U
INNER JOIN CLIENTS AS C ON U.document = C.document_user

SELECT * 
FROM USERS AS U
INNER JOIN EMPLOYEES AS E ON U.document = E.document_user

--CODE TO LOGIN
EXEC User_Login @User  = 'Admin', @Password = 'administrator';


--SELECT ALL TABLES
USE BUSINESS_ADMINISTRATOR
SELECT * FROM TOOLS
SELECT * FROM USERS
SELECT * FROM CLIENTS
SELECT * FROM EMPLOYEES
SELECT * FROM DEALERS
SELECT * FROM BRANDS
SELECT * FROM LINES
SELECT * FROM PRODUCTS
SELECT * FROM SERVICES
SELECT * FROM SESIONS
SELECT * FROM PURCHASES
SELECT * FROM DETAILS_PURCHASE
SELECT * FROM SALES
SELECT * FROM DETAILS_PRODUCT_SALES
SELECT * FROM DETAILS_SERVICE_SALES

--DROP

