using System.Text.Json;
using ProjetoSistemaLoja.Repositories.Interfaces;

namespace ProjetoSistemaLoja.Repositories.Framework;

public class RepositoryBaseList<TipoGenerico> : IRepositoryBase<TipoGenerico> where TipoGenerico : class
{

    private readonly string FilePath;

    public RepositoryBaseList(string filePath)
    {
        FilePath = filePath;
    }

    public void Save<T>(T entity)
    {
        List<T> entities;

        if (File.Exists(FilePath))
        {
            var jsonString = File.ReadAllText(FilePath);
            entities = JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
        }
        else
        {
            entities = new List<T>();
        }
        entities.Add(entity);

        var json = JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
    public void Update<T>(T entity)
    {
        if (!File.Exists(FilePath))
        {
            throw new FileNotFoundException("Arquivo JSON não encontrado.");
        }

        var jsonString = File.ReadAllText(FilePath);
        var entities = JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();

        var prop = typeof(T).GetProperty("Id");

        if (prop == null)
        {
            throw new InvalidOperationException("A entidade precisa ter uma propriedade 'Id'.");
        }

        var id = (int)prop.GetValue(entity);
        var index = entities.FindIndex(e => (int)prop.GetValue(e) == id);

        if (index >= 0)
        {
            entities[index] = entity;

            var updatedJson = JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, updatedJson);
        }
    }

    public void Remove<T>(int id)
    {
        if (!File.Exists(FilePath))
        {
            return;
        }

        var jsonString = File.ReadAllText(FilePath);
        var entities = JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
        
        var prop = typeof(T).GetProperty("Id");

        entities = entities.Where(e => (int)prop.GetValue(e) != id).ToList();

        var updatedJson = JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, updatedJson);
    }

    public T? GetById<T>(int id)
    {
        if (!File.Exists(FilePath))
        {
            throw new FileNotFoundException("Arquivo JSON não encontrado.");
        }

        var jsonString = File.ReadAllText(FilePath);
        var entities = JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
        var prop = typeof(T).GetProperty("Id");

        if (prop == null)
        {
            throw new InvalidOperationException("A entidade precisa ter uma propriedade 'Id'.");
        }

        return entities.FirstOrDefault(e => (int)prop.GetValue(e) == id);
    }

    public IList<T> GetAll<T>()
    {
        if (!File.Exists(FilePath))
        {
            return new List<T>();
        }
        var jsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
    }

}
