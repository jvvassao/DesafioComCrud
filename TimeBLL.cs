using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class TimeBLL
    {
        public static void conecta()
        {
            TimeDAL.conecta();
        }

        public static void desconecta()
        {
            TimeDAL.desconecta();
        }

        public static void validaCodigo(Time umtime, char op)
        {
            Erro.setErro(false);
            if(umtime.getCodigo().Equals("")) 
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            TimeDAL.consultaUmTime(umtime);
            if (op == 'c')
                TimeDAL.consultaUmTime(umtime);
            else
                TimeDAL.deletaUmTime(umtime);
        }
        public static void validaDados(Time umTime, char op) 
        {
            Erro.setErro(false);
            if (umTime.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (umTime.getTime().Equals(""))
            {
                Erro.setMsg("O nome do time é de preenchimento obrigatório!");
                return;
            }
            if (umTime.getDivisao().Equals(""))
            {
                Erro.setMsg("A divisao é de preenchimento obrigatório!");
                return;
            }
            if (umTime.getLocalidade().Equals(""))
            {
                Erro.setMsg("A localidade é de preenchimento obrigatório!");
                return;
            }

           // TimeDAL.inseriUmTime(umTime);
            if (op == 'i')
            TimeDAL.inseriUmTime(umTime);
            else
            TimeDAL.atualizaUmTime(umTime);

        }
    }
}
