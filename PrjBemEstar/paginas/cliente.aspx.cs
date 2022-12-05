using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using System.Diagnostics;
using PrjBemEstar.Classes;
using System.Net;
using System.Web.Services.Description;

namespace PrjBemEstar
{
    public partial class cliente : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string senha;
                HttpCookie cookie = Request.Cookies["z"];
                HttpCookie cookie2 = Request.Cookies["p"];
                HttpCookie cookie3 = Request.Cookies["n"];

                if (cookie != null && cookie2 != null & cookie3 != null)
                { 
                    DADOSLOGIN.Text = cookie.Value.ToString(); //GUARDANDO O MEU LOGIN
                    senha = cookie2.Value.ToString();
                    linkPerfil.Text = cookie3.Value.ToString();                
                }
                else
                {
                    //Response.Write("<script>alert('Faça o seu Login!!!')</script>");
                    Response.Redirect("../default.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("default.aspx");
            }



        }    
        protected void linkPerfil_Click(object sender, EventArgs e)
        {
            string guardarSenha;
            pagIMC.Style.Add("display", "none");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "block");

            SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
            SqlDataReader leitor;

            SqlCommand comando = new SqlCommand();

            comando.CommandText = "ps_buscaEditar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexaoIMC;
            comando.Parameters.Clear();


            comando.Parameters.AddWithValue("loginUsu", DADOSLOGIN.Text);
            conexaoIMC.Open();
            leitor = comando.ExecuteReader();



            if (leitor.HasRows)
            {
                leitor.Read();
                txtNome.Text = leitor.GetString(1);
                txtSobrenome.Text = leitor.GetString(2);
                txtLoginCadastrar.Text = leitor.GetString(3);
                txtDataNasc.Text = leitor.GetDateTime(5).ToString("dd/MM/yyyy");
                txtCel.Text = leitor.GetString(7); 
                          
                guardarSenha = leitor.GetString(4); // pegando a senha do banco de dados

                MD5 criaCripto = MD5.Create();

                byte[] vetorByte = Encoding.ASCII.GetBytes(guardarSenha); //criptografando senha
                byte[] vetorHash = criaCripto.ComputeHash(vetorByte);

                StringBuilder senhaCriptografada = new StringBuilder();
                for (int i = 0; i < vetorHash.Length; i++)
                {
                senhaCriptografada.Append(vetorHash[i].ToString("x2"));
                }
                
                txtSenhaCadastrar.Text = senhaCriptografada.ToString();
            }

            conexaoIMC.Close();

        }

        protected void linkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }

        protected void linkIMC_Click(object sender, EventArgs e)
        {           
            pagIMC.Style.Add("display", "block");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "none");
            txtPeso.Text = "";
            txtAltura.Text = "";
            txtResultadoIMC.Text = "";
        }

        protected void linkDieta_Click(object sender, EventArgs e)
        {
            pagIMC.Style.Add("display", "none");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "block");
            pagPerfil.Style.Add("display", "none");
        }

        protected void linkInicio_Click(object sender, EventArgs e)
        {
            pagIMC.Style.Add("display", "none");
            FUNDO.Style.Add("display", "block");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "none");
        }

        protected void btnAvaliacoes_Click(object sender, EventArgs e)
        {
            SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "ps_Imc";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexaoIMC;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("loginUsu", DADOSLOGIN.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);//traduz a tabela que vem do banco de dados
            DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria
            adaptador.Fill(dados); //preencher o grid na tela com os dados do data set
            gvAvaliacoes.DataSource = dados;
            gvAvaliacoes.DataBind();

            if (dados.Tables[0].Rows.Count == 0)
            {
                lblAviso.Text = "nada por aqui...";
            }
            conexaoIMC.Close();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
            SqlCommand comando = new SqlCommand();
            if (txtData.Text == "")
            {
                comando.CommandText = "ps_GridDietaNome";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("loginUsu", DADOSLOGIN.Text);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);//traduz a tabela que vem do banco de dados
                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria
                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set
                gvDietas.DataSource = dados;
                gvDietas.DataBind();
                conexaoIMC.Close();
            }
            else
            {
                comando.CommandText = "ps_GridDietaData";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("loginUsu", DADOSLOGIN.Text);
                comando.Parameters.AddWithValue("dataAval", txtData.Text);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);//traduz a tabela que vem do banco de dados
                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria
                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set
                gvDietas.DataSource = dados;
                gvDietas.DataBind();
                conexaoIMC.Close();
            }  

        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());

                SqlCommand comando = new SqlCommand();

                comando.CommandText = "pu_Usuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;

                    if (txtNome.Text == "" || txtSobrenome.Text == "" || txtSenhaCadastrar.Text == "" || txtDataNasc.Text == "" || txtPerfil.Text == "" || txtCel.Text == "")
                    {
                        lblErroAtualizacao.Text = "Preencha os campos vázios!!";
                        lblErroAtualizacao.Style.Add("color", "red");
                    }
                    else
                    {

                        MD5 criaCripto = MD5.Create();

                        byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenhaCadastrar.Text); //criptografando senha
                        byte[] vetorHash = criaCripto.ComputeHash(vetorByte);

                        StringBuilder senhaCriptografada = new StringBuilder();

                            for (int i = 0; i < vetorHash.Length; i++)
                            {
                                senhaCriptografada.Append(vetorHash[i].ToString("x2"));
                            }

                        comando.Parameters.AddWithValue("nomeUsu", txtNome.Text);
                        comando.Parameters.AddWithValue("sobreNomeUsu", txtSobrenome.Text);
                        comando.Parameters.AddWithValue("senhaUsu", senhaCriptografada.ToString());
                        comando.Parameters.AddWithValue("dataNascimentoUsu", DateTime.Parse(txtDataNasc.Text));
                        comando.Parameters.AddWithValue("perfilUsu", txtPerfil.Text);
                        comando.Parameters.AddWithValue("telefoneUsu", txtCel.Text);
                        conexaoIMC.Open();
                        comando.ExecuteReader();
                        lblErroAtualizacao.Style.Add("color", "#A67153");

                        Response.Redirect("../default.aspx");

                        linkPerfil.Text = txtNome.Text; 
                    }
            }
            catch (SqlException)
            {
                lblErroAtualizacao.Text = "Login já existente!!";
                lblErroAtualizacao.Style.Add("color", "red");
            }
        }

        protected void gvDietas_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void gvAvaliacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data;

            txtPeso.Text = HttpUtility.HtmlDecode(gvAvaliacoes.SelectedRow.Cells[3].Text);
            txtAltura.Text = HttpUtility.HtmlDecode(gvAvaliacoes.SelectedRow.Cells[4].Text);

            try
            {
                //realizando o calculo
                txtResultadoIMC.Text = Operacoes.CalculoIMC(Convert.ToDouble(txtPeso.Text), Convert.ToDouble(txtAltura.Text)).ToString("n2");
                //recebendo avisos de peso
                lblAviso.Text = Operacoes.AvisoIMC(Convert.ToDouble(txtPeso.Text), Convert.ToDouble(txtAltura.Text), Convert.ToDouble(txtResultadoIMC.Text));

                //se a altura for igual a 0, realizar a função Exception
                if (txtAltura.Text == 0.ToString())
                {
                    throw new DivideByZeroException();

                }
            }
            catch (FormatException)
            {
                //Se não for número, voltar para a pag default com o aviso de erro.
                lblAviso.Text = "Campos em Branco !!";
            }
            catch (DivideByZeroException)
            {
                //Se a altura for 0, voltar para a pag default com o aviso de erro.
                lblAviso.Text = "Divisão por Zero !!";
            }

            //Criando Fluxo para as figurinhas
            if (Convert.ToDouble(txtResultadoIMC.Text) < 18.5)
            {
                abaixo.Style.Add("opacity", "1");
                normal.Style.Add("opacity", "0.4");
                acima.Style.Add("opacity", "0.4");
                obesidade1.Style.Add("opacity", "0.4");
                obesidade2.Style.Add("opacity", "0.4");
            }
            else if (Convert.ToDouble(txtResultadoIMC.Text) >= 18.6 && Convert.ToDouble(txtResultadoIMC.Text) <= 24.9)
            {
                abaixo.Style.Add("opacity", "0.4");
                normal.Style.Add("opacity", "1");
                acima.Style.Add("opacity", "0.4");
                obesidade1.Style.Add("opacity", "0.4");
                obesidade2.Style.Add("opacity", "0.4");
            }
            else if (Convert.ToDouble(txtResultadoIMC.Text) >= 25.0 && Convert.ToDouble(txtResultadoIMC.Text) <= 29.9)
            {
                abaixo.Style.Add("opacity", "0.4");
                normal.Style.Add("opacity", "0.4");
                acima.Style.Add("opacity", "1");
                obesidade1.Style.Add("opacity", "0.4");
                obesidade2.Style.Add("opacity", "0.4");
            }
            else if (Convert.ToDouble(txtResultadoIMC.Text) >= 30 && Convert.ToDouble(txtResultadoIMC.Text) < 40)
            {
                abaixo.Style.Add("opacity", "0.4");
                normal.Style.Add("opacity", "0.4");
                acima.Style.Add("opacity", "0.4");
                obesidade1.Style.Add("opacity", "1");
                obesidade2.Style.Add("opacity", "0.4");
            }
            else
            {
                abaixo.Style.Add("opacity", "0.4");
                normal.Style.Add("opacity", "0.4");
                acima.Style.Add("opacity", "0.4");
                obesidade1.Style.Add("opacity", "0.4");
                obesidade2.Style.Add("opacity", "1");
            }
        }
    }
}