#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Data.Services
{
    public abstract class ServiceBase<TEntity> : IService<TEntity>
        where TEntity : class
    {
        #region Fields

        private IRepository<TEntity> _repository;

        #endregion

        #region Constructor(s)

        public ServiceBase( IRepository<TEntity> repository )
        {
            _repository = repository;
        }

        #endregion

        #region Validation

        public abstract ServiceResult Validate( TEntity model );

        #endregion

        #region Query Methods

        public virtual Task<TEntity> GetAsync( int id )
        {
            return _repository.GetAsync( id );
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        #endregion

        #region CRUD Methods

        public virtual async Task<ServiceResult> CreateAsync( TEntity item )
        {
            var validationResult = Validate( item );

            if ( !validationResult.Succeeded )
            {
                return validationResult;
            }

            try
            {
                await _repository.CreateAsync( item );
            }
            catch ( DbUpdateException e )
            {
                return ServiceResult.Failed( ServiceErrorType.Unknown, e );
            }

            return ServiceResult.Success;
        }

        public virtual async Task<ServiceResult> DeleteAsync( TEntity item )
        {
            var validationResult = Validate( item );

            if ( !validationResult.Succeeded )
            {
                return validationResult;
            }

            try
            {
                await _repository.DeleteAsync( item );
            }
            catch ( DbUpdateException e )
            {
                return ServiceResult.Failed( ServiceErrorType.Unknown, new ServiceError( string.Empty, e ) );
            }

            return ServiceResult.Success;
        }

        public virtual async Task<ServiceResult> EditAsync( TEntity item )
        {
            try
            {
                await _repository.EditAsync( item );
            }
            catch ( Exception e )
            {
                return ServiceResult.Failed( ServiceErrorType.Unknown, e );
            }

            return ServiceResult.Success;
        }

        #endregion
    }
}
