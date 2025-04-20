
using ApplicationLayer.Common.Services;

namespace InfrastructureLayer.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
