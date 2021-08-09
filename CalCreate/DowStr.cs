// <copyright file="DowStr.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalCreate
{
    using System;

    /// <summary>
    /// use for get abbrevation of the day of week.
    /// </summary>
    public static class DowStr
    {
        /// <summary>
        /// get the day of week abbrevation.
        /// </summary>
        /// <param name="index">the day of week.</param>
        /// <returns>the abbrevation of day of week.</returns>
        public static string Get(int index)
        {
            if (index < 0 || index >= 7)
            {
                throw new IndexOutOfRangeException("day of week should be 0 to 6");
            }

            return index switch
            {
                0 => "SU",
                1 => "MO",
                2 => "TU",
                3 => "WE",
                4 => "TH",
                5 => "FR",
                6 => "SA",
                _ => "Undefined",
            };
        }

        /// <summary>
        /// get the day of week abbrevation.
        /// </summary>
        /// <param name="dayOfWeek">the day of week.</param>
        /// <returns>the abbrevation of day of week.</returns>
        public static string Get(DayOfWeek dayOfWeek)
        {
            int index = (int)dayOfWeek;
            return index switch
            {
                0 => "SU",
                1 => "MO",
                2 => "TU",
                3 => "WE",
                4 => "TH",
                5 => "FR",
                6 => "SA",
                _ => "Undefined",
            };
        }
    }
}
