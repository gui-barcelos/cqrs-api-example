namespace CQRSExample.ProductApi.Business.Dtos.Command.Response
{
    public class CommandResponseDto
    {
        private CommandResponseDto() { }

        private CommandResponseDto(string failureReason)
        {
            FailureReason = failureReason;
        }

        public string FailureReason { get; }
        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public static CommandResponseDto Success { get; } = new CommandResponseDto();

        public static CommandResponseDto Fail(string reason)
        {
            return new CommandResponseDto(reason);
        }
    }
}
