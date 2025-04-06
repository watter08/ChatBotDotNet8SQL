using System.Net;

namespace ImproveAbilityInSqlAndC_.Application.DTOs
{
    public class ApiResponse<T>
    {
        public bool isSuccess { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public T? data { get; set; }

        public ApiResponse(bool isSuccess, HttpStatusCode statusCode, string message, T? data = default)
        {
            this.isSuccess = isSuccess;
            this.statusCode = statusCode;
            this.message = message;
            this.data = data;
        }

        public static ApiResponse<T> Success(T data, string message = "Operación exitosa", HttpStatusCode statusCode = HttpStatusCode.OK) =>
            new ApiResponse<T>(true, statusCode, message, data);

        public static ApiResponse<T> Error(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
            new ApiResponse<T>(false, statusCode, message);
    }
}
