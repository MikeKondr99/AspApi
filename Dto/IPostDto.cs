using AspApi.Database;

namespace AspApi.Dto;

public interface IPostDto<T>
{
    public T Create();

}
