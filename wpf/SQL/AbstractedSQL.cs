using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace wpf
{
    public abstract class AbstractedSQL
    {
        private static string connstring = "Server=tcp:invodb.database.windows.net,1433;Initial Catalog = invo-db; Persist Security Info=False;User ID = invoadmin; Password=QWDvuOw0t1rP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        public string connection { get { return connstring; } }
    }
}
