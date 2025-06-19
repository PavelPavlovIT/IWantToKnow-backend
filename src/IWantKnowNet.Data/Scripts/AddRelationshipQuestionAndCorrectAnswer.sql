CREATE DEFINER=`root`@`localhost` PROCEDURE `AddRelationshipQuestionAndCorrectAnswer`(
	IN Id varchar(255),
	IN QuestionId varchar(255),
	IN CorrectAnswerId varchar(255)
)
BEGIN
	INSERT INTO QuestionsAndCorrectAnswers
			   (Id, QuestionId, CorrectAnswerId)
		 VALUES
			   (Id, QuestionId, CorrectAnswerId);
END