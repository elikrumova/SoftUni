﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Models;

namespace BookingSystem.Views.Venues
{
    public class All : View
    {
        public All(IEnumerable<Venue> venues)
            : base(venues)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venues = Model as IEnumerable<Venue>;
            if (!venues.Any())
            {
                viewResult.AppendLine("There are currently no venues to show.");
            }
            else
            {
                foreach (var venue in venues)
                {
                    viewResult
                        .AppendFormat("*[{0}] {1}, located at {2}", venue.Id, venue.Name, venue.Address)
                        .AppendLine()
                        .AppendFormat("Free rooms: {0}", (venue.Rooms == null ? 0 : venue.Rooms.Count))
                        .AppendLine();
                }
            }
        }
    }
}
