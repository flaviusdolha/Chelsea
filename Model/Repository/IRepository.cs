using System.Collections.Generic;
using Chelsea.Model.Domain.Ticket;

namespace Chelsea.Model.Repository
{
    public interface IRepository<T>
    {
        public void Create(T t);
        public List<T> GetAll();
        public List<T> GetAllOnParent(int parentId);
        public T FindById(int id);
        public void Update(T t);
        public void Delete(int id);
        public int GetNextId();
    }
}