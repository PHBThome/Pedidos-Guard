using Projeto_Sistema_Loja.models;

namespace Projeto_Sistema_Loja.controllers
{
    internal class TransportadoraController
    {
        private Transportadora[] transportadoras = new Transportadora[100];
        private int transportadoraCount = 0;

        public string AdicionarTransportadora(Transportadora novaTransportadora)
        {
            if (transportadoraCount >= transportadoras.Length)
                return "Número máximo de transportadoras atingido!";

            foreach (Transportadora t in transportadoras)
            {
                if (t == null) continue;
                if (t.Id == novaTransportadora.Id)
                    return "ID já existente!";
                if (t.Nome == novaTransportadora.Nome)
                    return "Nome já cadastrado!";
            }

            transportadoras[transportadoraCount++] = novaTransportadora;
            return "Transportadora cadastrada com sucesso!";
        }

        public string RemoverTransportadora(int id)
        {
            for (int i = 0; i < transportadoraCount; i++)
            {
                if (transportadoras[i].Id == id)
                {
                    for (int j = i; j < transportadoraCount - 1; j++)
                        transportadoras[j] = transportadoras[j + 1];

                    transportadoras[--transportadoraCount] = null;
                    return "Transportadora removida com sucesso!";
                }
            }
            return "Transportadora não encontrada!";
        }

        public Transportadora ObterTransportadoraPorId(int id)
        {
            foreach (Transportadora t in transportadoras)
            {
                if (t != null && t.Id == id)
                    return t;
            }
            return null;
        }

        public Transportadora[] ObterTodasTransportadoras()
        {
            Transportadora[] lista = new Transportadora[transportadoraCount];
            Array.Copy(transportadoras, lista, transportadoraCount);
            return lista;
        }

        public string EditarTransportadora(int id, Transportadora dadosAtualizados)
        {
            for (int i = 0; i < transportadoraCount; i++)
            {
                if (transportadoras[i].Id == id)
                {
                    transportadoras[i] = dadosAtualizados;
                    return "Transportadora atualizada com sucesso!";
                }
            }
            return "Transportadora não encontrada!";
        }
    }
}
