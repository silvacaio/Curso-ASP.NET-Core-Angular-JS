namespace CS.Eventos.IO.Domain.Core.Events
{
    public interface IHandler<in TEntity> where TEntity : Message
    {
        void Handle(TEntity message);
    }
}
