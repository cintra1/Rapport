using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoDS.model
{
    class Usuario
    {
		// Atributos
		private int idUsuario;
		private String loginUsuario;
		private String senhaUsuario;

		// Getters e Setters
		public int getIdUsuario()
		{
			return idUsuario;
		}

		public void setIdUsuario(int idUsuario)
		{
			this.idUsuario = idUsuario;
		}

		public String getLoginUsuario()
		{
			return loginUsuario;
		}

		public void setLoginUsuario(String loginUsuario)
		{
			this.loginUsuario = loginUsuario;
		}

		public String getSenhaUsuario()
		{
			return senhaUsuario;
		}

		public void setSenhaUsuario(String senhaUsuario)
		{
			this.senhaUsuario = senhaUsuario;
		}
	}
}
