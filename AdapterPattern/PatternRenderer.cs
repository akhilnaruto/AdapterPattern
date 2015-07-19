using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class PatternRenderer : IRenderer
    {
        public IList<Pattern> ListPatterns(IPatternsRepository patternRepository)
        {
            return patternRepository.GetPatterns().ToList();
        }

        public void Render(TextWriter writer)
        {

        }
    }
}
