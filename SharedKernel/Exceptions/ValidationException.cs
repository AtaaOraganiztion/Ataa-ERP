using System;
using System.Collections.Generic;

namespace SharedKernel.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<string> failures) : this()
        {
            Errors = new List<string>(failures);
        }
    }
}
