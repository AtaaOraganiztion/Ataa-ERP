using System.Collections.Generic;

namespace SharedKernel.Results
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        protected Result()
        {
            Errors = new List<string>();
        }

        public static Result Success(string message = "Operation completed successfully")
        {
            return new Result { IsSuccess = true, Message = message };
        }

        public static Result Failure(string error)
        {
            return new Result { IsSuccess = false, Errors = new List<string> { error } };
        }

        public static Result Failure(List<string> errors)
        {
            return new Result { IsSuccess = false, Errors = errors };
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        public static Result<T> Success(T data, string message = "Operation completed successfully")
        {
            return new Result<T> { IsSuccess = true, Data = data, Message = message };
        }

        public static new Result<T> Failure(string error)
        {
            return new Result<T> { IsSuccess = false, Errors = new List<string> { error } };
        }

        public static new Result<T> Failure(List<string> errors)
        {
            return new Result<T> { IsSuccess = false, Errors = errors };
        }
    }
}
