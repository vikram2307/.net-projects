using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management
{
    public class Connect
    {
        
        public Connect() {
            string ConnectionString = "data source=DESKTOP-AI3GDBR;Initial catalog=Library_management;Integrated Security=true;";
            SqlConnection Connect = new SqlConnection(ConnectionString);
            Connect.Open();
        }
    }
}
