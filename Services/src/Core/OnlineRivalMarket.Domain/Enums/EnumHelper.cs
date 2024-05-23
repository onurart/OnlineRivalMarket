namespace OnlineRivalMarket.Domain.Enums
{
    public class EnumHelper
    {
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var displayAttribute = field?.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            return displayAttribute?.Name ?? value.ToString();
        }
    }
}
