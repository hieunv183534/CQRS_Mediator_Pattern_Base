using System.Data;

namespace NOM.SMSGATEWAY.Domain._Base.Core
{
    public class DataTableSim
    {
        public DataTable dataTableSim()
        {
            var table = new DataTable();
            table.Columns.Add("COM", typeof(string));
            table.Columns.Add("Check", typeof(bool));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Numberphone", typeof(string));
            table.Columns.Add("Content", typeof(string));
            return table;
        }
        public DataTable dataTableMessages()
        {
            var table = new DataTable();
            table.Columns.Add("STT", typeof(string));
            table.Columns.Add("Customer", typeof(string));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("ContentMessages", typeof(string));
            table.Columns.Add("Encrypt", typeof(string));
            return table;
        }
        public DataTable dataTableReceiveMessages()
        {
            var table = new DataTable();
            table.Columns.Add("COM", typeof(string));
            table.Columns.Add("Sender", typeof(string));
            table.Columns.Add("Time", typeof(string));
            table.Columns.Add("ShortMessages", typeof(string));
            table.Columns.Add("Messages", typeof(string));
            return table;
        }
    }
}
