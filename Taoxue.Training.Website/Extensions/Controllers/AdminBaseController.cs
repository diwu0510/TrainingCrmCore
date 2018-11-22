using HZC.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Taoxue.Training.Website.Extensions
{
    [Area("Admin")]
    //[Authorize]
    public class AdminBaseController : BaseController
    {
        public AppUser AppUser
        {
            get
            {
                return new AppUser { Id = 1, Name = "admin" };
            }
        }
    }
}
