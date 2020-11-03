--
-- Create Table    : 'Records'   
-- NoteId          :  (references Note.NoteId)
-- MaterialId      :  (references Material.MaterialId)
--
CREATE TABLE Records (
    NoteId         BIGINT NOT NULL,
    MaterialId     BIGINT NOT NULL,
CONSTRAINT pk_Records PRIMARY KEY CLUSTERED (NoteId,MaterialId),
CONSTRAINT fk_Records FOREIGN KEY (NoteId)
    REFERENCES Note (NoteId)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
CONSTRAINT fk_Records2 FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE CASCADE
    ON UPDATE CASCADE)