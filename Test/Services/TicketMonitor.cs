using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using test.Models.Railway;
using Test.Models;
using Test.Services.Railway;

namespace Test.Services
{
    public class TicketMonitor
    {
        private readonly TrainResponder _responder;

        public TicketMonitor()
        {
            _responder = new TrainResponder();
        }

        public List<Train> Find(Monitoring monitoring)
        {
            var result = new List<Train>();
            var trains = _responder.Search(monitoring.From, monitoring.To, monitoring.Date, monitoring.Time);
            foreach (var train in trains.Data.List)
            {
                if (train.Types.Select(i => i).Count(i => i.Title == monitoring.SeatType && i.Places != 0) != 0)
                {
                    result.Add(train);
                }
            }

            return result;
        }
    }
}
