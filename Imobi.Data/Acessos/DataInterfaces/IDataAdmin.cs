namespace Imobi.Data.Acessos.DataInterfaces
{
    public interface IDataAdmin<T> : IDataCommand<T>, IDataQuery<T>
    {
    }
}
