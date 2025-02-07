using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class DbConnect
    {
        public SqlConnection con { get; set; }
        public DbConnect()
        {
            try
            {
                string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + GetDBName() + ";Integrated Security=True";

                con = new SqlConnection(conString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
        public string GetDBName()
        {

            string[] filePaths;
            Int32 PathArrayIndex = 0;
            string[] dirConts;
            Boolean Found = false;
            Int32 Counter;
            List<string> DBNames = new List<string>();
            string BaseDir = TrimPath(System.AppDomain.CurrentDomain.BaseDirectory);
            do
            {
                filePaths = System.IO.Directory.GetDirectories(BaseDir);
                PathArrayIndex = 0;
                while (PathArrayIndex < filePaths.Length & Found == false)
                {
                    filePaths[PathArrayIndex] = filePaths[PathArrayIndex].ToLower();
                    if (filePaths[PathArrayIndex].Contains("app_data") == true)
                    {
                        dirConts = System.IO.Directory.GetFiles(filePaths[PathArrayIndex], "*.mdf", System.IO.SearchOption.AllDirectories);
                        Counter = 0;
                        while (Counter < dirConts.Length)
                        {
                            if (dirConts[Counter].Contains("ASPNETDB.MDF") == false)
                            {
                                DBNames.Add(dirConts[Counter]);
                            }
                            Counter++;
                        }
                        if (DBNames.Count == 1)
                        {
                            Found = true;
                        }
                        else
                        {
                            PathArrayIndex++;
                        }
                    }
                    else
                    {
                        PathArrayIndex++;
                    }
                }
                if (Found == false)
                {
                    BaseDir = TrimPath(BaseDir);
                }
            }
            while (BaseDir != "" & Found == false);
            if (DBNames.Count == 1)
            {
                return DBNames[0];
            }
            else if (DBNames.Count == 0)
            {
                throw new System.Exception("There is no database in your App_Data folder");
            }
            else
            {
                throw new System.Exception("You have too many database files in your App_Data folder");
            }
        }

        private string TrimPath(string OldPath)
        {
            Int32 Posn = 0;
            Posn = OldPath.LastIndexOf("\\");
            if (Posn != -1)
            {
                OldPath = OldPath.Substring(0, Posn);
            }
            else
            {
                OldPath = "";
            }
            return OldPath;
        }
    }
}
