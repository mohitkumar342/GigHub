using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int gigId)
        {

            var userID = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(a => a.AttendeeId == userID && a.GigId == gigId);
            if (exists)
                return BadRequest("Attendance Already Exists");
            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = userID
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
