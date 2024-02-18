 --Create the Movies table
 CREATE TABLE Movies (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    ReleaseDate DATE,
    MovieName NVARCHAR(255),
    Genre NVARCHAR(100),
    Stars INT,
    Comments NVARCHAR(MAX)
);

select * from Master.dbo.Movies;
-- Insert data for Action genre
INSERT INTO Movies (ReleaseDate, MovieName, Genre, Stars, Comments)
VALUES 
    ('2023-03-15', 'The Avengers', 'Action', 4, 'Exciting action'),
    ('2022-06-20', 'Mission Impossible', 'Action', 4, 'Tom Cruise rocks'),
    ('2022-08-10', 'John Wick', 'Action', 4, 'Intense fights');

-- Insert data for Romantic genre
INSERT INTO Movies (ReleaseDate, MovieName, Genre, Stars, Comments)
VALUES 
    ('2022-02-14', 'The Notebook', 'Romantic', 5, 'Touching love story'),
    ('2023-09-05', 'La La Land', 'Romantic', 4, 'Beautiful cinematography'),
    ('2022-11-20', 'Pride and Prejudice', 'Romantic', 4, 'Classic adaptation');

-- Insert data for Adult genre
INSERT INTO Movies (ReleaseDate, MovieName, Genre, Stars, Comments)
VALUES 
    ('2022-04-01', 'Fifty Shades of Grey', 'Adult', 3, 'Controversial, steamy scenes'),
    ('2022-07-30', 'Basic Instinct', 'Adult', 4, 'Thrilling erotic thriller'),
    ('2023-01-10', 'Eyes Wide Shut', 'Adult', 4, 'Intriguing psychological drama');

-- Insert data for Kids genre
INSERT INTO Movies (ReleaseDate, MovieName, Genre, Stars, Comments)
VALUES 
    ('2022-12-25', 'Finding Nemo', 'Kids', 5, 'Heartwarming animation'),
    ('2023-06-15', 'Toy Story', 'Kids', 5, 'Classic Pixar adventure'),
    ('2023-03-10', 'The Lion King', 'Kids', 5, 'Disney''s masterpiece');

-- Insert data for Horror genre
INSERT INTO Movies (ReleaseDate, MovieName, Genre, Stars, Comments)
VALUES 
    ('2022-10-31', 'The Conjuring', 'Horror', 4, 'Scary and suspenseful'),
    ('2023-08-15', 'Hereditary', 'Horror', 4, 'Disturbing psychological horror'),
    ('2022-09-20', 'Get Out', 'Horror', 4, 'Unique and chilling');
