CREATE DEFINER=`admin`@`%` PROCEDURE `GetAnswers`(
	IN TestId  varchar(255),
    IN QuestionsId varchar(255),
    IN CategoryId varchar(255),
	IN CountAnswers INT,
	IN NumberQuestion INT)
BEGIN
	DECLARE Count_incorrect_answers INT;
	START TRANSACTION;

	CREATE TEMPORARY TABLE  IF NOT EXISTS ListQuestionIds(
		Id varchar(255)
	);
        
	CREATE TEMPORARY TABLE IF NOT EXISTS Result(
		Id varchar(255),
		QuestionId varchar(255),
		TitleEn varchar(500),
		TitleEs varchar(500),
		TitleRu varchar(500),
		CreaterId varchar(255),
		ApproverId varchar(255),
		Rand_number decimal
	);
    
	CREATE TEMPORARY TABLE  IF NOT EXISTS CorrectAnswerListRecord(
		Id varchar(255),
		QuestionId varchar(255),
		TitleEn varchar(500),
		TitleEs varchar(500),
		TitleRu varchar(500),
		CreaterId varchar(255),
		ApproverId varchar(255),
		Rand_number decimal
	);

	CREATE TEMPORARY TABLE  IF NOT EXISTS IncorrectAnswerListRecord(
		Id varchar(255),
		QuestionId varchar(255),
		TitleEn varchar(500),
		TitleEs varchar(500),
		TitleRu varchar(500),
		CreaterId varchar(255),
		ApproverId varchar(255),
		Rand_number decimal
	);

	INSERT INTO CorrectAnswerListRecord
		SELECT 
			t1.Id, 
			t2.QuestionId, 
			TitleEn,
			TitleEs,
			TitleRu,
			CreaterId,
			ApproverId,
			rand()
			FROM CorrectAnswers AS t1
			INNER JOIN QuestionsAndCorrectAnswers AS t2 ON t1.Id = t2.CorrectAnswerId
		WHERE t2.QuestionId = QuestionsId;

    
	INSERT INTO ListQuestionIds
		SELECT t1.Id FROM Questions as t1
			INNER JOIN CategoryAndQuestions AS t2 ON t1.Id = t2.QuestionId
		WHERE t2.CategoryId = CategoryId;

	INSERT INTO IncorrectAnswerListRecord
		SELECT 
			t1.Id, 
			t2.QuestionId, 
			TitleEn,
			TitleEs,
			TitleRu,
			CreaterId,
			ApproverId,
			rand()
			FROM IncorrectAnswers AS t1
			INNER JOIN QuestionsAndIncorrectAnswers AS t2 ON t1.Id = t2.IncorrectAnswerId
		WHERE t2.QuestionId = QuestionsId;

	INSERT INTO Result 
		SELECT * FROM CorrectAnswerListRecord ORDER BY Rand_number LIMIT 3;
        
	IF !((TestId='') OR (TestId IS NULL))  THEN 
		BEGIN
			INSERT INTO TestCorrectAnswers 
				SELECT UUID(), TestId, QuestionId, NumberQuestion, Id FROM Result;	
        END;
    End IF;
    
	SELECT COUNT(*) FROM Result INTO @RESULT_COUNT;
    SELECT COUNT(*) FROM IncorrectAnswerListRecord INTO @INCORRECT_COUNT;
    
	IF (@INCORRECT_COUNT > 0) THEN 
		BEGIN
			SET Count_incorrect_answers = CountAnswers - @RESULT_COUNT;
            
			INSERT INTO Result
				SELECT * FROM IncorrectAnswerListRecord ORDER BY Rand_number LIMIT Count_incorrect_answers;
		END;
	END IF;

	SELECT COUNT(*) FROM Result INTO @RESULT_COUNT2;
    
	IF (@RESULT_COUNT2 < CountAnswers) THEN 
		BEGIN
			DELETE FROM IncorrectAnswerListRecord;
            
            INSERT INTO IncorrectAnswerListRecord
			SELECT 
				t1.Id, 
				t2.QuestionId, 
				TitleEn,
				TitleEs,
				TitleRu,
				CreaterId,
				ApproverId,
				uuid()
				FROM CorrectAnswers AS t1
				INNER JOIN QuestionsAndCorrectAnswers AS t2 ON t1.Id = t2.CorrectAnswerId
			WHERE t2.QuestionId <> QuestionsId and t2.QuestionId in (select Id from ListQuestionIds);
            
            SET Count_incorrect_answers = CountAnswers - @RESULT_COUNT2;
            
			INSERT INTO Result
				SELECT Id, QuestionId, TitleEn, TitleEs, TitleRu, CreaterId, ApproverId, Rand_number FROM IncorrectAnswerListRecord ORDER BY Rand_number LIMIT Count_incorrect_answers;

		END;
	END IF;
    
	SELECT Id, QuestionId, TitleEn, TitleEs, TitleRu, CreaterId, ApproverId  FROM Result ORDER BY Rand_number;
    
    DELETE FROM Result;
    DELETE FROM ListQuestionIds;
    DELETE FROM CorrectAnswerListRecord;
	DELETE FROM IncorrectAnswerListRecord;
    
	COMMIT;
END