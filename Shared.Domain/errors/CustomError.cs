using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.errors
{
    public class CustomError : Exception
    {
        public string message { get; set; }
        public int statusCode { get; set; }
        public CustomError(int statusCode, string message) : base(message)
        {
            this.statusCode = statusCode;

        }

        public static CustomError badRequest(string message)
        {
            return new CustomError(400, message);
        }
        public static CustomError unauthorized(string message)
        {
            return new CustomError(401, message);
        }
        public static CustomError forbidden(string message)
        {
            return new CustomError(403, message);
        }
        public static CustomError notFound(string message)
        {
            return new CustomError(404, message);
        }
        public static CustomError methodNotAllowed(string message)
        {
            return new CustomError(405, message);
        }
        public static CustomError unsupportedMediType(string message)
        {
            return new CustomError(415, message);
        }
        public static CustomError unprocesableEntity(string message)
        {
            return new CustomError(422, message);
        }
        public static CustomError tooManyRequests(string message)
        {
            return new CustomError(429, message);
        }
        public static CustomError internalServerError(string message)
        {
            return new CustomError(500, message);
        }
        public static CustomError wrapperError(string message, int status_num)
        {
            return new CustomError(status_num, message);
        }

    }
}
