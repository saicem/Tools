// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jwc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Jwc User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the userName for jwc login.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for jwc login.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the cookie after login the jwc.
        /// </summary>
        public CookieContainer Cookie { get; set; }
    }
}
