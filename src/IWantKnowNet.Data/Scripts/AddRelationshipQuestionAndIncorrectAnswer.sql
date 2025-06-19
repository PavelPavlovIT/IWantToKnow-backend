CREATE DEFINER=`root`@`localhost` PROCEDURE `AddRelationshipQuestionAndIncorrectAnswer`(
	IN Id varchar(255),
	IN QuestionId varchar(255),
	IN IncorrectAnswerId varchar(255)
)
BEGIN
	INSERT INTO QuestionsAndIncorrectAnswers
			   (Id, QuestionId, IncorrectAnswerId)
		 VALUES
			   (Id, QuestionId, IncorrectAnswerId);
END