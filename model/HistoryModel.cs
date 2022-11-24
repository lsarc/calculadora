using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
