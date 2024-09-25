using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace FandomMSSQL
{
    internal class LinqToSqlClass
    {
        static string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;" +
            "Initial Catalog=Fandom;" +
            "Integrated Security=True;";
        static public List<string> GetNames(string _pattern = "<empty>")
        {
            List<string> result = new List<string>();
            DataContext dc = new DataContext(connectionString);
            Table<PersonsClass> _persons = dc.GetTable<PersonsClass>();
            if (_pattern.Equals("<empty>"))
            {
                foreach (var item in _persons)
                {
                    result.Add(item.Name);
                }
            }
            else 
            {
                var tmpSequence = from _person in _persons
                                  where _person.Name.Contains(_pattern)
                                  select _person;
                foreach(var item in tmpSequence)
                {
                    result.Add(item.Name);
                }
            }
            return result;
        }

        static public bool ReplaceName(string _oldName, string _newName)
        {
            bool IsFound = false;
            DataContext dc = new DataContext(connectionString);
            Table<PersonsClass> _persons = dc.GetTable<PersonsClass>();
            foreach (var item in _persons)
            {
                if(item.Name == _oldName)
                {
                    IsFound = true;
                    item.Name = _newName;
                }
            }
            dc.SubmitChanges();
            return IsFound;
        }
    }
}
