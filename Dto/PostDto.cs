using AgileObjects.AgileMapper;

namespace AspApi.Dto;

public class PostDto<T> : IPostDto<T>
{
    public virtual T Create()
    {
        return Mapper.Map(this).ToANew<T>();
    }
}