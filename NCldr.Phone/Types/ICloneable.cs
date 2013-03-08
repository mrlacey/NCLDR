﻿// Type: System.ICloneable
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    /// Supports cloning, which creates a new instance of a class with the same value as an existing instance.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    [ComVisible(true)]
    public interface ICloneable
    {
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// 
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        object Clone();
    }
}
