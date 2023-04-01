using PortfolioServices.Dto;

namespace PortfolioServices.Bo.Interfaces
{
    public interface IProfileBo
    {
        Task<IEnumerable<ProfileResponseDto>> GetHomeInfoQueryableAsync(string languageId);

        Task<IEnumerable<ProfileResponseDto>> GetAboutInfoQueryableAsync(string languageId);

        Task<IEnumerable<ClientProfileResponseDto>> GetClientInfoQueryableAsync(string languageId);

        Task<IEnumerable<ServiceProfileResponseDto>> GetServicesInfoQueryableAsync(string languageId);
    }
}
