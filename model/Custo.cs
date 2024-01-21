using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoDS.model
{
    class Custo
    {
		// Atributos
		private int idCusto;
		private int idServico;
		private double valorCusto;
		private String descricaoCusto;

		// Getters e Setters
		public int getIdCusto()
		{
			return idCusto;
		}

		public void setIdCusto(int idCusto)
		{
			this.idCusto = idCusto;
		}

		public int getIdServico()
		{
			return idServico;
		}

		public void setIdServico(int idServico)
		{
			this.idServico = idServico;
		}

		public double getValorCusto()
		{
			return valorCusto;
		}

		public void setValorCusto(double valorCusto)
		{
			this.valorCusto = valorCusto;
		}

		public String getDescricaoCusto()
		{
			return descricaoCusto;
		}

		public void setDescricaoCusto(String descricaoCusto)
		{
			this.descricaoCusto = descricaoCusto;
		}
	}
}
