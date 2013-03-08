using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
    /// <summary>
    /// Defines the types of culture lists that can be retrieved using the <see cref="M:System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes)"/> method.
    /// </summary>
    [Flags]
    [ComVisible(true)]
    [Serializable]
    public enum CultureTypes
    {
        NeutralCultures = 1,
        SpecificCultures = 2,
        InstalledWin32Cultures = 4,
        AllCultures = InstalledWin32Cultures | SpecificCultures | NeutralCultures,
        UserCustomCulture = 8,
        ReplacementCultures = 16,
        [Obsolete("This value has been deprecated.  Please use other values in CultureTypes.")] WindowsOnlyCultures = 32,
        [Obsolete("This value has been deprecated.  Please use other values in CultureTypes.")] FrameworkCultures = 64,
    }
}
