using VooltTest.Domain.Entities;

namespace VooltTest.Domain.Services.BlockRepository;

public interface IBlockRepository
{
    public Task<RepositoryResult> CreateOrUpdatePageAsync(string key, Page page, bool overwrite = false);
    public Task<PageResult> GetPageAsync(string key);
    public Task<RepositoryResult> UpdateBlockAsync(string key, int sectionID, HeaderBlock updatedHeaderBlock);
    public Task<RepositoryResult> UpdateBlockAsync(string key, int sectionID, HeroBlock updatedHeroBlock);
    public Task<RepositoryResult> UpdateBlockAsync(string key, int sectionID, ServicesBlock updatedServicesBlock);
}
