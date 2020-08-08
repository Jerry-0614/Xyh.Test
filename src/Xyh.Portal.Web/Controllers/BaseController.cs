using System.Linq;
using System.Threading.Tasks;

namespace Xyh.Portal.Web.Controllers
{
    public class BaseController : PortalControllerBase
    {

        public BaseController()
        {
            
        }

        protected async Task<string> GetCurrentUser()
        {
            string guid = string.Empty;
            var sub = User.Claims.FirstOrDefault(c => c.Type == "sub");
            if (sub != null)
                guid = sub.Value;
            //guid = $"guid={guid}";
            //StaffBasicOutput output = await _eurekaClient.StaffBasicQuery(guid);
            //return output?.MapTo<BaseUser>();
            return guid;
        }
    }
}
