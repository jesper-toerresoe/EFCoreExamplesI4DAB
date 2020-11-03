--
-- Create Table    : 'Video'   
-- MaterialId      :  (references Material.MaterialId)
-- VideoId         :  
--
CREATE TABLE Video (
    MaterialId     BIGINT NOT NULL,
    VideoId        BIGINT IDENTITY(1,1) NOT NULL,
CONSTRAINT pk_Video PRIMARY KEY CLUSTERED (MaterialId,VideoId),
CONSTRAINT fk_Video FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)