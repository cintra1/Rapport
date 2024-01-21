using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoDS.model
{
    class Servico
    {
		// Atributos
		private int idServico;
		private String nome;
		private double valorServico;

		// Getters e Setters
		public int getIdServico()
		{
			return idServico;
		}

		public void setIdServico(int idServico)
		{
			this.idServico = idServico;
		}

		public String getNome()
		{
			return nome;
		}

		public void setNome(String nome)
		{
			this.nome = nome;
		}

		public double getValorServico()
		{
			return valorServico;
		}

		public void setValorServico(double valorServico)
		{
			this.valorServico = valorServico;
		}
	}
}
