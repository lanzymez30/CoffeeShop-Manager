using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Entity.Entities;

namespace CafeManagement.BLL.Interfaces
{
    public interface ITableService
    {
        IEnumerable<Table> GetAll();
        IEnumerable<Table> GetAvailableTables();
        Table? GetById(int id);
        void UpdateTableStatus(int tableId, string status);
        void Create(Table table);
        void Update(Table table);
        void Delete(int id);
    }
}
