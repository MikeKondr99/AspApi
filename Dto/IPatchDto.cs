using System.IO.MemoryMappedFiles;
using System.Collections;
using Microsoft.AspNetCore.OData.Deltas;
using AgileObjects.AgileMapper;

namespace AspApi.Dto;

public interface IPatchDto<T> where T : class
{
    public T Patch(T entity);
}
