--
-- Create Table    : 'Webpage'   
-- MaterialId      :  (references Material.MaterialId)
-- WebpageId       :  
--
CREATE TABLE Webpage (
    MaterialId     BIGINT NOT NULL,
    [WebpageId] BIGINT NOT NULL, 
    CONSTRAINT pk_Webpage PRIMARY KEY CLUSTERED (MaterialId,WebpageId),
CONSTRAINT fk_Webpage FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)