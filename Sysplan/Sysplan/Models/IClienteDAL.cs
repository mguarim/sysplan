using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sysplan.Models
{
    public interface IClienteDAL
    {
        IEnumerable<Cliente> GetAllCliente();
        void Addcliente(Cliente cliente);
        void Updatecliente(Cliente cliente);
        Cliente Getcliente(int? id);
        void Deletecliente(int? id);
    }
}
