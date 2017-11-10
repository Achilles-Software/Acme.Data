#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Data.Services
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync( int id );

        IQueryable<TEntity> GetAll();

        Task<int> CreateAsync( TEntity item );

        Task<int> EditAsync( TEntity item );

        Task<int> DeleteAsync( TEntity item );
    }
}
