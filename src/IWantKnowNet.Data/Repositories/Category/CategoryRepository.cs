using System.Collections.Concurrent;
using System.Linq;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantKnowNet.Data.Repositories.Base;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using IWantKnowNet.Data.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IWantKnowNet.Data.Repositories.AnalyticRepository;

namespace IWantKnowNet.Data.Repositories.Categories;

public class CategoryRepository(
    ILogger<CategoryRepository> logger,
    IAnalyticRepository analyticRepository,
    IDataService dataService,
    ApplicationDbContext context) : ICategoryRepository
{
    public async Task<List<string>?> GetAllIdCategoryByParentIdAsync(string parentId,
        CancellationToken cancellationToken)
    {
        var listCategories = await context.Categories.AsNoTracking().ToListAsync(cancellationToken);
        var model = listCategories.FirstOrDefault(i => i.Id.Equals(parentId));

        var resultList = new ConcurrentDictionary<string, Category>();

        await this.GetHierarchyDown(
            resultList,
            listCategories,
            parentId);

        resultList.TryAdd(parentId, new Category()
        {
            Id = model!.Id,
            CreaterId = model.CreaterId,
            NameEn = model.NameEn,
            NameEs = model.NameEn,
            NameRu = model.NameEn,
            DescriptionEn = model.DescriptionEn,
            DescriptionEs = model.DescriptionEs,
            DescriptionRu = model.DescriptionRu
        });

        foreach (var item in resultList.Values)
        {
            resultList.TryAdd(parentId, item);
        }

        return resultList.Values.Select(i => i.Id).ToList();
    }

    public async Task<string> GetHierarchyCategoryAsString(string lang, string categoryId,
        CancellationToken cancellationToken)
    {
        var list = await GetHierarchyCategory("", categoryId, cancellationToken);
        string result = "";
        foreach (var item in list)
        {
            switch (lang)
            {
                case "ru":
                    result += item.NameRu + "\\";
                    break;
                case "es":
                    result += item.NameEs + "\\";
                    break;
                default:
                    result += item.NameEn + "\\";
                    break;
            }
        }

        return result;
    }

    public async Task<List<CategoryViewModel>> GetHierarchyCategory(
        string lang,
        string categoryId,
        CancellationToken cancellationToken)
    {
        List<Category>? allCategories = null;

        Category? category = null;

        List<Category>? hierarchyCategory = null;


        allCategories = await context.Categories.AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        category = await context.Categories.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken: cancellationToken);
        hierarchyCategory = await GetHierarchyUp(new List<Category>(),
            allCategories,
            category!);
        hierarchyCategory.Add(new Category()
        {
            Id = string.Empty,
            CreaterId = Guid.Empty.ToString(),
            NameEn = "Root",
            NameEs = "Root",
            NameRu = "Root",
            DescriptionEn = string.Empty,
            DescriptionEs = string.Empty,
            DescriptionRu = string.Empty,
            CountQuestions = -1
        });
        hierarchyCategory.Reverse();

        return hierarchyCategory
            .Select(item => new CategoryViewModel(
                item.CreaterId,
                item.Hidden,
                item.Reverse,
                item.Id,
                item.ParentId,
                item.NameEn,
                item.NameEs,
                item.NameRu,
                item.DescriptionEn,
                item.DescriptionEs,
                item.DescriptionRu,
                item.OrderBy,
                item.CountQuestions))
            .ToList();
    }

    public async Task<List<CategoryViewModel>?> GetChildrenOfCategoryAsync(
        ApplicationUser? user,
        string? parentId,
        CancellationToken cancellationToken)
    {
        var result = await (from categories in context.Categories
            orderby categories.OrderBy
            where categories.ParentId == parentId
                  && !categories.Hidden
            select new CategoryViewModel(
                categories.CreaterId,
                categories.Hidden,
                categories.Reverse,
                categories.Id,
                categories.ParentId,
                categories.NameEn,
                categories.NameEs,
                categories.NameRu,
                categories.CountQuestions == -1 ? "" : categories.DescriptionEn,
                categories.CountQuestions == -1 ? "" : categories.DescriptionEs,
                categories.CountQuestions == -1 ? "" : categories.DescriptionRu,
                categories.OrderBy,
                categories.CountQuestions)).ToListAsync(cancellationToken: cancellationToken);

        if (!string.IsNullOrEmpty(user?.Id))
        {
            if (user.ExpireDateTime < DateTime.UtcNow)
            {
                foreach (var item in result)
                {
                    item.TestResultRead = "";
                    item.TestResultListen = "";
                    item.TestResultSpeaking = "";
                }

                return result;
            }

            var testResultsByRead =
                await analyticRepository.GetLastResultsTestByCategoryIdForUserByRead(user.Id, parentId,
                    cancellationToken);
            var testResultsByListen =
                await analyticRepository.GetLastResultsTestByCategoryIdForUserByListen(user.Id, parentId,
                    cancellationToken);
            var testResultsBySpeaking =
                await analyticRepository.GetLastResultsTestByCategoryIdForUserBySpeaking(user.Id, parentId,
                    cancellationToken);
            if (testResultsByRead == null && testResultsByListen == null && testResultsBySpeaking == null)
            {
                return result;
            }

            if (testResultsByRead!.Count == 0 && testResultsByListen!.Count == 0 && testResultsBySpeaking!.Count == 0)
            {
                return result;
            }

            foreach (var item in result)
            {
                if ((testResultsByRead != null) && (testResultsByRead!.Count > 0))
                {
                    if (testResultsByRead.ContainsKey(item.CategoryId))
                    {
                        var values = testResultsByRead[item.CategoryId];

                        if (values != null)
                        {
                            var resultString = "";
                            var index = 0;
                            foreach (var test in values)
                            {
                                index++;
                                resultString += $"{test.CorrectAnswersCount * 100 / test.TestQuestionCount}% ";
                                if (index == 3) break;
                            }

                            item.TestResultRead = resultString;
                        }
                    }
                }

                if ((testResultsByListen != null) && (testResultsByListen!.Count > 0))
                {
                    if (testResultsByListen.ContainsKey(item.CategoryId))
                    {
                        var values = testResultsByListen[item.CategoryId];

                        if (values != null)
                        {
                            var resultString = "";
                            var index = 0;
                            foreach (var test in values)
                            {
                                index++;
                                resultString += $"{test.CorrectAnswersCount * 100 / test.TestQuestionCount}% ";
                                if (index == 3) break;
                            }

                            item.TestResultListen = resultString;
                        }
                    }
                }

                if ((testResultsBySpeaking != null) && (testResultsBySpeaking!.Count > 0))
                {
                    if (testResultsBySpeaking.ContainsKey(item.CategoryId))
                    {
                        var values = testResultsBySpeaking[item.CategoryId];

                        if (values != null)
                        {
                            var resultString = "";
                            var index = 0;
                            foreach (var test in values)
                            {
                                index++;
                                resultString += $"{test.CorrectAnswersCount * 100 / test.TestQuestionCount}% ";
                                if (index == 3) break;
                            }

                            item.TestResultSpeaking = resultString;
                        }
                    }
                }
            }
        }

        return result;
    }

    public async Task<CategoryViewModel?> GetCategoryByCategoryIdAsync(
        string lang,
        string categoryId,
        CancellationToken cancellationToken)
    {
        return await context.Categories.Where(item => item.Id.Equals(categoryId))
            .Select(item => new CategoryViewModel(
                item.CreaterId,
                item.Hidden,
                item.Reverse,
                item.Id,
                item.ParentId,
                item.NameEn,
                item.NameEs,
                item.NameRu,
                item.DescriptionEn,
                item.DescriptionEs,
                item.DescriptionRu,
                item.OrderBy,
                item.CountQuestions))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task AddCategoryAsync(CategoryViewModel model, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(model.ParentId))
            model.ParentId = String.Empty;

        var allCategories = await context.Categories.AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        if (allCategories.Count == 0)
        {
            await context.Categories
                .AddAsync(new Category()
                {
                    Id = model.CategoryId,
                    CreaterId = model.CreaterId,
                    ParentId = model.ParentId,
                    NameEn = model.NameEn,
                    NameEs = model.NameEs,
                    NameRu = model.NameRu,
                    DescriptionEn = model.DescriptionEn,
                    DescriptionEs = model.DescriptionEs,
                    DescriptionRu = model.DescriptionRu,
                    OrderBy = model.OrderBy,
                    CountQuestions = -1
                }, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return;
        }

        /*
        var hierarchyCategory = await GetHierarchyUp(new List<Category>(),
            allCategories,
            new Category()
            {
                Id = model.CategoryId,
                CreaterId = model.CreaterId,
                ParentId = model.ParentId,
                NameEn = model.NameEn,
                NameEs = model.NameEs,
                NameRu = model.NameRu,
                DescriptionEn = model.DescriptionEn,
                DescriptionEs = model.DescriptionEs,
                DescriptionRu = model.DescriptionRu,
                CountQuestions = model.CountQuestions,
                OrderBy = model.OrderBy,
            });
        hierarchyCategory.Reverse();

        await context.Categories
            .Where(item => hierarchyCategory.Contains(item))
            .ExecuteUpdateAsync(item =>
                item.SetProperty(p => p.CountQuestions, -1), cancellationToken);
        */
        var categoryId = Guid.NewGuid().ToString();

        await context.Categories
            .AddAsync(new Category()
            {
                Id = categoryId,
                CreaterId = model.CreaterId,
                ParentId = model.ParentId,
                NameEn = model.NameEn,
                NameEs = model.NameEs,
                NameRu = model.NameRu,
                DescriptionEn = model.DescriptionEn,
                DescriptionEs = model.DescriptionEs,
                DescriptionRu = model.DescriptionRu,
                OrderBy = model.OrderBy,
                CountQuestions = -1
            }, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task UpdateCategoryAsync(CategoryViewModel model, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        context.Categories
            .Update(new Category
            {
                Id = model.CategoryId,
                CreaterId = model.CreaterId,
                ParentId = model.ParentId,
                NameEn = model.NameEn,
                NameEs = model.NameEs,
                NameRu = model.NameRu,
                DescriptionEn = model.DescriptionEn,
                DescriptionEs = model.DescriptionEs,
                DescriptionRu = model.DescriptionRu,
                OrderBy = model.OrderBy,
                CountQuestions = model.CountQuestions
            });

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task RemoveCategoryAsync(CategoryViewModel model, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var listCategories = await context.Categories.AsNoTracking().ToListAsync(cancellationToken);

        var resultList = new ConcurrentDictionary<string, Category>();

        await this.GetHierarchyDown(
            resultList,
            listCategories,
            model.CategoryId);

        resultList.TryAdd(model.CategoryId, new Category()
        {
            Id = model.CategoryId,
            CreaterId = model.CreaterId,
            NameEn = model.NameEn,
            NameEs = model.NameEn,
            NameRu = model.NameEn,
            DescriptionEn = model.DescriptionEn,
            DescriptionEs = model.DescriptionEs,
            DescriptionRu = model.DescriptionRu,
        });

        foreach (var item in resultList.Values)
        {
            context.Categories.Remove(item);
        }

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }

    #region Private methods

    private async Task<List<Category>> GetHierarchyUp(
        List<Category> result,
        List<Category> list,
        Category current)
    {
        var existCurrent = list.FirstOrDefault(x => x.Id == current.Id);

        if (existCurrent != null && string.IsNullOrEmpty(current.ParentId))
        {
            result.Add(existCurrent);
            return await Task.FromResult(result);
        }

        if (existCurrent != null) result.Add(existCurrent);

        var parent = list.FirstOrDefault(x => x.Id == current.ParentId);
        if (parent == null)
        {
            return await Task.FromResult(result);
        }

        return await await Task.FromResult(GetHierarchyUp(result, list, parent));
    }

    private async Task GetHierarchyDown(
        ConcurrentDictionary<string, Category> result,
        List<Category> list,
        string currentId)
    {
        var current = list.FirstOrDefault(x => x.Id == currentId);

        var children = list.Where(x => x.ParentId == currentId).ToList();

        if (!children.Any())
        {
            result.TryAdd(current?.Id, current);
            await Task.CompletedTask;
            return;
        }

        children.ForEach(Action);

        async void Action(Entity.Category x)
        {
            result.TryAdd(x.Id, x);
            await GetHierarchyDown(result, list, x.Id);
        }
    }

    #endregion
}