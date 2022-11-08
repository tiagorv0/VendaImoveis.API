namespace VendaImoveis.API.Response
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public int? TotalLinhas { get; private set; }

        public Result(T data, int? totalLinhas)
        {
            Data = data;
            TotalLinhas = totalLinhas;
        }
    }
}
