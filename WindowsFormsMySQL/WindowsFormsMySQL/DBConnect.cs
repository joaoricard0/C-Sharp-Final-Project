using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

class DBConnect
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;
    private string port;

    public DBConnect()
    {
        Initialize();
    }
    private void Initialize()
    {
        server = "grandeporto.ddns.net";    //localhost ou ip máquina virtual
        database = "formandos_prog09";
        uid = "Programador09";              //root
        password = "Dados@2022";            //"" - se não tiver password
        port = "3306";

        string connectionString;
        connectionString = "SERVER=" + server + "; DATABASE=" + database + "; UID=" + uid +
            "; PASSWORD=" + password + "; PORT=" + port + ";";

        connection = new MySqlConnection(connectionString);

    }

    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    public int Count()
    {
        string query = "Select COUNT(*) FROM formando";

        int count = -1;

        if (OpenConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            count = int.Parse(cmd.ExecuteScalar().ToString());

            CloseConnection();

        }

        return count;
    }
    public int MaxID()
    {
        string query = "Select Max(id_formando) FROM formando";

        int max = 0;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                /*max = int.Parse(cmd.ExecuteScalar().ToString());
                max++;*/
                int.TryParse(cmd.ExecuteScalar().ToString(), out max);

            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return max;
    }

    public void Insert()
    {
        string query = "insert into formando values(5, 'Jaquim', 'Rua Espetacular', NULL," +
            "'PT50654321', 'M', '1987-04-15')";
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

    }
    public bool Insert2()
    {
        string query = "insert into formando values (12, 'Jorge Varandas', 'Rua Principal', NULL," +
            "'PT500000001', 'M', '1980-11-13');";

        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }
    public bool InsertForm(string id, string nome, string morada, string contacto, string iban, char genero,
        string data_nascimento)
    {
        /*string query = "insert into formando values(2, 'Sr Padreco', 'Rua dos Senhores', NULL," +
            "'PT50516555', 'M', '1910-04-25')";*/
        string query = "insert into formando (id_formando, nome, morada, contacto, iban, sexo, data_nascimento) values (" +
            id + ",'" + nome + "','" + morada + "','" + contacto + "','" + iban + "','" + genero + "','" + data_nascimento + "');";

        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                flag = true;

            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return flag;

    }
    public bool SearchForm(string idpesquisa, ref string nome, ref string morada, ref string contacto, ref string iban, ref char genero,
        ref string data_nascimento)
    {
        /*string query = "insert into formando values(2, 'Sr Padreco', 'Rua dos Senhores', NULL," +
            "'PT50516555', 'M', '1910-04-25')";*/
        string query = "select nome, morada, contacto, iban, sexo, data_nascimento from formando " +
           "Where id_formando = " + idpesquisa;

        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    nome = dataReader[0].ToString();
                    morada = dataReader["morada"].ToString();
                    contacto = dataReader[2].ToString();
                    iban = dataReader[3].ToString();
                    genero = dataReader["sexo"].ToString()[0];
                    data_nascimento = dataReader[5].ToString();
                    flag = true;
                }

                dataReader.Close();

            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return flag;

    }
    public bool UpdateForm(string id, string nome, string morada, string contacto, string iban, char genero,
        string data_nascimento)
    {
        string query = "update formando set nome = '" + nome + "', morada = '" + morada + "', contacto = '"
            + contacto + "', iban = '" + iban + "', sexo = '" + genero + "', data_nascimento = '" + data_nascimento
         + "' where id_formando = " + id;
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }
    public bool DeleteForm(string id)
    {
        string query = "delete from formando " +
           "Where id_formando = " + id;

        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                flag = true;

            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return flag;

    }

    public bool Update(string id, string nome)
    {
        string query = "update formando set nome = '" + nome + "' where id_formando = " + id;
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }

    public bool Delete(string id)
    {
        string query = "Delete from formando where id_formando = " + id;
        bool flag = false;
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                flag = true;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }

    public void PreencherDataGridViewFormandoFiltro(ref DataGridView dgv,
        string nome, char genero)
    {
        string query = "select id_formando, nome, iban, data_nascimento, sexo from formando";
        bool flag = false;

        if (genero != 'T' && genero != ' ')
        {
            query = query + " where sexo = '" + genero + "'";
            flag = true;
        }

        if (nome.Length > 0)
        {
            if (flag)
            {
                query = query + " and nome like '%" + nome + "%'";
            }
            else
            {
                query = query + " where nome like '%" + nome + "%'";
            }

        }


        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                int idxLinha = 0;

                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[idxLinha].Cells["codID"].Value = dr[0].ToString();
                    dgv.Rows[idxLinha].Cells[1].Value = dr[1].ToString();
                    dgv.Rows[idxLinha].Cells["iban"].Value = dr[2].ToString();
                    dgv.Rows[idxLinha].Cells[3].Value = DateTime.Parse(dr[3].ToString()).ToString("dd-MM-yyyy");
                    dgv.Rows[idxLinha].Cells["genero"].Value = dr["sexo"].ToString();
                    idxLinha++;
                }
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }
    public bool InsertNacionalidade(string iso2, string nacionalidade)
    {
        bool flag = true;

        string query = "insert into Nacionalidade values (0, '" + iso2 + "', '" + nacionalidade + "')";

        try
        {
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            flag = false;
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }

    public bool DeleteNacionalidade(string id_nacionalidade)
    {
        bool flag = true;

        string query = "Delete from Nacionalidade where id_nacionalidade = " + id_nacionalidade;

        try
        {
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            flag = false;
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }
    public bool UpdateNacionalidade(string id_nac, string iso, string nacionalidade)
    {
        bool flag = true;

        string query = "Update Nacionalidade set alf2 = '" + iso + "', nacionalidade = '" + nacionalidade + "' where id_nacionalidade = " + id_nac;

        try
        {
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            flag = false;
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }

    public void DataGridViewNacionalidade(ref DataGridView dgv)
    {
        string query = "select id_nacionalidade, alf2, nacionalidade from Nacionalidade";
        try
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                int nacLinha = 0;

                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[nacLinha].Cells["id_nacionalidade"].Value = dr[0].ToString();
                    dgv.Rows[nacLinha].Cells[1].Value = dr[1].ToString();
                    dgv.Rows[nacLinha].Cells["nacionalidade"].Value = dr[2].ToString();
                    nacLinha++;
                }
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    internal void ComboBoxNac(ref ComboBox nac)
    {
        string query = "select * from Nacionalidade";

        try
        {
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nac.Items.Add(dr[0] + " | " + dr[1] + " | " + dr[2]);

                }
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }
}