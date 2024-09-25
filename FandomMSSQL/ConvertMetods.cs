using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FandomMSSQL
{
    internal class ConvertMetods
    {
        public static DataTable ListOfString2DataSet(List<string> _lst)
        {
            //DataSet result = new DataSet();
            DataTable result = new DataTable();
            result.Columns.Add("Имя"); // Добавляем колонку
            foreach (string s in _lst)
            {               
                result.Rows.Add(s);          
            }                     
            return result;
        }
    }
}
