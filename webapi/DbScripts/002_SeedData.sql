SET IDENTITY_INSERT Movies ON

INSERT INTO Movies (Id, Name, Category, Rating) VALUES
(1, 'James Bond Quantum of Solace', 'Action', 4),
(2, 'Inside Out', 'Animation', 4),
(3, 'Jumanji', 'Comedy', 4),
(4, 'Atonement', 'Drama', 5),
(5, 'Harry Potter and the Philosopher''s Stone', 'Fantasy', 5),
(6, 'Murder on the Nile', 'Mystery', 3),
(7, 'Edge of Tomorrow', 'Science Fiction', 4);

SET IDENTITY_INSERT Movies OFF
