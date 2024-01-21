using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoDS.dao;

namespace TrabalhoDS.model
{
    class Controle
    {
        public bool tem;
        public String mensagem = "";
        

        public bool acessar(String loginUsuario, String senhaUsuario)
        {
            loginDAO lg = new loginDAO();
            tem = lg.verificarLogin(loginUsuario, senhaUsuario);

            
            return tem;
        }

        public String cadastrar(String loginUsuario, String senhaUsuario, String confSenhaUsuario)
        {
            loginDAO lg = new loginDAO();
            this.mensagem = lg.cadastrar(loginUsuario, senhaUsuario, confSenhaUsuario);
            if (lg.tem)
            {
                this.tem = true;
            }
            return mensagem;

        }


    }
}
