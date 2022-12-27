using AspApi.Controllers;
using AspApi.Database;
using AspApi.Dto.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace ODataCodegen.Controllers;

public class ProjectsController : DefaultRepositoryController<Project,Guid>
{
    public ProjectsController(SqliteDb sqliteDb) : base(sqliteDb,sqliteDb.Projects) { }

    [EnableQuery]
    public IQueryable<Project> Get() =>
        DefaultGet();
    
    [EnableQuery]
    public SingleResult<Project> Get(Guid key) =>
        DefaultGet(key);

    [EnableQuery]   
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ProjectPostDto postDto) =>
        await DefaultPostAsync(postDto);

    [EnableQuery]   
    [HttpPatch]
    public async Task<IActionResult> PatchAsync(Guid key,[FromBody] ProjectPatchDto postDto) =>
        await DefaultPatchAsync(key,postDto);

    [EnableQuery]   
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid key) =>
        await DefaultDeleteAsync(key);
}