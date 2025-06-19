CREATE DEFINER=`root`@`localhost` PROCEDURE `AddQuestion`(
	IN Id varchar(255),
    IN TitleEn nvarchar(500),
	IN TitleEs nvarchar(500),
	IN TitleRu nvarchar(500),
    IN ProofUrlEn nvarchar(1000),
	IN ProofUrlEs nvarchar(1000),
	IN ProofUrlRu nvarchar(1000),
    IN CategoryId nvarchar(255),
    IN UserId nvarchar(255),
	IN KeyS3 nvarchar(50),
	IN ExpiredSignedUrlS3 datetime,
	IN SignedUrlS3 nvarchar(1000)
    )
BEGIN
	DECLARE Count INT;
	SET Count = -1;

    SELECT COUNT(*) FROM db1.Questions as t1 WHERE t1.CategoryId=CategoryId INTO Count; 
    
	INSERT INTO Questions(
		Id,
        TitleEn,
        TitleEs,
        TitleRu,
        ProofUrlEn,
        ProofUrlEs,
        ProofUrlRu,
        CategoryId,
        CreaterId,
        KeyS3,
        ExpiredSignedUrlS3,
        SignedUrlS3)
	VALUES (
		Id, 
        TitleEn,
        TitleEs,
        TitleRu,
        ProofUrlEn,
        ProofUrlEs,
        ProofUrlRu,
        CategoryId,
        UserId,
        KeyS3,
        ExpiredSignedUrlS3,
        SignedUrlS3);
	
	UPDATE Categories t1 SET t1.CountQuestions=Count+1 WHERE t1.Id=CategoryId;
    
END