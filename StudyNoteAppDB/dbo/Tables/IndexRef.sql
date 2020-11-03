--
-- Create Table    : 'IndexRef'   
-- IndexRefId      :  
-- MaterialId      :  (references Material.MaterialId)
--
CREATE TABLE IndexRef (
    IndexRefId     BIGINT IDENTITY(1,1) NOT NULL,
    MaterialId     BIGINT NOT NULL,
CONSTRAINT pk_IndexRef PRIMARY KEY CLUSTERED (IndexRefId),
CONSTRAINT fk_IndexRef FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)