 

namespace Contracts.Menus
{
    public record MenuResponse(
        Guid Id, 
        string Name, 
        string Description, 
        float AverageRating, 
        List<MenuSectionResponse> Sections,
        string HostId,
        List<string> DinnerIds,
        List<string> MenuIds,
        List<string> MenuReviewIds, 
        DateTime CreatedAt,
        DateTime UpdatedAt
        );
    public record MenuSectionResponse(string Id, string Name, string Description, List<MenuItemResponse> Sections);
    public record MenuItemResponse(string Id, string Name, string Description);
}
