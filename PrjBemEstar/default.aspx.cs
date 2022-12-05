using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjBemEstar
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            ParteCadastrar.Style.Add("display", "none");
            logar.Style.Add("display", "block");
        }
        protected void btnAcessar_Click(object sender, EventArgs e)
        {


            if (txtLogin.Text == "" && txtSenha.Text == "")
            {
                txtLogin.Style.Add("border-bottom", "solid 3px red");
                txtSenha.Style.Add("border-bottom", "solid 3px red");

                lblErro.CssClass = "avisoErro";
                lblErro.Text = "Preencha os campos vázios.";
            }
            else if (txtLogin.Text == "")
            {
                txtLogin.Style.Add("border-bottom", "solid 3px red");
                txtSenha.Style.Add("border", "none");

                lblErro.CssClass = "avisoErro";
                lblErro.Text = "Digite o seu login.";
                lblErro.Style.Add("color", "red");

            }
            else if (txtSenha.Text == "")
            {
                txtSenha.Style.Add("border-bottom", "solid 3px red");
                txtLogin.Style.Add("border", "none");

                lblErro.CssClass = "avisoErro";
                lblErro.Text = "Senha inválido!!";
            }
            else
            {


                //try
                //{
                    SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
                    SqlDataReader leitor; //declarando variavel para leitor, função para ler uma linha por vez

                    SqlCommand comando = new SqlCommand();

                    comando.CommandText = "ps_validaLoginUsu"; //vinculando com a procedure
                    comando.CommandType = CommandType.StoredProcedure;//declarando tipo procedure
                    comando.Connection = conexaoIMC; //conectando no banco de dados 

                    MD5 criaCripto = MD5.Create(); //MD5=CLASSE abstrata. criando objeto de criptografia atraves do algoritimo md5

                    byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenha.Text);// encoding vai pegar a quantidade de bytes equivalentes e transformar a senha em vetor de bytes
                    byte[] vetorHash = criaCripto.ComputeHash(vetorByte); //gerar o hash(dado criptografado) com nase na equivalencia de bytes que pegamos na linha



                    StringBuilder senhaCriptografada = new StringBuilder(); // StringBuilder = classe do framework q serve para manipular strings(juntar informações sem ter q concatenar)
                    for (int i = 0; i < vetorHash.Length; i++) // i++= i=i+1
                    {
                        senhaCriptografada.Append(vetorHash[i].ToString("x2"));    //append= junta pedaços de string mais o seu valor(o objeto deve ser StringBuilder para usar append
                    }

                    //fim criptografia

                    comando.Parameters.Clear();

                    //vinculando os valores
                    comando.Parameters.AddWithValue("loginUsu", txtLogin.Text);
                    comando.Parameters.AddWithValue("senhaUsu", senhaCriptografada.ToString());

                    //abrindo a conexão
                    conexaoIMC.Open();
                    leitor = comando.ExecuteReader(); //abrindo o leitor com os comandos para a leitura da procedure Cliente

                        

                    if (leitor.HasRows) //se o login for cliente, acessar a pagina cliente!!
                    {
                        HttpCookie cookie = new HttpCookie("z");
                        cookie.Value = txtLogin.Text;

                        HttpCookie cookie2 = new HttpCookie("p");
                        cookie2.Value = senhaCriptografada.ToString();

                        leitor.Read();

                        HttpCookie cookie3 = new HttpCookie("n");
                        cookie3.Value = leitor.GetString(0);


                        DateTime agora = DateTime.Now;
                        TimeSpan tempo = new TimeSpan(0, 2, 0);
                        cookie.Expires = agora + tempo;
                        cookie2.Expires = agora + tempo;

                        Response.Cookies.Add(cookie);
                        Response.Cookies.Add(cookie2);
                        Response.Cookies.Add(cookie3);

                        Response.Redirect("paginas/cliente.aspx");
                    }
                    else 
                    {
                        leitor.Close(); //fechando o leitor para abrir outro comando para Profissional
                        comando.CommandText = "ps_validaLoginPro"; //vinculando com a procedure
                        comando.Parameters.Clear();

                        //vinculando os valores
                        comando.Parameters.AddWithValue("loginPro", txtLogin.Text);
                        comando.Parameters.AddWithValue("senhaPro", senhaCriptografada.ToString());
                        leitor = comando.ExecuteReader(); //abrindo o leitor com os comandos para a leitura da procedure Profissional

                        if (leitor.HasRows) // se não for cliente, acessar a pagina profissional!!
                        {
                            HttpCookie cookie = new HttpCookie("z");
                            cookie.Value = txtLogin.Text;

                            HttpCookie cookie2 = new HttpCookie("p");
                            cookie2.Value = senhaCriptografada.ToString();

                            leitor.Read();
                            HttpCookie cookie3 = new HttpCookie("i");
                            cookie3.Value = leitor.GetInt32(0).ToString();

                            HttpCookie cookie4 = new HttpCookie("n");
                            cookie4.Value = leitor.GetString(1);

                            HttpCookie cookie5 = new HttpCookie("t");
                            cookie5.Value = leitor.GetString(2);

                        DateTime agora = DateTime.Now;
                            TimeSpan tempo = new TimeSpan(0, 10, 0);
                            cookie.Expires = agora + tempo;
                            cookie2.Expires = agora + tempo;

                            Response.Cookies.Add(cookie);
                            Response.Cookies.Add(cookie2);
                            Response.Cookies.Add(cookie3);
                            Response.Cookies.Add(cookie4);
                            Response.Cookies.Add(cookie5);

                             Response.Redirect("paginas/profissional.aspx");
                        }
                        else // caso não for nem cliente ou profissional, significa que o login ou senha não exite!!
                        {
                            lblErro.CssClass = "avisoErro";
                            lblErro.Text = "Login ou Senha inválidos";

                            txtSenha.Style.Add("border", "none");
                            txtLogin.Style.Add("border", "none");
                        }
                    }
                    conexaoIMC.Close();
                //}
                //catch (Exception exceção)
                //{
                //    lblErro.Text = exceção.Message;
                //}
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
                if (txtNome.Text == "" || txtSobrenome.Text == "" || txtLoginCadastrar.Text == "" || txtSenhaCadastrar.Text == "" || txtDataNasc.Text == "" || txtCel.Text == "")
                {
                    lblErroCadastrar.CssClass = "avisoErro";
                    lblErroCadastrar.Text = "Preencha os campos vazios!";
                }
                else
                {
                    try
                    {
                        SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());

                        SqlCommand comando = new SqlCommand();

                        comando.CommandText = "pi_Usuario";
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Connection = conexaoIMC;

                        MD5 Cripto = MD5.Create();
                        
                        byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenhaCadastrar.Text);
                        byte[] vetorHash = Cripto.ComputeHash(vetorByte);

                        StringBuilder senhaCriptografada = new StringBuilder();

                        for (int i = 0; i < vetorHash.Length; i++)
                        {
                            senhaCriptografada.Append(vetorHash[i].ToString("x2"));
                        }

                        conexaoIMC.Open();

                        comando.Parameters.Clear();

                        comando.Parameters.AddWithValue("nomeUsu", txtNome.Text);
                        comando.Parameters.AddWithValue("sobreNomeUsu", txtSobrenome.Text);
                        comando.Parameters.AddWithValue("loginUsu", txtLoginCadastrar.Text);
                        comando.Parameters.AddWithValue("senhaUsu", senhaCriptografada.ToString());
                        comando.Parameters.AddWithValue("dataNascimentoUsu", txtDataNasc.Text);
                        comando.Parameters.AddWithValue("telefoneUsu", txtCel.Text);
                        comando.Parameters.AddWithValue("perfilUsu", txtTipo.Text);

                        comando.ExecuteNonQuery();

                        conexaoIMC.Close();

                        Response.Write("<script>alert('Usuário cadastrado com sucesso!!')</script>");


                        txtNome.Text = "";
                        txtSobrenome.Text = "";
                        txtLoginCadastrar.Text = "";
                        txtSenhaCadastrar.Text = "";
                        txtDataNasc.Text = "";
                        txtCel.Text = "";
                        lblErroCadastrar.Text = "";

                    }
                    catch (SqlException)
                    {
                        lblErroCadastrar.CssClass = "avisoErro";
                        lblErroCadastrar.Text = "Login já está em uso!";
                    }
                }

        } 
        protected void Cliente_Click(object sender, EventArgs e)
        {
            ParteCadastrar.Style.Add("display", "block");
            logar.Style.Add("display", "none");
            txtTipo.Text = "Cliente";
            perfil.Style.Add("display","none");
            lblErroCadastrar.Text = "";
        }
    }
}