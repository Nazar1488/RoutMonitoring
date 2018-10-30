using Hangfire;
using Test.Models;

namespace Test.Services
{
    public static class HangfireService
    {
        private static int _testCount;

        private static readonly MonitoringRepository _monitoringRepository;

        static HangfireService()
        {
            _monitoringRepository = new MonitoringRepository();
        }

        public static void CheckTickets(Monitoring monitoring)
        {
            if (_testCount == 3)
            {
                monitoring.IsSuccessed = true;
                monitoring.IsInProccess = false;
                _monitoringRepository.Update(monitoring);
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