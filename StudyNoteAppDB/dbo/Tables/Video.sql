--
-- Create Table    : 'Video'   
-- MaterialId      :  (references Material.MaterialId)
-- VideoId         :  
--
CREATE TABLE Video (
    MaterialId     BIGINT NOT NULL,
CONSTRAINT pk_Video PRIMARY KEY CLUSTERED (MaterialId),
CONSTRAINT fk_Video FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)