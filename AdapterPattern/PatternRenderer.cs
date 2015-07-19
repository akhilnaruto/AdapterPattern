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
        private IList<Pattern> ListPatterns(IPatternsRepository patternRepository)
        {
            return patternRepository.GetPatterns().ToList();
        }
    
        public void Render(TextWriter writer)
        {
            var myDataSet = new DataSet();

            var myDataTable = new DataTable();
            myDataTable.Columns.Add(new DataColumn("Id", typeof(int)));
            myDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            myDataTable.Columns.Add(new DataColumn("Description", typeof(string)));

            var _patterns = ListPatterns(new PatternRepository());

            foreach (var pattern in _patterns)
            {
                var myRow = myDataTable.NewRow();
                myRow[0] = pattern.Id;
                myRow[1] = pattern.Name;
                myRow[2] = pattern.Description;
                myDataTable.Rows.Add(myRow);
            }
            myDataSet.Tables.Add(myDataTable);
            myDataSet.AcceptChanges();


            foreach (DataTable table in myDataSet.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    writer.Write(column.ColumnName.PadRight(20) + " ");
                }
                writer.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString().PadRight(20) + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
