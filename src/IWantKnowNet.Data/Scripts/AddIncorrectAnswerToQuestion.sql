CREATE DEFINER=`root`@`localhost` PROCEDURE `AddIncorrectAnswerToQuestion`(
    IN QuestionId nvarchar(255),
    IN UserId nvarchar(255),

	IN TitleIncorrectAnswerEn nvarchar(500),
	IN TitleIncorrectAnswerEs nvarchar(500),
	IN TitleIncorrectAnswerRu nvarchar(500),

	OUT Message nvarchar(1000) 
    )
BEGIN
	DECLARE Id varchar(255);
    DECLARE CategoryId varchar(255);
    DECLARE IncorrectAnswerId nvarchar(255);
    
    SET IncorrectAnswerId = UUID();
    SET Id = UUID();
	SET Message = 'NOT COMPLETED';
    
    START TRANSACTION;
    
    CALL AddIncorrectAnswer (IncorrectAnswerId, TitleCorrectAnswerEn, TitleCorrectAnswerEs, TitleCorrectAnswerRu, UserId);

	CALL AddRelationshipQuestionAndIncorrectAnswer (Id, QuestionId, IncorrectAnswerId);
    
    SET Message = 'DONE';
    
    COMMIT;
END