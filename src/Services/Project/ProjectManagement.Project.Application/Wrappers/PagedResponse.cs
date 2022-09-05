namespace ProjectManagement.Project.Application.Wrappers;

public class PagedResponse<TData>
{
    public TData? Data { get; }
    public int Page { get; }
    public int Size { get; }

    public PagedResponse(TData? data, int page, int size)
    {
        Data = data;
        Page = page;
        Size = size;
    }
}