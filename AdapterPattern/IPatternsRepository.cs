using System.Collections.Generic;

namespace AdapterPattern
{
    public interface IPatternsRepository
    {
        IEnumerable<Pattern> GetPatterns();
    }
}