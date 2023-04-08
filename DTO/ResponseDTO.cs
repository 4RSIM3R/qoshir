namespace Qoshir.DTO
{
    public sealed record ResponseDTO<TData>(string message, TData data);
}
