USE IMDB;

--Stored Procedures--
--Q1. Add Movie Procedure
CREATE PROCEDURE usp_AddMovie @Name VARCHAR(20)
	,@YearOfRelease INT
	,@Plot VARCHAR(200)
	,@ProducerId INT
	,@Poster VARCHAR(2000)
	,@CreatedAt DATE
	,@UpdatedAt DATE
	,@Language VARCHAR(20)
	,@Profit INT
	,@ActorId VARCHAR(max)
	,@GenerId VARCHAR(max)
AS
BEGIN
	INSERT INTO Foundation.Movies
	VALUES (
		@Name
		,@YearOfRelease
		,@Plot
		,@ProducerId
		,@Poster
		,@CreatedAt
		,@UpdatedAt
		,@Language
		,@Profit
		)

	SELECT SCOPE_IDENTITY()

	INSERT INTO Foundation.MoviesActors (
		MovieId
		,ActorId
		)
	SELECT (
			SELECT TOP 1 ID
			FROM Foundation.Movies
			WHERE Name = @Name
			)
		,Value
	FROM string_split(@ActorId, ',')

	INSERT INTO Foundation.GenresMovies (
		MovieID
		,GenreId
		)
	SELECT (
			SELECT TOP 1 ID
			FROM Foundation.Movies
			WHERE Name = @Name
			)
		,Value
	FROM string_split(@GenerId, ',')
END;

--execute procedure
usp_AddMovie 'Doctor'
	,'2021'
	,'its and amazing movie in hindi'
	,1
	,'https://www.themoviedb.org/t/p/w220_and_h330_face/neo50PMS8QZhl4VdzXAF1Cz3sPz.jpg'
	,'2023-02-13 14:59:16.017'
	,'2023-02-13 14:59:16.017'
	,'hindi'
	,2800000
	,'2,5'

--Q2. SP for delete the movie
CREATE PROC usp_DeleteMovie @MovieId INT
AS
BEGIN
	DELETE Foundation.MoviesActors
	WHERE MovieId = @MovieId

	DELETE Foundation.GenresMovies
	WHERE MovieId = @MovieId

	DELETE Foundation.Movies
	WHERE ID = @MovieId
END
	--execute procedure
	spDeleteMovie 3

--Q3. SP to delete producer
CREATE PROC usp_DeleteProducer @ProducerId INT
AS
BEGIN
	DELETE Foundation.MoviesActors
	WHERE MovieId = (
			SELECT ID
			FROM Foundation.Movies
			WHERE MovieID = (select ID from Foundation.Movies where ProducerId = @ProducerId)
			)

	DELETE Foundation.Movies
	WHERE ProducerId = @ProducerId

	DELETE Foundation.Producers
	WHERE ID = @ProducerId
END
	--execute procedure
	spDeleteProducer 2

--Q4. SP for delete the Actor
CREATE PROC usp_DeleteActor @ActorId INT
AS
BEGIN
	DELETE Foundation.MoviesActors
	WHERE ActorId = @ActorId

	DELETE Foundation.Actors
	WHERE ID = @ActorId
END
	--execute procedure
	spDeleteActor 3