using Microsoft.AspNetCore.Mvc;
using Taoxue.Training.Services;

namespace Taoxue.Training.Website.Extensions
{
    [Area("School")]
    public class SchoolBaseController : BaseController
    {
        protected SchoolUser SchoolUser
        {
            get
            {
                return new SchoolUser { Id = 2, Name = "江语晨", SchoolId = 1 };
            }
        }
    }
}
