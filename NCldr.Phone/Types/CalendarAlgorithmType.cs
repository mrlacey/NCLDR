namespace System.Globalization
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies whether a calendar is solar-based, lunar-based, or lunisolar-based.
    /// </summary>
    [ComVisible(true)]
    public enum CalendarAlgorithmType
    {
        Unknown,
        SolarCalendar,
        LunarCalendar,
        LunisolarCalendar,
    }
}