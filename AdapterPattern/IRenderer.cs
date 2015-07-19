using System.IO;

namespace AdapterPattern
{
    public interface IRenderer
    {
        void Render(TextWriter writer);

    }
}