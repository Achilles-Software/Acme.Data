#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Achilles.Acme.Data.Models;

#endregion

namespace Achilles.Acme.Data.Services
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region Fields

        private DbContext _dbContext;

        #endregion

        #region Constructor(s)

        public RepositoryBase( DbContext dbContext )
        {
            _dbContext = dbContext;
        }

        #endregion

        #region CRUD Methods

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public Task<TEntity> GetAsync( int id )
        {
            return _dbContext.Set<TEntity>().FirstOrDefaultAsync( e => ( e as IEntity ).Id == id );
        }
        
        public virtual async Task<int> CreateAsync( TEntity item )
        {
            _dbContext.Set<TEntity>().Add( item );

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync( TEntity entity )
        {
            _dbContext.Set<TEntity>().Remove( entity );

            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> EditAsync( TEntity entity )
        {
            _dbContext.Update( entity );

            return await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
