using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class PatternRepository : IPatternsRepository
    {
        public IEnumerable<Pattern> GetPatterns()
        {
            var patterns = new List<Pattern>
                             {
                                 new Pattern {Id = 1, Name = "Pattern One", Description = "Pattern One Description"},
                                 new Pattern {Id = 2, Name = "Pattern Two", Description = "Pattern Two Description"}
                             };
            return patterns;
        }
    }
}
