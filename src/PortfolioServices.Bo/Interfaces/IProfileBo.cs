using PortfolioServices.Dto;

namespace PortfolioServices.Bo.Interfaces
{
    public interface IProfileBo
    {
        Task<IEnumerable<ProfileResponseDto>> GetHomeInfoAsync(string languageId);

        Task<IEnumerable<ProfileResponseDto>> GetAboutInfoAsync(string languageId);

        Task<IEnumerable<ClientProfileResponseDto>> GetClientInfoAsync(string languageId);
        
        Task<IEnumerable<PortfolioProfileResponseDto>> GetPortfolioInfoAsync(string languageId);

        Task<IEnumerable<ServiceProfileResponseDto>> GetServicesInfoAsync(string languageId);
    }
}
