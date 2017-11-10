#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

#endregion

namespace Achilles.Acme.Data.Services
{
    public class ServiceErrors : IEnumerable<ServiceError>
    {
        List<ServiceError> _errors = new List<ServiceError>();

        public IReadOnlyCollection<ServiceError> Errors => new ReadOnlyCollection<ServiceError>( _errors );

        public void AddError( ServiceError error )
        {
            _errors.Add( error );
        }

        public void AddError( string key, Exception exception )
        {
            if ( key == null )
            {
                throw new ArgumentNullException( nameof( key ) );
            }

            if ( exception == null )
            {
                throw new ArgumentNullException( nameof( exception ) );
            }

            _errors.Add( new ServiceError( key, exception ) );
        }

        public void AddError( string key, Exception exception, string errorMessage )
        {
            if ( key == null )
            {
                throw new ArgumentNullException( nameof( key ) );
            }

            if ( exception == null )
            {
                throw new ArgumentNullException( nameof( exception ) );
            }

            if ( errorMessage == null )
            {
                throw new ArgumentNullException( nameof( errorMessage ) );
            }

            _errors.Add( new ServiceError( key, exception ) );
        }

        public void AddError( string key, string errorMessage )
        {
            if ( key == null )
            {
                throw new ArgumentNullException( nameof( key ) );
            }

            if ( errorMessage == null )
            {
                throw new ArgumentNullException( nameof( errorMessage ) );
            }

            _errors.Add( new ServiceError( key, errorMessage ) );
        }

        public IEnumerator<ServiceError> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Errors.GetEnumerator();
        }
    }
}
