--
-- Create Table    : 'Book'   
-- MaterialId      :  (references Material.MaterialId)
-- BookId          :  
--
CREATE TABLE Book (
    MaterialId     BIGINT NOT NULL,
CONSTRAINT pk_Book PRIMARY KEY CLUSTERED (MaterialId),
CONSTRAINT fk_Book FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)