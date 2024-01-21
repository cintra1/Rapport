using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoDS.model
{
    class DetalhesPedido
    {
		// Atributos
		private int idServico;
		private int idPedido;
		private int statusPedido;


		// Getters e Setters
		public int getIdServico()
		{
			return idServico;
		}

		public void setIdServico(int idServico)
		{
			this.idServico = idServico;
		}

		public int getIdPedido()
		{
			return idPedido;
		}

		public void setIdPedido(int idPedido)
		{
			this.idPedido = idPedido;
		}

		public int getStatusPedido()
		{
			return statusPedido;
		}

		public void setStatusPedido(int statusPedido)
		{
			this.statusPedido = statusPedido;
		}
	}
}
