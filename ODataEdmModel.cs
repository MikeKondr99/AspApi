using AspApi.Database;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace AspApi;
public static class ODataEdmModel
{
    public static IEdmModel Get() 
    {
        var builder = new ODataConventionModelBuilder();

        builder.EntitySet<User>("Users");

        return builder.GetEdmModel();

    }

}