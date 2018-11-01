using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Hangfire;
using test.Models.Railway;
using Test.Models;

namespace Test.Services
{
    public static class HangfireService
    {
        private static readonly TicketMonitor TicketMonitor;

        private static readonly MonitoringRepository MonitoringRepository;

        static HangfireService()
        {
            TicketMonitor = new TicketMonitor();
            MonitoringRepository = new MonitoringRepository();
        }

        public static void CheckTickets(Monitoring monitoring)
        {
            var trains = TicketMonitor.Find(monitoring);
            if (trains.Count == 0) return;
            monitoring.Trains = new List<Train>(trains);
            monitoring.IsSuccessed = true;
            monitoring.IsInProccess = false;
            MonitoringRepository.Update(monitoring);
            RecurringJob.RemoveIfExists(monitoring.Id.ToString());
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("***** Найдені потяги *****");
            foreach (var train in trains)
            {
                Console.WriteLine(train.ToString());
                stringBuilder.AppendLine(train.ToString());
            }
            MailAddress from = new MailAddress("gomenyuknazar@gmail.com", "RailwayBot");
            MailAddress to = new MailAddress(monitoring.UserEmail);
            MailMessage m = new MailMessage(from, to) { Subject = "RailwayTicket", Body = stringBuilder.ToString() };
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("gomenyuknazar@gmail.com", "jumpjet24845"),
                EnableSsl = true
            };
            smtp.Send(m);
        }
    }
}