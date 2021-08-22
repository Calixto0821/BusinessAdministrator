--DML BATABASE BUSINESS ADMINISTRATOR
--TEST DATA (TABLE PRODUCTS)
USE BUSINESS_ADMINISTRATOR

INSERT INTO PRODUCTS ([reference],[name],[barcode],[price],[stock],[minimum_stock],[description],[id_dealer],[id_brand],[id_line]) VALUES (@Reference,@Name,@Barcode,@Price,@Stock,@MinimumStock,@Description,@DealerID,@BrandID,@LineID)
UPDATE PRODUCTS SET [reference]=@Reference,[name]=@Name,[barcode]=@Barcode,[price]=@Price,[stock]=@Stock,[minimum_stock]=@MinimumStock,[description]=@Description,[id_dealer]=@DealerID,[id_brand]=@BrandID,[id_line]=@LineID