using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public FollowController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult AddFollower([FromBody]string Followee)
        {
            var loggedInUser = User.Identity.GetUserId();
            var exists = _context.Follows.Any(f => f.FolloweeId == Followee && f.FollowerId == loggedInUser);
            if (exists)
                return BadRequest("Some issue");
            var followObj = new Follow()
            {
                FolloweeId = Followee,
                FollowerId = loggedInUser
            };
            _context.Follows.Add(followObj);
            _context.SaveChanges();
            return Ok();
        }
    }
}
