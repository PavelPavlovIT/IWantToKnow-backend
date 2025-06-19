CREATE DEFINER=`admin`@`%` PROCEDURE `StartTest`(
	IN TestId  varchar(255),
	IN TypeTestId varchar(255),
	IN UserId varchar(255),
    IN CategoryId varchar(255),
    IN CategoryName varchar(500),
    IN CountQuestions int)
BEGIN
	START TRANSACTION;
    
    CREATE TEMPORARY TABLE IF NOT EXISTS ListIds (
		Id varchar(255)
    );
    
    CREATE TEMPORARY TABLE IF NOT EXISTS firstQuestionsRecord(
	   Id varchar(255),
	   CategoryId varchar(255),
       KeyS3 varchar(50),
       ExpiredSignedUrlS3 datetime(6),
       SignedUrlS3 varchar(1000),
       TitleEn varchar(500),
       TitleEs varchar(500),
       TitleRu varchar(500),
       ProofUrlEn varchar(1000),
       ProofUrlEs varchar(1000),
       ProofUrlRu varchar(1000),
       ProofCRCEn varchar(100),
       ProofCRCEs varchar(100),
       ProofCRCRu varchar(100),
       CreaterId varchar(255),
       ApproverId varchar(255),
       Guid varchar(255)
	);
    
    INSERT INTO Tests
		(`Id`,
		`CategoryName`,
		`Created`,
		`Started`,
		`CountQuestions`,
		`Finished`,
		`UserId`,
		`CategoryId`,
		`TypeTestId`)
	VALUES
		(TestId,
		CategoryName,
		now(),
		now(),
		CountQuestions,
        FALSE,
		UserId,
		CategoryId,
		TypeTestId);
        
	IF (TypeTestId='7b4da4cf-52b5-4c78-9834-b56e9dbe491a') OR (TypeTestId='9f8fb08c-0074-4860-8a95-6f49ab6bf5ac')  THEN 
		BEGIN
			INSERT INTO ListIds
			WITH RECURSIVE _listIds (Id) AS
			(
			  SELECT Id
				FROM Categories
				WHERE ParentId=CategoryId
			  UNION ALL
			  SELECT T1.Id
				FROM listIds AS p JOIN Categories AS T1
				  ON p.Id = T1.ParentId
			)
            SELECT * FROM _listIds;
            
            INSERT INTO firstQuestionsRecord
			SELECT t1.Id, CategoryId, KeyS3, ExpiredSignedUrlS3, SignedUrlS3, TitleEn, TitleEs, TitleRu, ProofUrlEn, ProofUrlEs, 
					ProofUrlRu, ProofCRCEn, ProofCRCEs, ProofCRCRu, CreaterId, ApproverId, UUID()
			FROM Questions AS t1
				INNER JOIN CategoryAndQuestions AS t2 ON t1.Id=t2.QuestionId
                WHERE t2.CategoryId IN (SELECT Id FROM ListIds);
        END;
    ELSE
		BEGIN
            INSERT INTO firstQuestionsRecord
			SELECT t1.Id, CategoryId, KeyS3, ExpiredSignedUrlS3, SignedUrlS3, TitleEn, TitleEs, TitleRu, ProofUrlEn, ProofUrlEs, 
					ProofUrlRu, ProofCRCEn, ProofCRCEs, ProofCRCRu, CreaterId, ApproverId, UUID()
			FROM Questions AS t1
				INNER JOIN CategoryAndQuestions AS t2 ON t1.Id=t2.QuestionId
                WHERE t2.CategoryId = CategoryId;
        END;
    END IF;
    
    INSERT INTO TestQuestions
		(`Id`,
		`TestId`,
		`QuestionsId`,
		`Created`,
		`Started`)
    SELECT uuid(), TestId, Id, now(),now() FROM firstQuestionsRecord ORDER BY Guid Limit 1;
    
    SELECT
		Id,
		CategoryId,
		KeyS3,
		ExpiredSignedUrlS3,
		SignedUrlS3,
		TitleEn,
		TitleEs,
		TitleRu,
		ProofUrlEn,
		ProofUrlEs,
		ProofUrlRu,
		ProofCRCEn,
		ProofCRCEs,
		ProofCRCRu,
		CreaterId FROM firstQuestionsRecord ORDER BY Guid Limit 1;
    
    DELETE FROM ListIds;
    DELETE FROM firstQuestionsRecord;
    
    COMMIT;
END