﻿namespace NCldr.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Types;

    /// <summary>
    /// RegionInfoExtensions is a collection of extension methods for the RegionInfo class to access CLDR data as well as static methods to access CLDR data from region names
    /// </summary>
    public static class RegionInfoExtensions
    {
        /// <summary>
        /// GetPostcodeRegex gets the postal code regular expression for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the postal code regular expression for</param>
        /// <returns>The postal code regular expression for the RegionInfo</returns>
        public static string GetPostcodeRegex(this RegionInfo regionInfo)
        {
            return GetPostcodeRegex(regionInfo.Name);
        }

        /// <summary>
        /// GetPostcodeRegex gets the postal code regular expression for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the postal code regular expression for</param>
        /// <returns>The postal code regular expression for the region</returns>
        public static string GetPostcodeRegex(string regionId)
        {
            return (from pcr in NCldr.PostcodeRegexes
                    where string.Compare(pcr.RegionId, regionId, CultureInfo.InvariantCulture, CompareOptions.None) == 0
                    select pcr.Regex).FirstOrDefault();
        }

        /// <summary>
        /// GetTelephoneCodes gets an array of telephone codes used by the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the telephone codes for</param>
        /// <returns>An array of telephone codes used by the RegionInfo</returns>
        public static string[] GetTelephoneCodes(this RegionInfo regionInfo)
        {
            return GetTelephoneCodes(regionInfo.Name);
        }

        /// <summary>
        /// GetTelephoneCodes gets an array of telephone codes used by the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the telephone codes for</param>
        /// <returns>An array of telephone codes used by the region</returns>
        public static string[] GetTelephoneCodes(string regionId)
        {
            return (from rtc in NCldr.RegionTelephoneCodes
                    where string.Compare(rtc.RegionId, regionId, CultureInfo.InvariantCulture, CompareOptions.None) == 0
                    select rtc.TelephoneCodes).FirstOrDefault();
        }

        /// <summary>
        /// GetTelephoneCode gets the telephone code used by the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the telephone code for</param>
        /// <returns>The telephone code used by the RegionInfo</returns>
        /// <remarks>GetTelephoneCode gets only the first telephone code used by the region.
        /// There is only one telephone code when a region is a country/region. Only when a region
        /// is larger than a country/region (e.g. The World) will it have more than one telephone code.</remarks>
        public static string GetTelephoneCode(this RegionInfo regionInfo)
        {
            return GetTelephoneCode(regionInfo.Name);
        }

        /// <summary>
        /// GetTelephoneCode gets the telephone code used by the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the telephone code for</param>
        /// <returns>The telephone code used by the region</returns>
        /// <remarks>GetTelephoneCode gets only the first telephone code used by the region.
        /// There is only one telephone code when a region is a country/region. Only when a region
        /// is larger than a country/region (e.g. The World) will it have more than one telephone code.</remarks>
        public static string GetTelephoneCode(string regionId)
        {
            string[] telephoneCodes = (from rtc in NCldr.RegionTelephoneCodes
                                       where string.Compare(rtc.RegionId, regionId, CultureInfo.InvariantCulture, CompareOptions.None) == 0
                                       select rtc.TelephoneCodes).FirstOrDefault();
            if (telephoneCodes == null || telephoneCodes.GetLength(0) == 0)
            {
                return null;
            }

            return telephoneCodes[0];
        }

        /// <summary>
        /// GetRegionCode gets the RegionCode for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the RegionCode for</param>
        /// <returns>The RegionCode for the RegionInfo</returns>
        public static RegionCode GetRegionCode(this RegionInfo regionInfo)
        {
            return GetRegionCode(regionInfo.Name);
        }

        /// <summary>
        /// GetRegionCode gets the RegionCode for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the RegionCode for</param>
        /// <returns>The RegionCode for the region</returns>
        public static RegionCode GetRegionCode(string regionId)
        {
            return (from rc in NCldr.RegionCodes
                    where string.Compare(rc.RegionId, regionId, CultureInfo.InvariantCulture, CompareOptions.None) == 0
                    select rc).FirstOrDefault();
        }

        /// <summary>
        /// GetMeasurementSystem gets the MeasurementSystem for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the MeasurementSystem for</param>
        /// <returns>The MeasurementSystem for the RegionInfo</returns>
        public static RegionMeasurementSystem GetMeasurementSystem(this RegionInfo regionInfo)
        {
            return GetMeasurementSystem(regionInfo.Name);
        }

        /// <summary>
        /// GetMeasurementSystem gets the MeasurementSystem for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the MeasurementSystem for</param>
        /// <returns>The MeasurementSystem for the region</returns>
        public static RegionMeasurementSystem GetMeasurementSystem(string regionId)
        {
            RegionMeasurementSystem measurementSystem = (from ms in NCldr.MeasurementData.MeasurementSystems
                                                         where ms.RegionIds.Contains(regionId)
                                                         select ms).FirstOrDefault();

            if (measurementSystem != null)
            {
                // this region has a specific measurement system
                return measurementSystem;
            }

            // there is no specific measurement system for this region so default to the measurement system for the world ("001")
            return (from ms in NCldr.MeasurementData.MeasurementSystems
                    where ms.RegionIds.Contains(NCldr.RegionIdForTheWorld)
                    select ms).FirstOrDefault();
        }

        /// <summary>
        /// GetPaperSize gets the RegionPaperSize for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the RegionPaperSize for</param>
        /// <returns>The RegionPaperSize for the RegionInfo</returns>
        public static RegionPaperSize GetPaperSize(this RegionInfo regionInfo)
        {
            return GetPaperSize(regionInfo.Name);
        }

        /// <summary>
        /// GetPaperSize gets the RegionPaperSize for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the RegionPaperSize for</param>
        /// <returns>The RegionPaperSize for the region</returns>
        public static RegionPaperSize GetPaperSize(string regionId)
        {
            RegionPaperSize paperSize = (from ms in NCldr.MeasurementData.PaperSizes
                                         where ms.RegionIds.Contains(regionId)
                                         select ms).FirstOrDefault();

            if (paperSize != null)
            {
                // this region has a specific paper size
                return paperSize;
            }

            // there is no specific paper size for this region so default to the paper size for the world ("001")
            return (from ms in NCldr.MeasurementData.PaperSizes
                    where ms.RegionIds.Contains(NCldr.RegionIdForTheWorld)
                    select ms).FirstOrDefault();
        }

        /// <summary>
        /// GetDayOfWeek gets the first DayOfWeek for the RegionInfo
        /// </summary>
        /// <param name="regionInfo">The RegionInfo to get the first DayOfWeek for</param>
        /// <returns>The first DayOfWeek for the RegionInfo</returns>
        public static DayOfWeek GetDayOfWeek(this RegionInfo regionInfo)
        {
            return GetFirstDayOfWeek(regionInfo.Name);
        }

        /// <summary>
        /// GetFirstDayOfWeek gets the first DayOfWeek for the region
        /// </summary>
        /// <param name="regionId">The Id of the region to get the first DayOfWeek for</param>
        /// <returns>The first DayOfWeek for the region</returns>
        public static DayOfWeek GetFirstDayOfWeek(string regionId)
        {
            if (NCldr.WeekData != null && NCldr.WeekData.FirstDayOfWeeks != null)
            {
                RegionDayOfWeek regionDayOfWeek = (from fdow in NCldr.WeekData.FirstDayOfWeeks
                                                   where fdow.RegionIds.Contains(regionId)
                                                   select fdow).FirstOrDefault();
                if (regionDayOfWeek != null)
                {
                    // there is a specific first day of week for this region
                    return regionDayOfWeek.DayOfWeek;
                }

                // get the first day of week default (i.e. for the world)
                regionDayOfWeek = (from fdow in NCldr.WeekData.FirstDayOfWeeks
                                   where fdow.RegionIds.Contains(NCldr.RegionIdForTheWorld)
                                   select fdow).FirstOrDefault();
                if (regionDayOfWeek != null)
                {
                    return regionDayOfWeek.DayOfWeek;
                }
            }

            return DayOfWeek.Monday;
        }
    }
}
