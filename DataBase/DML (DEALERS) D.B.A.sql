--DML BATABASE BUSINESS ADMINISTRATOR
--TEST DATA (TABLE DEALERS)
USE BUSINESS_ADMINISTRATOR

INSERT INTO DEALERS([name],[number_phone],[number_cellphone],[address],[web],[contact_email]) VALUES (@Name, @Phone, @Cellphone, @Address, @Web, @Email);
UPDATE DEALERS SET [name]=@Name,[number_phone]=@Phone,[number_cellphone]=@Cellphone,[address]=@Address,[contect_email]=@Email WHERE [id]=@dealerID;