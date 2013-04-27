using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lekplatser.Api.Security
{
    public class AdminAttribute : AuthorizeAttribute
    {
        //TODO: Dont allow users that are not admin: 
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            return;
        }
    }
}