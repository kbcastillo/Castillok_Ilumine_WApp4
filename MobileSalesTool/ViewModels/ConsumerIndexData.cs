using System.Collections.Generic;
using MobileSalesTool.Models;

namespace MobileSalesTool.ViewModels
{
    public class ConsumerIndexData
    {
        public IEnumerable<Consumer> Consumers { get; set; }
        public IEnumerable<Promotion> Promotions { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}