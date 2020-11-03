--
-- Create Table    : 'Webpage'   
-- MaterialId      :  (references Material.MaterialId)
-- WebpageId       :  
--
CREATE TABLE Webpage (
    MaterialId     BIGINT NOT NULL,
    CONSTRAINT pk_Webpage PRIMARY KEY CLUSTERED (MaterialId),
CONSTRAINT fk_Webpage FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)