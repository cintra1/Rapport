using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoDS.model
{
    class Pedido
    {
		// Atributos
		private int idPedido;
		private int idCliente;
		private DateTime dataVenda;
		private String profissionalResponsavel;

		// Getters e Setters
		public int getIdPedido()
		{
			return idPedido;
		}

		public void setIdPedido(int idPedido)
		{
			this.idPedido = idPedido;
		}

		public int getIdCliente()
		{
			return idCliente;
		}

		public void setIdCliente(int idCliente)
		{
			this.idCliente = idCliente;
		}

		public DateTime getDataVenda()
		{
			return dataVenda;
		}

		public void setDataVenda(DateTime dataVenda)
		{
			this.dataVenda = dataVenda;
		}

		public String getProfissionalResponsavel()
		{
			return profissionalResponsavel;
		}

		public void setProfissionalResponsavel(String profissionalResponsavel)
		{
			this.profissionalResponsavel = profissionalResponsavel;
		}
	}
}
