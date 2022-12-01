using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace calculadora.model
{
    public class HistoryModel
    {
        private List<string> operacoes;

        public HistoryModel()
        {
            operacoes = new List<string>();
        }

        public void AddToHistory(string operation)
        {
            operacoes.Add(operation.ToString());
        }

        public List<string> getHistory()
        {
            return operacoes;
        }

        public void Clean()
        {
            operacoes.Clear();
        }

        public void SaveHistory()
        {
            using (StreamWriter writer = new StreamWriter(@".\history.sav"))
            {
                foreach (var element in this.getHistory())
                {
                    writer.WriteLine(element);
                }
                    
            }
        }
        public void RestoreHistory()
        {
            try
            {
                string[] readText = File.ReadAllText(@".\history.sav").Split("\n ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < readText.Length; i++)
                {
                    operacoes.Add(readText[i]);
                }
            }
            catch
            {
                throw new Exception("Erro de Leitura");
            }

        }
    }
}
