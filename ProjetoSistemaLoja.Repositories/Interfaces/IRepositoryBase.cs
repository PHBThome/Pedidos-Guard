namespace ProjetoSistemaLoja.Repositories.Interfaces;

public interface IRepositoryBase<TipoGenerico> where TipoGenerico : class 
{   
    public void Save<T>(T entity);
    public void Update<T>(T entity);
    public void Remove<T>(int id);
    public T GetById<T>(int id);
    public IList<T> GetAll<T>();
}
