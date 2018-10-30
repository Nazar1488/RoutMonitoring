using Postal;

namespace Test.Models
{
    public class EmailNotification : Email
    {
        public string To { get; set; }
        public string UserName { get; set; }
        public string RoutName { get; set; }
    }
}