--
-- Create Table    : 'TextBite'   
-- TextBiteId      :  
-- MaterialId      :  (references Book.MaterialId)
-- BookId          :  (references Book.BookId)
-- MaterialId1     :  (references Webpage.MaterialId)
-- WebpageId       :  (references Webpage.WebpageId)
--
CREATE TABLE TextBite (
    TextBiteId     BIGINT IDENTITY(1,1) NOT NULL,
    MaterialId     BIGINT NULL,
[MaterialId1] BIGINT NULL, 
    CONSTRAINT pk_TextBite PRIMARY KEY CLUSTERED (TextBiteId),
CONSTRAINT fk_TextBite FOREIGN KEY (MaterialId)
    REFERENCES Book (MaterialId)
    ON UPDATE CASCADE,
CONSTRAINT fk_TextBite2 FOREIGN KEY (MaterialId1)
    REFERENCES Webpage (MaterialId)
    ON UPDATE CASCADE)