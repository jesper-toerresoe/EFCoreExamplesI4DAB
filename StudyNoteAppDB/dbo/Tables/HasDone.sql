--
-- Create Table    : 'HasDone'   
-- NoteId          :  (references Author.NoteId)
-- MaterialId      :  (references Material.MaterialId)
--
CREATE TABLE HasDone (
    NoteId         BIGINT NOT NULL,
    MaterialId     BIGINT NOT NULL,
CONSTRAINT pk_HasDone PRIMARY KEY CLUSTERED (NoteId,MaterialId),
CONSTRAINT fk_HasDone FOREIGN KEY (NoteId)
    REFERENCES Author (NoteId)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_HasDone2 FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)