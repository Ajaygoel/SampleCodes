#region usings

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.Practices.Unity;
using OnlineCoding.Domain.Dto;
using OnlineCoding.IDal.IUnitOfWork;

#endregion

namespace OnlineCoding.Bal
{
    public abstract class BalBase : IDisposable
    {
        #region Constructors

        protected BalBase(IUnitOfWork unitOfWork)
        {
            Unit = unitOfWork;
            UnityContainer = new UnityContainer();
            UnityBootstrapper.RegisterTypes(UnityContainer);
        }

        #endregion

        #region Private Functions

        private string GetExceptionString(Exception exception)
        {
            if (exception.InnerException == null)
            {
                var error = exception.Message;
                return error;
            }
            return GetExceptionString(exception.InnerException);
        }

        #endregion

        ~BalBase()
        {
            Dispose(false);
        }

        #region Fields

        private bool _disposed;
        protected IUnitOfWork Unit;

        protected IUnityContainer UnityContainer;

        #endregion

        #region Public Methods

        //To Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //To Dispose
        public void Dispose(bool disposing)
        {
            if (!_disposed & disposing)
            {
                Unit?.Dispose();
                UnityContainer?.Dispose();
            }
            _disposed = true;
        }

        #endregion

        #region Protected Methods

        protected virtual BaseDto Success()
        {
            return Success<BaseDto>();
        }

        protected virtual T Success<T>() where T : BaseDto, new()
        {
            return new T
            {
                IsSuccess = true
            };
        }

        protected virtual T Failure<T>(List<ValidationResult> validationResults) where T : BaseDto, new()
        {
            return new T
            {
                Errors = validationResults.Select(x => new Error {ErrorMessage = x.ErrorMessage}).ToList(),
                IsSuccess = false
            };
        }

        protected BaseDto Failure(List<ValidationResult> validationResults)
        {
            return Failure<BaseDto>(validationResults);
        }

        protected virtual T Failure<T>(string errorMessage) where T : BaseDto, new()
        {
            return new T
            {
                Errors = new List<Error>
                {
                    new Error
                    {
                        ErrorMessage = errorMessage
                    }
                },
                IsSuccess = false
            };
        }

        protected BaseDto Failure(string errorMessage)
        {
            return Failure<BaseDto>(errorMessage);
        }

        protected T HandleException<T>(Exception exception) where T : BaseDto, new()
        {
            var validationException = exception as DbEntityValidationException;
            if (validationException != null)
            {
                return Exception<T>(validationException);
            }

            var valException = exception as ValidationException;
            if (valException != null)
            {
                return Exception<T>(valException);
            }

            var exceptionString = GetExceptionString(exception);
            return new T
            {
                IsSuccess = false,
                Errors = new List<Error>
                {
                    new Error
                    {
                        ErrorMessage = exceptionString
                    }
                }
            };
        }

        private static T Exception<T>(Exception validationException) where T : BaseDto, new()
        {
            return new T
            {
                IsSuccess = false,
                Errors = new List<Error>
                {
                    new Error
                    {
                        ErrorMessage = validationException.Message
                    }
                }
            };
        }

        protected BaseDto HandleException(Exception exception)
        {
            return HandleException<BaseDto>(exception);
        }

        #endregion
    }
}