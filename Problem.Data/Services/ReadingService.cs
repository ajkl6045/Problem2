using Problem2.Data.Services.Interfaces;
using Problem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Data.Services
{
    public class ReadingService : IReadingService
    {
        public readonly BuildingDbContext _context;
        public ReadingService(BuildingDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Reading> GetReadingAll()
        {
            return  _context.Readings.OrderBy(u=>u.Id).Take(100).OrderBy(u=>u.Id).ToList();
        }

        public IEnumerable<Reading> GetByRange(DateTime start, DateTime end)
        {
            return _context.Readings.Where(u=>u.TimeStamp >= start && u.TimeStamp<= end).OrderBy(u => u.Id).Take(100).OrderBy(u => u.Id).ToList();
        }
    }
}
