using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.Domain.errors;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace backend_template_net_core.configuration
{
    public static class HttpResponseCustomHelper
    {
        public static ApiResponse<T> Success<T>(T data, string message)
        {
            return new ApiResponse<T> { StatusCode = (int)HttpStatusCode.OK, Data = data, Message = message };
        }

        public static ApiResponse<T> Created<T>(T data)
        {
            return new ApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Data = default,
                Message = data?.ToString()
            };
        }

        public static ApiResponse<T> CreateErrorResponse<T>(object error)
        {
            if (error is CustomError customError)
            {
                
                switch (customError.statusCode)
                {
                    case (int)HttpStatusCode.BadRequest:
                        return BadRequest<T>(customError);
                    default:
                        return InternalServerError<T>(customError);
                }
                
            }
            return InternalServerError<T>(error);
        }

        public static ApiResponse<T> InternalServerError<T>(object error)
        {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }
            return new ApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Data = default,
                Message = error.ToString()
            };
        }
        public static ApiResponse<T> BadRequest<T>(object error)
        {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
            
        }

        public static ApiResponse<T> Unathorized<T>(object error)
        {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
        }

        public static ApiResponse<T> Forbiden<T>(object error)
        {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
        }
        public static ApiResponse<T> NotFound<T>(object error)
        {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
        }
        public static ApiResponse<T> MethodNotAllowed<T>(object error) {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
        }
        public static ApiResponse<T> UnsupportedMediType<T>(object error)
        {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
        }
        public static ApiResponse<T> TooManyRequest<T>(object error) {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
        }
        public static ApiResponse<T> UnprocesableEntity<T>(object error)
        {
            if (error is CustomError customError)
            {
                return new ApiResponse<T> { StatusCode = customError.statusCode, Data = default, Message = customError.Message };
            }

            return InternalServerError<T>(error);
        }
    }
}
