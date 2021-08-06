// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc
{
    using System;

    /// <summary>
    /// The config of Jwc.
    /// </summary>
    internal class Config
    {
        /// <summary>
        /// Gets the datetime of the first Monday of the term.
        /// </summary>
        public static DateTime TermStart { get; } = new(2021, 3, 1);
    }
}
