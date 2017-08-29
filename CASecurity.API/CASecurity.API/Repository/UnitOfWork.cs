using CASecurity.API.Migrations;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace CASecurity.API.Repository
{
    /// <summary>
    /// Default implementation of the IUnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;//new GpsTrackingContext();
        }

        protected DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Commit the In-memory changes of the DbContext to the backend database.
        /// </summary>
        public void Commit()
        {
            try
            {
                if (this.context == null) throw new NullReferenceException("context");

                this.context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            
        }
    }
}