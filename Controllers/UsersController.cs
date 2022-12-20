using AspApi.Database;
using AspApi.Dto;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Controllers;

public class UsersController : DefaultRepositoryController<User,Guid>
{
    public UsersController(SqliteDb sqliteDb) : base(sqliteDb,sqliteDb.Users) {

    }

}

