namespace ProjetoSistemaLoja.Services
{
    public static class Util
    {
        public static int NextId(List<int> ids)
        {
            int id = 1;
            ids.Sort();
            foreach(var i in ids)
            {
                if (id == i)
                    id++;
                else
                {
                    break;
                }
            }
            return id;
        }
    }
}
