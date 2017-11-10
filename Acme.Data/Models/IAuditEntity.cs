#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;

#endregion

namespace Achilles.Acme.Data.Models
{
    public interface IAuditEntity
    {
        string CreatedByUserId { get; set; }

        DateTime DateCreated { get; set; }

        string ModifiedByUserId { get; set; }

        DateTime DateModified { get; set; }

        // REVIEW: Where to put these fields

        //string PublishedByUserId { get; set; }

        //DateTime DatePublished { get; set; }
    }
}
