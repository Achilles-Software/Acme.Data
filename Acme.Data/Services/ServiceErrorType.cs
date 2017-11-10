#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Collections.Generic;

#endregion

namespace Achilles.Acme.Data.Services
{
    public enum ServiceErrorType : int
    {
        Unknown = 0x01,
        Validation = 0x02,
        Repository = 0x03,
        SqlReferentialConstraint = 547,
    }

    public class DataServiceErrorString
    {
        public static readonly IDictionary<ServiceErrorType, string> Names = new Dictionary<ServiceErrorType, string>
        {
            { ServiceErrorType.Unknown, "Unknown access failure" },
            { ServiceErrorType.Validation, "Validation failure" },
            { ServiceErrorType.Repository, "Repository access failure" },
            { ServiceErrorType.SqlReferentialConstraint, "SQL Referential Constraint violation" },
        };
    }
}
