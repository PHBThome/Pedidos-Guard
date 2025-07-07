using System.Text.Json;
using ProjetoSistemaLoja.Repositories.Interfaces;

namespace ProjetoSistemaLoja.Repositories.Framework
{
    public class RepositoryBaseArray<TipoGenerico> : IRepositoryBase<TipoGenerico> where TipoGenerico : class
    {
        protected virtual string FilePath { get; set; }

        public void Save<T>(T entity)
        {
            T[] entities;

            if (File.Exists(FilePath))
            {
                var jsonString = File.ReadAllText(FilePath);
                entities = JsonSerializer.Deserialize<T[]>(jsonString) ?? Array.Empty<T>();
            }
            else
            {
                entities = Array.Empty<T>();
            }

            // Adicionar novo elemento ao array
            Array.Resize(ref entities, entities.Length + 1);
            entities[entities.Length - 1] = entity;

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
            var entities = JsonSerializer.Deserialize<T[]>(jsonString) ?? Array.Empty<T>();

            var prop = typeof(T).GetProperty("Id");
            if (prop == null)
            {
                throw new InvalidOperationException("A entidade precisa ter uma propriedade 'Id'.");
            }

            var id = (int)prop.GetValue(entity);
            var index = Array.FindIndex(entities, e => (int)prop.GetValue(e) == id);

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
            var entities = JsonSerializer.Deserialize<T[]>(jsonString) ?? Array.Empty<T>();

            var prop = typeof(T).GetProperty("Id");
            if (prop == null)
            {
                throw new InvalidOperationException("A entidade precisa ter uma propriedade 'Id'.");
            }

            var filtered = entities.Where(e => (int)prop.GetValue(e) != id).ToArray();

            var updatedJson = JsonSerializer.Serialize(filtered, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, updatedJson);
        }

        public T GetById<T>(int id)
        {
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("Arquivo JSON não encontrado.");
            }

            var jsonString = File.ReadAllText(FilePath);
            var entities = JsonSerializer.Deserialize<T[]>(jsonString) ?? Array.Empty<T>();

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
                return Array.Empty<T>();
            }

            var jsonString = File.ReadAllText(FilePath);
            var entities = JsonSerializer.Deserialize<T[]>(jsonString) ?? Array.Empty<T>();
            return entities;
        }
    }
}
