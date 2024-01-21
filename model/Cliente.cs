using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoDS.model
{
    class Cliente
    {
		// Atributos
		private int idCliente;
		private String nome;
		private String cnpj;
		private String telefone;
		private String email;
		private String endereco;

		// Getters e Setters
		public int getIdCliente()
		{
			return idCliente;
		}

		public void setIdCliente(int idCliente)
		{
			this.idCliente = idCliente;
		}

		public String getNome()
		{
			return nome;
		}

		public void setNome(String nome)
		{
			this.nome = nome;
		}

		public String getCnpj()
		{
			return cnpj;
		}

		public void setCnpj(String cnpj)
		{
			this.cnpj = cnpj;
		}

		public String getTelefone()
		{
			return telefone;
		}

		public void setTelefone(String telefone)
		{
			this.telefone = telefone;
		}

		public String getEmail()
		{
			return email;
		}

		public void setEmail(String email)
		{
			this.email = email;
		}

		public String getEndereco()
		{
			return endereco;
		}

		public void setEndereco(String endereco)
		{
			this.endereco = endereco;
		}
	}
}
