using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Dal.Interfaces
{
    public interface ICrud<T>
    {
        public List<T> GetAll();
        public T GetOne(int id);
        public void Create(T newT);
        public void Delete(int id);
        public void Update(T updateT);

    }
}
