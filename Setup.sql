USE burgershack252;

-- MySql : MongoDb as Table : Collection

-- CREATE COLLECTION ------------------------------------------
DROP TABLE combos;
DROP TABLE burgers;
DROP TABLE sides;

-- UPDATE burgers SET inspiredby = "Justin" ;

-- NOTE if NOT NULL && UNIQUE the key MUST change?
CREATE TABLE burgers
(
  id INT AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL UNIQUE,
  description VARCHAR(255) NOT NULL,
  inspiredby VARCHAR(255) NOT NULL,
  price DECIMAL(6,2) NOT NULL,

  PRIMARY KEY(id)
);

CREATE TABLE sides
( 
  id INT AUTO_INCREMENT,
  inspiredby VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NULL,
  price DECIMAL(6,2) NOT NULL,

  PRIMARY KEY(id)
);

CREATE TABLE combos
(
  id INT NOT NULL AUTO_INCREMENT,
  price DECIMAL(6,2) DEFAULT 9.00,
  burgerId INT NOT NULL,
  sideId INT NOT NULL,

  PRIMARY KEY (id),

  FOREIGN KEY (burgerId)
      REFERENCES burgers (id)
      ON DELETE CASCADE,
  FOREIGN KEY (sideId)
    REFERENCES sides (id)
    ON DELETE CASCADE
);


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

    -- {
    --     "id": 1,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Justin's Jr Bacon Cheese",
    --     "description": "This bacon cheeseburger is so tasty you'll wish you'd ordered two!",
    --     "price": 5.5
    -- },
    -- {
    --     "id": 2,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Justin's Double Bacon Cheese",
    --     "description": "This bacon cheeseburger is so big you might just have to save half for tomorrow!",
    --     "price": 10.5
    -- },
    -- {
    --     "id": 3,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Justin's Veggie Burger",
    --     "description": "This menu item needs deleted!",
    --     "price": 7.25
    -- }

  -- INSERT INTO sides (name, description, price) VALUES ("Fries","Shoestring",1.99);
  -- INSERT INTO sides (name, description, price) VALUES ("Fries","HomeStyle",2.99);
  -- INSERT INTO sides (name, description, price) VALUES ("Fries","Waffle",3.99);

    --   {
    --     "id": 1,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Fries",
    --     "description": "Shoestring",
    --     "price": 1.99
    -- },
    -- {
    --     "id": 2,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Fries",
    --     "description": "Homestyle",
    --     "price": 2.99
    -- },
    -- {
    --     "id": 3,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Fries",
    --     "description": "Waffle",
    --     "price": 3.99
    -- },
    -- {
    --     "id": 4,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Tots",
    --     "description": "Who wouldn't want a pocket full of tater-tots!?",
    --     "price": 1.75
    -- },
    -- {
    --     "id": 6,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Huckelberries",
    --     "description": "Soon to be out of stock...",
    --     "price": 5.5
    -- },
    -- {
    --     "id": 7,
    --     "inspiredBy": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
    --     "name": "Watermelon",
    --     "description": "Eww",
    --     "price": 1.75
    -- }

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
