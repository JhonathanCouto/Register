using Microsoft.Extensions.Localization;

namespace Register.Application;

public sealed class ResultService : IResultService
{
    public Result Error() => Result.Error();

    public Result Error(string message) => Result.Error(message);

    public Result<T> Error<T>(string message) => Result<T>.Error(message);

    public Result Success() => Result.Success();

    public Result<T> Success<T>(T value) => Result<T>.Success(value);
}