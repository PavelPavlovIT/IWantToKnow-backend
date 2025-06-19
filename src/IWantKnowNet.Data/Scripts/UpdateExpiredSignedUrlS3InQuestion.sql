CREATE DEFINER=`admin`@`%` PROCEDURE `UpdateExpiredSignedUrlS3InQuestion`(
	IN QuestionId varchar(255),
    IN ExpiredSignedUrlS3 datetime,
	IN SignedUrlS3 varchar(1000)
)
BEGIN
	UPDATE Questions
	SET ExpiredSignedUrlS3=ExpiredSignedUrlS3, SignedUrlS3=SignedUrlS3 
	WHERE Id=QuestionId;
END