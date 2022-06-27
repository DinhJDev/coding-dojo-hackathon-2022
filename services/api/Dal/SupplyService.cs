using Hackathon.Core;
using Hackathon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Dal
{
    public class SupplyService : ICrud<Supply>
    {
        private readonly HackathonContext _context;

        public SupplyService(HackathonContext context)
        {
            this._context = context;
        }
        public void Create(Supply newT)
        {
            this._context.Supplies.Add(newT);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            Supply deletedOne = _context.Supplies.Where(p => p.Id == id).FirstOrDefault();
            if (deletedOne != null)
            {
                _context.Supplies.Remove(deletedOne);
            }
            _context.SaveChanges();
        }

        public List<Supply> GetAll()
        {
            return this._context.Supplies.ToList();
        }

        public Supply GetOne(int id)
        {
            return _context.Supplies.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Supply updateT)
        {
            throw new NotImplementedException();
        }
    }
}
