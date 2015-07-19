using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class PatternRenderer : IRenderer
    {
        private readonly IDbDataAdapter _dataAdapter;
        private IList<Pattern> ListPatterns(IPatternsRepository patternRepository)
        {
            return patternRepository.GetPatterns().ToList();
        }

        public PatternRenderer(IDbDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }
        public void Render(TextWriter writer)
        {
           var  _dataRenderer = new DataRenderer(_dataAdapter);
            _dataRenderer.Render(writer);
        }
    }
}
