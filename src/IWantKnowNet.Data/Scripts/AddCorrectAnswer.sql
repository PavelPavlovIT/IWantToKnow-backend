CREATE DEFINER=`root`@`localhost` PROCEDURE `AddCorrectAnswer`(
	IN Id varchar(255),
    IN TitleEn nvarchar(500),
	IN TitleEs nvarchar(500),
	IN TitleRu nvarchar(500),
    IN UserId nvarchar(255)
)
BEGIN
INSERT INTO CorrectAnswers
	(Id
	,TitleEn
	,TitleEs
	,TitleRu
	,CreaterId)
VALUES
	(Id
	,TitleEn
	,TitleEs
	,TitleRu
	,UserId);
END