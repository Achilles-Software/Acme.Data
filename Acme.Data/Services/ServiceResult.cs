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

namespace Achilles.Acme.Data.Services
{
    public class ServiceResult
    {
        #region Fields

        private static readonly ServiceResult _success = new ServiceResult( true );

        #endregion

        #region Constructors

        private ServiceResult( bool success )
        {
            Succeeded = success;
        }

        public ServiceResult( ServiceErrorType errorType, ServiceError error )
        {
            Succeeded = false;
            ErrorType = errorType;
            Errors = new ServiceErrors();

            Errors.AddError( error );
        }

        public ServiceResult( ServiceErrorType errorType, ServiceErrors errors )
        {
            Succeeded = false;
            ErrorType = errorType;
            Errors = errors;
        }

        #endregion

        #region Properties

        public ServiceErrors Errors { get; private set; }

        public ServiceErrorType ErrorType { get; private set; }

        public bool Succeeded { get; private set; }

        public static ServiceResult Success
        {
            get
            {
                return _success;
            }
        }

        public static ServiceResult Failed( ServiceErrorType errorType, Exception e = null )
        {
            return new ServiceResult( errorType, new ServiceError( string.Empty, e ) );
        }

        public static ServiceResult Failed( ServiceErrorType errorType, ServiceError error = null )
        {
            return new ServiceResult( errorType, error );
        }

        public static ServiceResult Failed( ServiceErrorType errorType, ServiceErrors errors = null )
        {
            return new ServiceResult( errorType, errors );
        }

        #endregion
    }
}
