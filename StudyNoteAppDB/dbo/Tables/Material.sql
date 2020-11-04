--
-- Create Table    : 'Material'   
-- MaterialId      :  
-- PublisheId      :  (references Publisher.PublisheId)
--
CREATE TABLE Material (
    MaterialId     BIGINT IDENTITY(1,1) NOT NULL,
    PublisheId     BIGINT NOT NULL,
[MaterialType] NVARCHAR(50) NULL, 
    CONSTRAINT pk_Material PRIMARY KEY CLUSTERED (MaterialId),
CONSTRAINT fk_Material FOREIGN KEY (PublisheId)
    REFERENCES Publisher (PublisheId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)