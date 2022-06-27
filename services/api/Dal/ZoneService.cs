using Hackathon.Core;
using Hackathon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Dal
{
    public class ZoneService : ICrud<HotZone>
    {
        private readonly HackathonContext _context;

        public ZoneService(HackathonContext context)
        {
            this._context = context;
        }
        public void Create(HotZone newT)
        {
            _context.HotZones.Add(newT);
            _context.SaveChanges();
        }

        public void Delete(int id)
        { 
            HotZone deletedOne = _context.HotZones.Where(p => p.Id == id).FirstOrDefault(); 
            if (deletedOne != null)
            {
                _context.HotZones.Remove(deletedOne);
            }
            _context.SaveChanges();
        }

        public List<HotZone> GetAll()
        {
            return this._context.HotZones.ToList();
        }

        public HotZone GetOne(int id)
        {
            return _context.HotZones.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(HotZone updateT)
        {
            throw new NotImplementedException();
        }
    }
}
