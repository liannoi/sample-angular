namespace SampleAngular.Application.Common.Pagings
{
    public interface IPagingDetails
    {
        int TotalItems { get; set; }
        int ItemsPerPage { get; set; }
        int CurrentPage { get; set; }
        int TotalPages { get; }
    }
}