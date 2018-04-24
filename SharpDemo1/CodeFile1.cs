using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MySelect
{
    internal MySelect()
    {
        names = new List<string>();
        bydef = new List<string>() { "Количество", "Сумма" };
        selectedcolumns = new List<int>();

    }

    internal List<string> names;

    internal List<string> bydef;

    internal List<int> selectedcolumns;

    internal string standartquery()
    {
        return "SELECT Дата, Организация, Город, Страна, Менеджер, Количество, Сумма FROM Organization";
    }

    internal string query(string nametable)
    {
        StringBuilder sb = new StringBuilder();
        
        sb.Append(string.Format("SELECT {0}, ", string.Join(",", names)));

        for (int i = 0; i < bydef.Count; i++)
        {
            sb.Append(string.Format(" SUM({0}) AS {0}", bydef[i]));
            if (i != bydef.Count - 1)
                sb.Append(", ");
        }
        
        sb.Append(string.Format(" FROM {0} GROUP BY {1};", nametable, string.Join(",", names)));

        return sb.ToString();
    }
}