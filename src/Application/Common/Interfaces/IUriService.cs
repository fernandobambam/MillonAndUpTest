namespace Application.Common.Interfaces
{
    public interface IUriService
    {
        Uri GetAllEntities(int PageSize, int PageNumber, string actionUrl);
    }
}
