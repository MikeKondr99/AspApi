using AspApi.Database;
using AspApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Controllers;

public interface IHasKey<T> 
{
    public T Id { get; set; }
}

public abstract class DefaultRepositoryController<T,TKey> : ODataController  where T : class, IHasKey<TKey>
{
    protected DbSet<T> Table { get; init;}
    protected DbContext Context { get; init;}

    public DefaultRepositoryController(DbContext db,DbSet<T> table)
    {
        Context = db;
        Table = table;
    }


    [EnableQuery]
    public IQueryable<T> Get()
    {
        return Table;
    }
    
    [EnableQuery]
    public SingleResult<T> Get(TKey key)
    {
        return SingleResult.Create(Table.Where(u => u.Id!.Equals(key)));
    }

    [EnableQuery]   
    public async Task<IActionResult> PostAsync([FromBody] IPostDto<T> postDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var user = postDto.Create();
        await Table.AddAsync(user);
        await Context.SaveChangesAsync();
        return Created(user);
    }

    [EnableQuery]   
    public async Task<IActionResult> PatchAsync(Guid key,[FromBody] IPatchDto<T> patchDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var user = await Table.FindAsync(key);
        if(user is null) 
            return NotFound();
        user = patchDto.Patch(user);
        await Context.SaveChangesAsync();
        return Updated(user);
    }



    [EnableQuery]   
    public async Task<IActionResult> DeleteAsync(Guid key)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        var user = await Table.FindAsync(key);
        if(user is null) 
            return NotFound();
        Table.Remove(user);
        await Context.SaveChangesAsync();
        return NoContent();
    }


}

