namespace CQRSExample.ProductApi.Application.Dtos.Query.Response
{
    public class QueryResponseDto<T>
    {
        private QueryResponseDto() { }

        public QueryResponseDto(string failureReason)
        {
            FailureReason = failureReason;
        }

        public QueryResponseDto(T result)
        {
            Result = result;
        }

        public string FailureReason { get; }
        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);
        public T Result { get; }

        public static QueryResponseDto<T> Success(T result)
        {
            return new QueryResponseDto<T>(result);
        }

        public static QueryResponseDto<T> Fail(string reason)
        {
            return new QueryResponseDto<T>(reason);
        }
    }
}
