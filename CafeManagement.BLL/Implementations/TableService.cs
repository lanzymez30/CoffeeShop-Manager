using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.BLL.Interfaces;
using CafeManagement.DAL.Repositories;
using CafeManagement.Entity.Entities;

namespace CafeManagement.BLL.Implementations
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _uow;

        public TableService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Table> GetAll()
        {
            return _uow.Tables.GetAll();
        }

        public IEnumerable<Table> GetAvailableTables()
        {
            return _uow.Tables.GetAll(t => t.Status == "Available");
        }

        public Table? GetById(int id)
        {
            return _uow.Tables.GetById(id);
        }

        public void UpdateTableStatus(int tableId, string status)
        {
            var table = _uow.Tables.GetById(tableId);
            if (table == null)
                throw new InvalidOperationException("Không tìm thấy bàn");

            table.Status = status;
            _uow.Tables.Update(table);
            _uow.Save();
        }

        public void Create(Table table)
        {
            _uow.Tables.Insert(table);
            _uow.Save();
        }

        public void Update(Table table)
        {
            _uow.Tables.Update(table);
            _uow.Save();
        }

        public void Delete(int id)
        {
            _uow.Tables.Delete(id);
            _uow.Save();
        }
    }
}
