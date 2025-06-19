using System.Xml.Linq;

namespace IWantToKnowNet.Common.ViewModels;

public class CategoryViewModel
{
    public CategoryViewModel(
        string createrId,
        bool hidden,
        bool reverse,
        string categoryId,
        string? parentId,
        string nameEn,
        string nameEs,
        string nameRu,
        string? descriptionEn,
        string? descriptionEs,
        string? descriptionRu,
        int orderBy,
        int countQuestions)
    {
        CreaterId = createrId;
        Hidden = hidden;
        Reverse = reverse;
        CategoryId = categoryId;
        ParentId = parentId;
        NameEn = nameEn;
        NameEs = nameEs;
        NameRu = nameRu;
        DescriptionEn = descriptionEn;
        DescriptionEs = descriptionEs;
        DescriptionRu = descriptionRu;
        OrderBy = orderBy;
        CountQuestions = countQuestions;
    }
    public string CreaterId { get; set; }
    public bool Hidden { get; set; }
    public bool Reverse { get; set; }
    public string CategoryId { get; set; }
    public string? ParentId { get; set; }
    public string NameEn { get; set; }
    public string NameEs { get; set; }
    public string NameRu { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionEs { get; set; }
    public string? DescriptionRu { get; set; }
    public int OrderBy { get; set; }
    public int CountQuestions { get; set; }
    public string? TestResultSpeaking { get; set; } = "0%";
    public string? TestResultListen { get; set; } = "0%";
    public string? TestResultRead { get; set; } = "0%";

}
