--
-- Create Table    : 'HasA'   
-- CategoryId      :  (references Category.CategoryId)
-- MaterialId      :  (references Material.MaterialId)
--
CREATE TABLE HasA (
    CategoryId     BIGINT NOT NULL,
    MaterialId     BIGINT NOT NULL,
CONSTRAINT pk_HasA PRIMARY KEY CLUSTERED (CategoryId,MaterialId),
CONSTRAINT fk_HasA FOREIGN KEY (CategoryId)
    REFERENCES Category (CategoryId)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_HasA2 FOREIGN KEY (MaterialId)
    REFERENCES Material (MaterialId)
    ON DELETE CASCADE
    ON UPDATE CASCADE)