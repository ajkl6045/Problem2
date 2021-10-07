using Problem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Data.Services.Interfaces
{
   public interface IReadingService
    {
        IEnumerable<Reading> GetReadingAll();
        IEnumerable<Reading> GetByRange(DateTime start,DateTime end);
    }
}
