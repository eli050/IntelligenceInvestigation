using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligenceInvestigation.Entities.Players;
using IntelligenceInvestigation.SQL.DB;
using MySql.Data.MySqlClient;

namespace IntelligenceInvestigation.SQL.DAL
{
    public class PlayersDAL
    {
        private MySQLData _mySql;
        public PlayersDAL(MySQLData MySql)
        {
            _mySql = MySql;
        }
        public Player GetByUserName(string UserName)
        {
            MySqlConnection? conn = null;
            try
            {
                conn = _mySql.GetConnection();
                string query = $"SELECT * FROM players WHERE players.nick_name = '{UserName}';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");
                string userName = reader.GetString("nick_name");
                int stage = reader.GetInt32("stage");
                Player player = new Player(id, name, userName, stage);
                return player;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    _mySql.CloseConnection(conn);
                }
            }
        }
        public void InsertUser(Player player)
        {
            MySqlConnection? conn = null;
            try
            {
                conn = _mySql.GetConnection();
                string query = "INSERT INTO players(name,nick_name)" +
                    $"VALUES('{player.Name}','{player.NickName}');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    _mySql.CloseConnection(conn);
                }
            }
        }
    }
}
