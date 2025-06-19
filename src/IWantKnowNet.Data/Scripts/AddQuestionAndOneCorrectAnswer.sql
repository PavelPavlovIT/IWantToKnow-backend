CREATE DEFINER=`admin`@`%` PROCEDURE `AddQuestionAndOneCorrectAnswer`(
	IN KeyS3 varchar(50),
	IN ExpiredSignedUrlS3 datetime,
	IN SignedUrlS3 varchar(1000),

	IN TitleEn varchar(500),
	IN TitleEs varchar(500),
	IN TitleRu varchar(500),
    IN ProofUrlEn varchar(1000),
	IN ProofUrlEs varchar(1000),
	IN ProofUrlRu varchar(1000),
    IN CategoryId varchar(255),
    IN UserId varchar(255),

	IN TitleCorrectAnswerEn nvarchar(500),
	IN TitleCorrectAnswerEs nvarchar(500),
	IN TitleCorrectAnswerRu nvarchar(500),

	INOUT Message nvarchar(1000) 
)
BEGIN
    
    SET @Id = 'empty';
    SET @QuestionId = UUID();
    SET @ExistQuestionId = 'empty';
    SET @ExistCorrectAnswerId = 'empty';
    SET @TextMessage = 'Not completed';
    
    START TRANSACTION;
    
    SET @TextMessage = 'Completed';
    
	SELECT t1.Id FROM Questions AS t1 
		WHERE  t1.TitleEn=TitleEn OR t1.TitleEs=TitleEs OR t1.TitleRu=TitleRu INTO @ExistQuestionId;
    
	IF @ExistQuestionId='empty' THEN 
		BEGIN
			INSERT INTO Questions(Id, TitleEn, TitleEs, TitleRu, ProofUrlEn, ProofUrlEs, ProofUrlRu, CreaterId, KeyS3, ExpiredSignedUrlS3, SignedUrlS3)
			VALUES (@QuestionId, TitleEn, TitleEs, TitleRu, ProofUrlEn, ProofUrlEs, ProofUrlRu, UserId, KeyS3, ExpiredSignedUrlS3, SignedUrlS3);                
                
			INSERT INTO CategoryAndQuestions (Id, CategoryId, QuestionId)
			VALUES (uuid(), CategoryId, @QuestionId);
        END;
    ELSE 
		BEGIN
			SET @QuestionId = @ExistQuestionId;
			SELECT t1.Id FROM CategoryAndQuestions AS t1 
				WHERE  t1.CategoryId=CategoryId AND t1.QuestionId=@QuestionId INTO @Id;
                
			IF @Id='empty' THEN 
				BEGIN
           			INSERT INTO CategoryAndQuestions (Id, CategoryId, QuestionId)
					VALUES (uuid(), CategoryId, @QuestionId);
				END;
			ELSE
				BEGIN
					SET @TextMessage = 'CategoryAndQuestions found for CategoryId='+ CategoryId + ' QuestionId=' + @QuestionId;
                END;
			END IF;
		END;
    END IF;
    
    SELECT t1.Id FROM CorrectAnswers t1 
		WHERE  t1.TitleEn=TitleCorrectAnswerEn OR t1.TitleEs=TitleCorrectAnswerEs OR t1.TitleRu=TitleCorrectAnswerRu INTO @ExistCorrectAnswerId;
    
    IF @ExistCorrectAnswerId ='empty' THEN 
		BEGIN
			SET @CorrectAnswerId = UUID();
            
			INSERT INTO CorrectAnswers (Id, TitleEn, TitleEs, TitleRu, CreaterId)
			VALUES (@CorrectAnswerId, TitleCorrectAnswerEn, TitleCorrectAnswerEs, TitleCorrectAnswerRu, UserId);

			INSERT INTO QuestionsAndCorrectAnswers (Id, QuestionId, CorrectAnswerId)
			VALUES (UUID(), @QuestionId, @CorrectAnswerId);
        END;
    ELSE 
		BEGIN
			SET @CorrectAnswerId = @ExistCorrectAnswerId;
			SELECT t1.Id FROM QuestionsAndCorrectAnswers AS t1 
				WHERE  t1.QuestionId=@QuestionId AND t1.CorrectAnswerId=@CorrectAnswerId INTO @Id;

			IF @Id='empty' THEN 
				BEGIN
					INSERT INTO QuestionsAndCorrectAnswers (Id, QuestionId, CorrectAnswerId)
					VALUES (UUID(), @QuestionId, @CorrectAnswerId);
				END;
			ELSE
				BEGIN
					SET @TextMessage = @TextMessage + '. QuestionsAndCorrectAnswers found for QuestionId='+ @QuestionId + ' CorrectAnswerId=' + @CorrectAnswerId;
                END;
			END IF;
        END;
    END IF;
    
    SET Message = @TextMessage;
    COMMIT;
END