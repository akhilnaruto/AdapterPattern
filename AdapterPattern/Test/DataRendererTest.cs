using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Test
{
    [TestClass]
    public class DataRendererTest
    {
        [TestMethod]
        public void RenderOneRowGivenStubDataAdapter()
        {
            var myRenderer = new DataRenderer(new StubDbAdapter());

            var writer = new StringWriter();
            myRenderer.Render(writer);

            string result = writer.ToString();
            Console.Write(result);

            int lineCount = result.Count(c => c == '\n');
            Assert.AreEqual(3, lineCount);
        }

        [TestMethod]
        public void RenderTwoRowsGivenOleDbDataAdapter()
        {
            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("SELECT * FROM Pattern");
            adapter.SelectCommand.Connection =
                new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=f:\Naruto Images\Sample.mdf;Integrated Security=True;Connect Timeout=30");
            var myRenderer = new DataRenderer(adapter);

            var writer = new StringWriter();
            myRenderer.Render(writer);

            string result = writer.ToString();
            Console.Write(result);

            int lineCount = result.Count(c => c == '\n');
            Assert.AreEqual(4, lineCount);
        }

    }
}
