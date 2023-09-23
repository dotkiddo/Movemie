SET IDENTITY_INSERT Categories ON

INSERT INTO Categories (Id, Name) VALUES 
(1, 'Action'),
(2, 'Animation'),
(3, 'Comedy'),
(4, 'Drama'),
(5, 'Fantasy'),
(6, 'Mystery'),
(7, 'Science Fiction');

SET IDENTITY_INSERT Categories OFF

-------------------------------------------------

SET IDENTITY_INSERT Movies ON


INSERT INTO Movies (Id, Name, CategoryId, Rating) VALUES
(1, 'James Bond Quantum of Solace', 1, 4),
(2, 'Inside Out', 2, 4),
(3, 'Jumanji', 3, 4),
(4, 'Atonement', 4, 5),
(5, 'Harry Potter and the Philosopher''s Stone', 5, 5),
(6, 'Murder on the Nile', 6, 3),
(7, 'Edge of Tomorrow', 7, 4);

SET IDENTITY_INSERT Movies OFF
