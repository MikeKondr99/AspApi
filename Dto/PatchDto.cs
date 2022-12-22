using System.IO.MemoryMappedFiles;
using AgileObjects.AgileMapper;

namespace AspApi.Dto;

public class PatchDto<T> : IPatchDto<T> where T : class
{
    public virtual T Patch(T entity)
    {
        Mapper.Map(this).OnTo(entity);
        return entity;
    }
}