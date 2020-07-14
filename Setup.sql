USE burgershack252;

-- MySql : MongoDb as Table : Collection

-- CREATE COLLECTION ------------------------------------------
-- CREATE TABLE burgers
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL(6,2) NOT NULL,

--   PRIMARY KEY(id)
-- );

-- CREATE TABLE sides
-- ( 
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NULL,
--   price DECIMAL(6,2) NOT NULL,

--   PRIMARY KEY(id)
-- );
-- DROP TABLE sides;

-- CREATE TABLE combos
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   price DECIMAL(6,2) DEFAULT 9.00,
--   burgerId INT NOT NULL,
--   sideId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (burgerId)
--       REFERENCES burgers (id)
--       ON DELETE CASCADE,
--   FOREIGN KEY (sideId)
--     REFERENCES sides (id)
--     ON DELETE CASCADE
-- );
-- DROP TABLE combos;


-- GET ALL ---------------------------------------------------------
-- SELECT * FROM burgers;
-- SELECT * FROM sides;
-- SELECT * FROM combos;

-- GET BY ID
-- SELECT * FROM burgers WHERE id = 1;
-- SELECT * FROM burgers WHERE id = 1;
-- SELECT * FROM combos WHERE id = 1;


-- CREATE ----------------------------------------------------------
-- INSERT INTO  burgers 
-- (name, price, description)
-- VALUES
-- ("Aloha Zach", 7.99, "Taste of the Islands");
-- ("BBQ Brittany", 7.98, "BBQ Sauce and Onion Rings");
-- ("Mark Deluxe", 8.98, "Only the freshest .. long pork");

  -- INSERT INTO sides (name, description, price) VALUES ("Fries","Shoestring",1.99);
  -- INSERT INTO sides (name, description, price) VALUES ("Fries","HomeStyle",2.99);
  -- INSERT INTO sides (name, description, price) VALUES ("Fries","Waffle",3.99);

  -- INSERT INTO combos (burgerId, sideId, price) VALUES (1,1,6.00);
  -- INSERT INTO combos (burgerId, sideId, price) VALUES (1,2,7.00);
  -- INSERT INTO combos (burgerId, sideId, price) VALUES (4,1,8.00);
  -- INSERT INTO combos (burgerId, sideId, price) VALUES (5,3,9.00);

-- EDIT ------------------------------------------------------------
-- UPDATE burgers 
-- SET 
--   description = "Its extra Cheesy!!!",
--   price = 5.99
-- WHERE id = 4;

-- DELETE
-- DELETE FROM burgers WHERE id = 4;

-- DANGER ZONE
-- DELETE FROM burgers; -- DELETES ALL DATA IN THE TABLE
-- DROP TABLE burgers; -- DESTROYS THE WHOLE TABLE
-- DROP DATABASE burgershack713; DESTROYS WHOLE DATABASE
