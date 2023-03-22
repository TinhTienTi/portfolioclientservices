using PortfolioServices.Model;

namespace PortfolioServices.Bo.Interfaces
{
    public interface IProfileBo
    {
        Task<IEnumerable<ProfileResponseDto>> GetHomeInfoQueryableAsync(string languageId);

        Task<IEnumerable<ProfileResponseDto>> GetAboutInfoQueryableAsync(string languageId);
    }
}
