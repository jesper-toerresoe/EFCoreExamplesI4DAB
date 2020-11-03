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
    BookId         BIGINT NULL,
    MaterialId1    BIGINT NULL,
    WebpageId      BIGINT NULL,
CONSTRAINT pk_TextBite PRIMARY KEY CLUSTERED (TextBiteId),
CONSTRAINT fk_TextBite FOREIGN KEY (MaterialId,BookId)
    REFERENCES Book (MaterialId,BookId)
    ON UPDATE CASCADE,
CONSTRAINT fk_TextBite2 FOREIGN KEY (MaterialId1,WebpageId)
    REFERENCES Webpage (MaterialId,WebpageId)
    ON UPDATE CASCADE)