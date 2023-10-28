using Newtonsoft.Json;
using System.Net;
using VooltTest.Domain.Entities;
using VooltTest.Domain.Services;
using VooltTest.Domain.Services.BlockRepository;

namespace VooltTest.Data;

internal sealed class BlockRepository : IBlockRepository
{
    private static string GetFilePath(string key)
    {
        var subFolder = "pages";

        if (!Directory.Exists(subFolder))
        {
            Directory.CreateDirectory(subFolder);
        }

        return Path.Combine(subFolder, $"{key}.json");
    }

    public async Task<RepositoryResult> CreateOrUpdatePageAsync(string key, Page page, bool overwrite = false)
    {
        var filePath = GetFilePath(key);

        if (!overwrite && File.Exists(filePath))
        {
            return new RepositoryResult(HttpStatusCode.Conflict, "File already exists.");
        }

        var jsonData = JsonConvert.SerializeObject(page);
        await File.WriteAllTextAsync(filePath, jsonData);
        return new RepositoryResult();
    }

    public async Task<PageResult> GetPageAsync(string key)
    {
        var filePath = GetFilePath(key);

        if (!File.Exists(filePath))
        {
            return new PageResult(HttpStatusCode.NotFound, $"Page {key} not found.");
        }

        var jsonData = await File.ReadAllTextAsync(filePath);
        var page = JsonConvert.DeserializeObject<Page>(jsonData)!;
        return new PageResult(page);
    }

    public async Task<RepositoryResult> UpdateBlockAsync(string key, int sectionID, HeaderBlock updatedHeaderBlock)
    {
        var getPageResult = await GetPageAsync(key);

        if (getPageResult.IsInvalid)
        {
            return new RepositoryResult(getPageResult.StatusCode, getPageResult.ErrorMessage!);
        }

        var page = getPageResult.Page!;
        var existingBlockIndex = page.Headers!.FindIndex(x => x.ID == sectionID);

        if (existingBlockIndex == -1)
        {
            return new RepositoryResult(HttpStatusCode.NotFound, $"Block {sectionID} not found.");
        }

        updatedHeaderBlock.ID = sectionID;
        page.Headers[existingBlockIndex] = updatedHeaderBlock;

        return await CreateOrUpdatePageAsync(key, page, true);
    }

    public async Task<RepositoryResult> UpdateBlockAsync(string key, int sectionID, HeroBlock updatedHeroBlock)
    {
        var getPageResult = await GetPageAsync(key);

        if (getPageResult.IsInvalid)
        {
            return new RepositoryResult(getPageResult.StatusCode, getPageResult.ErrorMessage!);
        }

        var page = getPageResult.Page!;
        var existingBlockIndex = page.Heroes.FindIndex(x => x.ID == sectionID);

        if (existingBlockIndex == -1)
        {
            return new RepositoryResult(HttpStatusCode.NotFound, $"Block {sectionID} not found.");
        }

        page.Heroes[existingBlockIndex] = updatedHeroBlock;

        return await CreateOrUpdatePageAsync(key, page, true);
    }

    public async Task<RepositoryResult> UpdateBlockAsync(string key, int sectionID, ServicesBlock updatedServicesBlock)
    {
        var getPageResult = await GetPageAsync(key);

        if (getPageResult.IsInvalid)
        {
            return new RepositoryResult(getPageResult.StatusCode, getPageResult.ErrorMessage!);
        }

        var page = getPageResult.Page!;
        var existingBlockIndex = page.Services.FindIndex(x => x.ID == sectionID);

        if (existingBlockIndex == -1)
        {
            return new RepositoryResult(HttpStatusCode.NotFound, $"Block {sectionID} not found.");
        }

        page.Services[existingBlockIndex] = updatedServicesBlock;

        return await CreateOrUpdatePageAsync(key, page, true);
    }
}
