using Hangfire;
using Test.Models;

namespace Test.Services
{
    public static class HangfireService
    {
        private static int _testCount;

        private static readonly MonitoringRepository MonitoringRepository;

        static HangfireService()
        {
            MonitoringRepository = new MonitoringRepository();
        }

        public static void CheckTickets(Monitoring monitoring)
        {
            if (_testCount == 3)
            {
                monitoring.IsSuccessed = true;
                monitoring.IsInProccess = false;
                MonitoringRepository.Update(monitoring);
                RecurringJob.RemoveIfExists(monitoring.Id.ToString());
                _testCount = 0;
            }
            else
            {
                _testCount++;
            }
        }
    }
}