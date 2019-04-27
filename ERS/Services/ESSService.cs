using ERS.Data;
using ERS.Models;
using System;
using System.Linq;

namespace ERS.Services
{
    public class ESSService : IESSService
    {
        private readonly ApplicationDbContext _context;

        public ESSService(ApplicationDbContext context)
        {
            _context = context;
        }        

        public string GenerateESSCode()
        {
            string month = DateTime.UtcNow.ToString("MM");
            string year = DateTime.UtcNow.Year.ToString();
            ESSInfo lastEssInfo = _context.ESSInfos.LastOrDefault();
            int essNumber = 1;
            if (lastEssInfo != null)
            {
                essNumber = int.Parse(lastEssInfo.ESSCode.Substring(6));
            }

            string essCode = month + year + ++essNumber;

            return essCode;
        }
    }
}
