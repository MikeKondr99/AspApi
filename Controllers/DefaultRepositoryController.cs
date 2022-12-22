using ODataCodegen.Database;
using FluentValidation;
using ODataCodegen.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ODataCodegen.Controllers;


public interface IHasKey<T> 
{
    public T Id { get; set; }
}

public abstract class DefaultRepositoryController<T,TKey> : ODataController  where T : class, IHasKey<TKey>
{
    protected DbSet<T> Table { get; init;}
    protected DbContext Context { get; init;}
    protected IValidator<T> Validator { get; init; } 
    protected IValidator<IPostDto<T>> PostValidator { get; init; }
    protected IValidator<IPatchDto<T>> PatchValidator { get; init; }

    public DefaultRepositoryController(DbContext db,
                                       DbSet<T> table,
                                       IValidator<T> Validator,
                                       IValidator<IPostDto<T>> PostValidator,
                                       IValidator<IPatchDto<T>> PatchValidator)
    {
        this.Validator = Validator;
        this.PostValidator = PostValidator;
        this.PatchValidator = PatchValidator;

        Context = db;
        Table = table;
    }

    public virtual IQueryable<T> DefaultGet()
    {
        return Table;
    }
    
    public virtual SingleResult<T> DefaultGet(TKey key)
    {
        return SingleResult.Create(Table.Where(u => u.Id!.Equals(key)));
    }

    public virtual async Task<IActionResult> DefaultPostAsync([FromBody] IPostDto<T> postDto) 
    {
        if(!ModelIsValid())
            return BadRequest(ModelState);
        var user = postDto.Create();
        await Table.AddAsync(user);
        await Context.SaveChangesAsync();
        return Created(user);
    }

    public virtual async Task<IActionResult> DefaultPatchAsync(TKey key,[FromBody] IPatchDto<T> patchDto)
    {
        if(!ModelIsValid())
            return BadRequest(ModelState);
        var user = await Table.FindAsync(key);
        if(user is null) 
            return NotFound();
        user = patchDto.Patch(user);
        await Context.SaveChangesAsync();
        return Updated(user);
    }

    public virtual async Task<IActionResult> DefaultDeleteAsync(TKey key)
    {
        if(!ModelIsValid())
            return BadRequest(ModelState);
        var user = await Table.FindAsync(key);
        if(user is null) 
            return NotFound();
        Table.Remove(user);
        await Context.SaveChangesAsync();
        return NoContent();
    }

    public virtual bool ModelIsValid()
    {
        return ModelState.IsValid;
    }


}

