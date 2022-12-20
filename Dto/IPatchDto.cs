namespace AspApi.Dto;

public interface IPatchDto<T>
{
    public T Patch(T obj);

}
