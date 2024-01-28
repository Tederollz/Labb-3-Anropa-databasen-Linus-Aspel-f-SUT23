using System.Data.SqlClient;

namespace Labb_3___Anropa_databasen_Linus_Aspelöf_SUT23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.StartMenu();

            SqlConnection sqlCon = new SqlConnection(@"Data Source = LINUSDESKTOP;Initial Catalog=SkolaDB;integrated security = True;TrustServerCertificate=True");

            

        }
    }
}
