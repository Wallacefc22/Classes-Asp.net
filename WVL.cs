using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Autor: wallace faustino
/// Data: 25/11/2022
/// Resumo:
/// Classe com pequenas funções do dia a dia de um
/// programador asp.net tendo a deixar seus codigos
/// mais limpos e praticos
/// exemplificado para iniciantes.
/// V: 1.0.0
/// </summary>
public class WVL
{
    public WVL()
    {

    }
    private SqlConnection Con;
    public string Scon { get; set; }
    public SqlConnection conn { get; set; }
    #region VALIDAÇÕES
    /// <summary>
    /// classes de validações
    /// sendo passado um parametro e tendo seu retorno
    /// de verdadeiro ou falso
    /// </summary>
    /// <param name="cpf">Cpf recebido do usuário</param>
    /// <param name="cnpj">Cnpj recebido do usuário</param>
    /// <param name="Scon">String de conexão ao banco de dados</param>
    /// <returns>Verdadeiro ou falso</returns>
    public bool Verifica_Cpf(string cpf)
    {

        #region VERIFICA VALOR VAZIO
        if (cpf == "")
        {
            return false;
        }
        cpf = cpf.Trim();
        cpf = cpf.Replace("-", "").Replace(".", "");
        #endregion
        #region VERIFICA QUANTIDADE DE DIGITOS
        if (cpf.Length != 11) { return false; }
        #endregion
        #region VARIAVEIS PARA CALCULOS
        ///VARIAVEIS PARA SOMA E VALIDAÇÃO DOS NUMEROS
        int soma = 0;
        string digito = "";
        string cpfTemp;
        int resto;

        int[] p1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] p2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] n = new int[11];
        /////////////////////////////////////////////
        #endregion
        #region ELIMINA CASOS DE DIGITOS IGUAIS
        switch (cpf)
        {
            case "11111111111":
                return false;
            case "00000000000":
                return false;
            case "22222222222":
                return false;
            case "33333333333":
                return false;
            case "44444444444":
                return false;
            case "55555555555":
                return false;
            case "66666666666":
                return false;
            case "77777777777":
                return false;
            case "88888888888":
                return false;
            case "99999999999":
                return false;
        }
        #endregion
        #region CAPTURA CADA DIGITO DOS 11 DIGITOS DO CPF
        try
        {
            //converte para int e captura o numero de uma determinada posição da variavel cpf
            n[0] = Convert.ToInt32(cpf.Substring(0, 1));
            n[1] = Convert.ToInt32(cpf.Substring(1, 1));
            n[2] = Convert.ToInt32(cpf.Substring(2, 1));
            n[3] = Convert.ToInt32(cpf.Substring(3, 1));
            n[4] = Convert.ToInt32(cpf.Substring(4, 1));
            n[5] = Convert.ToInt32(cpf.Substring(5, 1));
            n[6] = Convert.ToInt32(cpf.Substring(6, 1));
            n[7] = Convert.ToInt32(cpf.Substring(7, 1));
            n[8] = Convert.ToInt32(cpf.Substring(8, 1));
            n[9] = Convert.ToInt32(cpf.Substring(9, 1));
            n[10] = Convert.ToInt32(cpf.Substring(10, 1));
            ///////////////////////////////////////////////////////////////////////////////////
        }
        catch
        {
            return false;
        }
        #endregion
        #region VALIDAÇÃO DO CPF
        cpfTemp = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
        { soma += int.Parse(cpfTemp[i].ToString()) * p1[i]; }
        resto = soma % 11;

        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }
        digito = resto.ToString();
        cpfTemp = cpfTemp + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(cpfTemp[i].ToString()) * p2[i];
        }
        resto = soma % 11;
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
        #endregion
    }
    public bool Verifica_Cnpj(string cnpj)
    {
        
        #region VERIFICA VALORES VAZIOS (formata)
        cnpj.Trim();
        cnpj = cnpj.Replace("/", "").Replace(".", "").Replace("-", "");
        if (cnpj.Length != 14)
        {
            return false;
        }
        #endregion
        #region VARIAVEIS E LISTAS
        int[] m1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] m2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string cnpjTemp;
        #endregion
        #region VALIDAÇÃO CNPJ
        cnpjTemp = cnpj.Substring(0, 12);
        soma = 0;
        for (int i = 0; i < 12; i++)
        {
            soma += int.Parse(cnpjTemp[i].ToString()) * m1[1];
        }
        resto = (soma % 11);
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }
        digito = resto.ToString();
        cnpjTemp = cnpjTemp + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
        {
            soma += int.Parse(cnpjTemp[i].ToString()) * m2[i];
        }
        resto = (soma % 11);
        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }
        digito = digito + resto.ToString();
        return cnpj.EndsWith(digito);
        #endregion

    }
    public bool Verifica_Conexão_internet()
    {
        #region STATUS
        try
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
        #endregion
    }
    #endregion
    #region SQL FERRAMENTAS
    /// <summary>
    /// Tenta conexão com banco de dados
    /// </summary>
    /// <param name="Scon"></param>
    /// <returns>tentativa da conexão</returns>
    public string Verifica_conexao_com_banco_de_dados(string Scon)
    {
        #region TENTA CONEXÃO
        this.Con = new SqlConnection(this.Scon);
        string retorno;
        try
        {
            this.Con.Open();
            retorno = "Conectado no banco!";
        }
        catch (SqlException ex)
        {
            retorno = ex.Message;
        }
        finally  // vai ser sempre executado, independente de dar exeção ou não 
        {
            this.Con.Close();
        }
        return retorno;

        #endregion
    }
    /// <summary>
    /// Envia uma query pro banco de dados
    /// </summary>
    /// <param name="Scon">string de conexão ao banco</param>
    /// <param name="Squery">query do usuário</param>
    /// <returns>Tabela com os dados</returns>
    public DataTable Tabela_Generica(string Scon, string Squery)
    {
        #region CONEXÃO E QUERY
        DataTable dt = new DataTable();
        SqlDataAdapter dta = new SqlDataAdapter();


        using (SqlConnection cnn = new SqlConnection(Scon))
        {
            cnn.Open();

            using (SqlCommand cmd = new SqlCommand(Squery, cnn))
            {

                dta.SelectCommand = cmd;


                dta.Fill(dt);



                cnn.Close();

                if (dt.Rows != null)
                {

                    return dt;
                }
                else
                {
                    return null;
                }
            }


        }
        #endregion
    }
    /// <summary>
    /// Envia comando ao banco de dados
    /// </summary>
    /// <param name="Scon">string de conexão</param>
    /// <param name="Squery">query de update do usuário</param>
    /// <returns>Numero de linhas afetadas</returns>
    public int Update(string Scon, string Squery)
    {
        using (SqlConnection cnn = new SqlConnection(Scon))
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand(Squery, cnn))
            {

                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.Text;
                try
                {
                    cmd.Parameters.Add(new SqlParameter("", Squery));
                    
                    cmd.ExecuteNonQuery();
                   
                    return cmd.ExecuteNonQuery();
                    
                }
                catch (Exception e) { return 00; }
                finally { cnn.Close(); }


            }

        }
    }

    #endregion
}


    

     
    
