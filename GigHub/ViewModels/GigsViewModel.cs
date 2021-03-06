using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> Gigs { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}