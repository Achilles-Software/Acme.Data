﻿#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

namespace Achilles.Acme.Data.Models
{
    public interface IEntity
    {
        // REVIEW: int vs GUID or have alternate GUID key along with int PK.
        int Id { get; set; }
    }
}