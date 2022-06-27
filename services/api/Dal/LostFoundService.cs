using Hackathon.Core;
using Hackathon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Dal
{
    public class LostFoundService : ICrud<LostFound>
    {

        private readonly HackathonContext _context;

        public LostFoundService(HackathonContext context)
        {
            this._context = context;
        }
        public void Create(LostFound newT)
        {
            this._context.LostFounds.Add(newT);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            LostFound deletedOne = _context.LostFounds.Where(p => p.Id == id).FirstOrDefault();
            if (deletedOne != null)
            {
                _context.LostFounds.Remove(deletedOne);
            }
            _context.SaveChanges();
        }

        public List<LostFound> GetAll()
        {
            return this._context.LostFounds.ToList();
        }

        public LostFound GetOne(int id)
        {
            return _context.LostFounds.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(LostFound updateT)
        {
            throw new NotImplementedException();
        }
    }
}
