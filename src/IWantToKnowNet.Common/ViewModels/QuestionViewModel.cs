using System.ComponentModel.DataAnnotations;

namespace IWantToKnowNet.Common.ViewModels;

public class QuestionViewModel
{
    //public QuestionViewModel(
    //    string id,
    //    bool isTerm,
    //    string categoryId,
    //    string keyS3,
    //    DateTime? expiredSignedUrlS3,
    //    string signedUrlS3,
    //    string titleEn,
    //    string titleEs,
    //    string titleRu,
    //    string proofUrlEn,
    //    string? proofCRCEn,
    //    string proofUrlEs,
    //    string? proofCRCEs,
    //    string proofUrlRu,
    //    string? proofCRCRu,
    //    string createrId,
    //    string? approverId,
    //    string? correctAnswerEn,
    //    string? correctAnswerEs,
    //    string? correctAnswerRu)
    //{
    //    QuestionId = id;
    //    IsTerm = isTerm;
    //    CategoryId = categoryId;
    //    KeyS3 = keyS3;
    //    ExpiredSignedUrlS3 = expiredSignedUrlS3;
    //    SignedUrlS3 = signedUrlS3;
    //    TitleEn = titleEn;
    //    TitleEs = titleEs;
    //    TitleRu = titleRu;
    //    ProofUrlEn = proofUrlEn;
    //    ProofCRCEn = proofCRCEn;
    //    ProofUrlEs = proofUrlEs;
    //    ProofCRCEs = proofCRCEs;
    //    ProofUrlRu = proofUrlRu;
    //    ProofCRCRu = proofCRCRu;
    //    CreaterId = createrId;
    //    ApproverId = approverId;
    //    CorrectAnswerEn = correctAnswerEn;
    //    CorrectAnswerEs = correctAnswerEs;
    //    CorrectAnswerRu = correctAnswerRu;
    //}
    public string QuestionId { get; set; }
    public string CategoryId { get; set; }
    public string? KeyS3 { get; set; }
    public DateTime? ExpiredSignedUrlS3 { get; set; }
    public string? SignedUrlS3 { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleEs { get; set; }
    public string? TitleRu { get; set; }
    public string? ProofUrlEn { get; set; }
    public string? ProofCRCEn { get; set; }
    public string? ProofUrlEs { get; set; }
    public string? ProofCRCEs { get; set; }
    public string? ProofUrlRu { get; set; }
    public string? ProofCRCRu { get; set; }
    public string? CreaterId { get; set; }
    public string? ApproverId { get; set; }
    public string? CorrectAnswerEn { get; set; }
    public string? CorrectAnswerEs { get; set; }
    public string? CorrectAnswerRu { get; set; }
    public int? IsTerm { get; set; }
}