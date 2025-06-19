CREATE DEFINER=`root`@`localhost` PROCEDURE `AddCorrectAnswerToQuestion`(
    IN QuestionId nvarchar(255),
    IN UserId nvarchar(255),

	IN TitleCorrectAnswerEn nvarchar(500),
	IN TitleCorrectAnswerEs nvarchar(500),
	IN TitleCorrectAnswerRu nvarchar(500),

	OUT Message nvarchar(1000) 
    )
BEGIN
	DECLARE Id varchar(255);
    DECLARE CategoryId varchar(255);
    DECLARE CorrectAnswerId nvarchar(255);
    
    SET CorrectAnswerId = UUID();
    SET Id = UUID();
	SET Message = 'NOT COMPLETED';
    
    START TRANSACTION;
    
    CALL AddCorrectAnswer (CorrectAnswerId, TitleCorrectAnswerEn, TitleCorrectAnswerEs, TitleCorrectAnswerRu, UserId);

	CALL AddRelationshipQuestionAndCorrectAnswer (Id, QuestionId, CorrectAnswerId);
    
    SET Message = 'DONE';
    
    COMMIT;
END