--
-- Create Table    : 'Category'   
-- CategoryId      :  
-- TypeOfCategory  :  
-- CatName         :  
-- Describtion     :  
--
CREATE TABLE Category (
    CategoryId     BIGINT IDENTITY(1,1) NOT NULL,
    TypeOfCategory NVARCHAR(50) NOT NULL,
    CatName        NVARCHAR(100) NOT NULL,
    Describtion    NVARCHAR(500) NOT NULL,
CONSTRAINT pk_Category PRIMARY KEY CLUSTERED (CategoryId))