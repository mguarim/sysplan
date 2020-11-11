using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sysplan.Models
{
    public class ClienteDAL : IClienteDAL
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Cliente;Integrated Security=True;"; 

        public IEnumerable<Cliente> GetAllCliente()
        {
            List<Cliente> lstcliente = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Nome,Idade from Cliente", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(rdr["Id"]);
                    cliente.Nome = rdr["Nome"].ToString();
                    cliente.Idade = rdr["Idade"].ToString();

                    lstcliente.Add(cliente);
                }
                con.Close();
            }
            return lstcliente;
        }

        public void Addcliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into Cliente (Nome,Idade) Values(@Nome, @Idade)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Idade", cliente.Idade);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Updatecliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update Cliente set Nome = @Nome, Idade = @Idade where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", cliente.Id);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Idade", cliente.Idade);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Cliente Getcliente(int? id)
        {
            Cliente cliente = new Cliente();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Cliente WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cliente.Id = Convert.ToInt32(rdr["Id"]);
                    cliente.Nome = rdr["Nome"].ToString();
                    cliente.Idade = rdr["Idade"].ToString();
                }
            }
            return cliente;
        }
        public void Deletecliente(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Cliente where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
