using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
     class Time
     {
        private string codigo;
        private string time;
        private string divisao;
        private string localidade;

        public void setCodigo(string _codigo) { codigo = _codigo; }
        public void setTime(string _time) {  time = _time; }
        public void setDivisao(string _divisao) {  divisao = _divisao; }
        public void setLocalidade(string _localidade) { localidade = _localidade; }

        public string getCodigo() {  return codigo; }
        public string getTime() { return time; }
        public string getDivisao() {  return divisao; }
        public string getLocalidade() {  return localidade; }



     }
}
