using System.Linq;

namespace DapperBullCopyManager
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DataAccess : IDisposable
    {
        private SqlConnection connection;
        private SqlBulkCopy sqlBulkCopy;

        #region Constructor
        public DataAccess()
        {
            connection = new SqlConnection("Your string conection");
            sqlBulkCopy = new SqlBulkCopy(connection);

            var myDict = new Dictionary<string, string>();
            myDict["GetCantidadesWithParameters"] = "@Id";
            myDict["GetCantidadesWithParametersAndName"] = "@SixName , @Name";

            var model = new Parametro
            {
               Id=1,
               Name="Prueba",
               SixName="Prueba" 
            };


          var response = QueryMultiple<Parametro>(myDict,model);
            var que01 = response.Result.Data.Read<Album>().ToList();
        }
        #endregion

        #region Methods Dapper
        //DAPPER Query Multiple
        public async Task<Response<SqlMapper.GridReader>> QueryMultiple<T>(Dictionary<string, string> Dict, T model) where T : class
        {
            var response = new Response<SqlMapper.GridReader>();
            try
            {
                var sql = StoreMethods(Dict);
                response = new Response<SqlMapper.GridReader>()
                {
                    IsSuccess = true,
                    Message = "Exito",
                    Data = await connection.QueryMultipleAsync(sql, model)
                };

            }
            catch (Exception excepcion)
            {
                response = new Response<SqlMapper.GridReader>()
                {
                    IsSuccess = false,
                    Message = excepcion.Message,
                    Data = null
                };
            }

            return response;
        }

        // Proposals proposals, Careers careers,
        private async Task<Response<string>> LoteOperationDao (IDataReader model,string NameTable)   
        {
            var response = new Response<string>();

            try
            {
                string createTableSql = SqlDropAndCreateTable(sqlBulkCopy, NameTable);

                using (SqlCommand createTable = new SqlCommand(createTableSql, connection))
                {
                    createTable.ExecuteNonQuery();
                }
                await sqlBulkCopy.WriteToServerAsync(model);

                response = new Response<string>
                {
                    Data = "",
                    IsSuccess = true,
                    Message = "Operaciòn exitosa"

                };
            }
            catch (Exception exception)
            {
                response = new Response<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = exception.Message
                };
                
            }

            return response;
            
        }
        
        #endregion

        #region Utils
        //Method the Dictionary to String.
        private string StoreMethods(Dictionary<string, string> Dict)
        {
            var myStringBuilder = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<string, string> pair in Dict)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    myStringBuilder.Append(" ");
                }

                myStringBuilder.AppendFormat("{0} {1} {2}", "exec", pair.Key, pair.Value);
            }

            var myDesiredOutput = myStringBuilder.ToString();
            return myDesiredOutput;
        }

        private static string SqlDropAndCreateTable(SqlBulkCopy bcp, string TableName)
        {
            bcp.DestinationTableName = TableName;

            string createTableSql = "";

            createTableSql += "IF EXISTS(SELECT * FROM sys.tables t WHERE t.name = '"
                + bcp.DestinationTableName + "') DROP TABLE " + bcp.DestinationTableName + ";";
            createTableSql += "CREATE TABLE dbo." + bcp.DestinationTableName + "()";     //");"
            return createTableSql;
        }

        #endregion

        public void Dispose()
        {
            connection.Dispose();
        }


    }

    public class Parametro
    {
        public int Id { get; set; }
        public string SixName { get; set; }
        public string Name { get; set; }

    }
}






//public void Insert<T>(T model)
//{
//    connection.(model);
//}

//public void Update<T>(T model)
//{
//    connection.Update(model);
//}

//public void Delete<T>(T model)
//{
//    connection.Delete(model);
//}

//public T First<T>(bool WithChildren) where T : class
//{
//    if (WithChildren)
//    {
//        return connection.GetAllWithChildren<T>().FirstOrDefault();
//    }
//    else
//    {
//        return connection.Table<T>().FirstOrDefault();
//    }
//}

//public List<T> GetList<T>(bool WithChildren) where T : class
//{
//    if (WithChildren)
//    {
//        return connection.GetAllWithChildren<T>().ToList();
//    }
//    else
//    {
//        return connection.Table<T>().ToList();
//    }
//}

//public T Find<T>(int pk, bool WithChildren) where T : class
//{
//    if (WithChildren)
//    {
//        return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
//    }
//    else
//    {
//        return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
//    }
//}



//public async Task<List<Artist>> GetAllAsync()
//{
//    using (
//        SqlConnection conn =
//            new SqlConnection(""))
//    {
//        await conn.OpenAsync();

//        using (var multi = await conn.QueryMultipleAsync())//StoredProcs.Artists.GetAll, commandType: CommandType.StoredProcedure))
//        {
//            var Artists = multi.Read<Artist, AlbumArtist, Artist>((artist, albumArtist) =>
//            {
//                artist.albumArtist = albumArtist;
//                return artist;
//            }).ToList();

//            var albums = multi.Read<Album, AlbumArtist, Album>(
//            (album, albumArtist, album) =>
//            {
//                album.albumArtist = album; 
//                return albums;
//            }).ToList();


//            conn.Close();

//            return Artists;
//        }
//    }
//}
