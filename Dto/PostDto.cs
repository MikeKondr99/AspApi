using AgileObjects.AgileMapper;

namespace AspApi.Dto.Users;

public class PostDto<T> : IPostDto<T>
{
    public virtual T Create()
    {
        return Mapper.Map(this).ToANew<T>();
    }
}