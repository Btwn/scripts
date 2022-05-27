using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace UseBlowFish
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://defuse.ca/blowfish.htm
            //string sDatos = "Text";
            //string KeyStr = "xfirmae";
            //BlowFish mbf = new BlowFish(KeyStr);
            //string str = mbf.Encrypt_CBC(sDatos);
            //string strd = mbf.Decrypt_CBC(str);

            string KeyStr = "xfirmae";
            string connectionString = "Data Source=INSTANCE;Initial Catalog=IntelisisTest;Persist Security Info=True;User ID=USER;Password=PASS";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT datos FROM Sysbase WHERE Objeto = 'ABC.tbl'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader Reader = null;
            sqlConnection.Open();
            Reader = sqlCommand.ExecuteReader();
            Reader.Read();
            //string sDatos = "Y2MzYjdlYjc3YzJlYmMyNWQyM2U3N2ZhM2I5NDMzODc=";
            string sDatos = Encoding.ASCII.GetString((byte[])Reader[0]);
            sqlConnection.Close();


            SHA1CryptoServiceProvider cryptoServiceProvider = new SHA1CryptoServiceProvider();
            byte[] sDatosArray = Convert.FromBase64String(sDatos);
            byte[] IV = new byte[8];
            byte[] buffer = new byte[64];
            for (int index = 0; index < 8; ++index)
                buffer[index] = sDatosArray[index];
            Array.Copy((Array)Encoding.Unicode.GetBytes(KeyStr), 0, (Array)buffer, 8, KeyStr.Length);
            byte[] computeHash = cryptoServiceProvider.ComputeHash(buffer, 0, 8 + KeyStr.Length);
            BlowFish blowFish = new BlowFish(computeHash);
            for (int index = 8; index < 16; ++index)
                IV[index - 8] = sDatosArray[index];
            blowFish.IV = IV;
            byte[] ct = new byte[sDatosArray.Length - 16];
            for (int index = 16; index < sDatosArray.Length; ++index)
                ct[index - 16] = sDatosArray[index];
            string strAscii = Encoding.ASCII.GetString((byte[])blowFish.Decrypt_CBC(ct));
            string strUnicode = Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(strAscii));


            Console.WriteLine("Hello World!");
        }
    }
}
