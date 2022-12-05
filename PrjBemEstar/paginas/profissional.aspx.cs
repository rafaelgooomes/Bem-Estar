using PrjBemEstar.Classes;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PrjBemEstar
{
    public partial class profissional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string senha;
                HttpCookie cookie = Request.Cookies["z"];
                HttpCookie cookie2 = Request.Cookies["p"];
                HttpCookie cookie3 = Request.Cookies["i"];
                HttpCookie cookie4 = Request.Cookies["n"];
                HttpCookie cookie5 = Request.Cookies["t"];


                if (cookie != null && cookie2 != null & cookie3 != null & cookie4 != null & cookie5 != null)
                {
                    string PERFIL;
                    PERFIL = cookie5.Value.ToString();
                    DADOSID.Text = cookie3.Value.ToString();
                    DADOSLOGIN.Text = cookie.Value.ToString(); //GUARDANDO O MEU LOGIN
                    senha = cookie2.Value.ToString();
                    linkPerfil.Text = cookie4.Value.ToString();

                    if (PERFIL == "Admin") //SE A CONTA FOR DO TIPO ADMIN, SERÁ DISPONI
                    {
                        linkCadastrarPro.Style.Add("display", "block");
                    }
                    else
                    {
                        linkCadastrarPro.Style.Add("display", "none");
                    }
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

        protected void linkInicio_Click(object sender, EventArgs e)
        {
            pagAvaliacao.Style.Add("display", "none");
            pagIMC.Style.Add("display", "none");
            FUNDO.Style.Add("display", "block");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "none");
            footer.Style.Add("display", "block");
            CadastrarProfissional.Style.Add("display", "none");
        }
        protected void linkAvaliacao_Click(object sender, EventArgs e)
        {
            pagIMC.Style.Add("display", "none");
            pagAvaliacao.Style.Add("display", "flex");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "none");
            footer.Style.Add("display", "none");
            CadastrarProfissional.Style.Add("display", "none");
            txtNumPro.Text = DADOSID.Text;
            lblErroAvaliacoes.Text = "";
        }
        protected void linkIMC_Click(object sender, EventArgs e)
        {
            pagAvaliacao.Style.Add("display", "none");
            pagIMC.Style.Add("display", "block");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "none");
            footer.Style.Add("display", "none");
            CadastrarProfissional.Style.Add("display", "none");
            txtNumProDieta.Text = DADOSID.Text;
        }

        protected void linkDieta_Click(object sender, EventArgs e)
        {
            pagAvaliacao.Style.Add("display", "none");
            pagIMC.Style.Add("display", "none");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "block");
            pagPerfil.Style.Add("display", "none");
            footer.Style.Add("display", "none");
            CadastrarProfissional.Style.Add("display", "none");
        }

        protected void linkPerfil_Click(object sender, EventArgs e)
        {
            string guardarSenha;
            pagAvaliacao.Style.Add("display", "none");
            pagIMC.Style.Add("display", "none");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "block");
            footer.Style.Add("display", "none");
            CadastrarProfissional.Style.Add("display", "none");

            SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
            SqlDataReader leitor;

            SqlCommand comando = new SqlCommand();

            comando.CommandText = "ps_buscaEditarPro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexaoIMC;
            comando.Parameters.Clear();


            comando.Parameters.AddWithValue("loginPro", DADOSLOGIN.Text);
            conexaoIMC.Open();
            leitor = comando.ExecuteReader();

            if (leitor.HasRows)
            {
                leitor.Read();
                txtNomeAtualizarPro.Text = leitor.GetString(1);
                txtSobrenomeAtualizarPro.Text = leitor.GetString(2);
                txtCredencialAtualizarPro.Text = leitor.GetString(3);
                txtLoginAtualizarPro.Text = leitor.GetString(4);
                txtDataNascAtualizarPro.Text = leitor.GetDateTime(6).ToString("dd/MM/yyyy");
                txtCelAtualizarPro.Text = leitor.GetString(8);

                guardarSenha = leitor.GetString(5); // pegando a senha do banco de dados

                MD5 criaCripto = MD5.Create();

                byte[] vetorByte = Encoding.ASCII.GetBytes(guardarSenha); //criptografando senha
                byte[] vetorHash = criaCripto.ComputeHash(vetorByte);

                StringBuilder senhaCriptografada = new StringBuilder();
                for (int i = 0; i < vetorHash.Length; i++)
                {
                    senhaCriptografada.Append(vetorHash[i].ToString("x2"));
                }

                txtSenhaAtualizarPro.Text = senhaCriptografada.ToString();
            }

            conexaoIMC.Close();
        }
        protected void linkCadastrarPro_Click(object sender, EventArgs e)
        {
            pagAvaliacao.Style.Add("display", "none");
            pagIMC.Style.Add("display", "none");
            FUNDO.Style.Add("display", "none");
            pagDieta.Style.Add("display", "none");
            pagPerfil.Style.Add("display", "none");
            footer.Style.Add("display", "none");
            CadastrarProfissional.Style.Add("display", "block");
        }
        protected void linkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }

        protected void btnAvaliacoes_Click(object sender, EventArgs e)
        {
            SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "ps_ImcPro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexaoIMC;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("nomeUsu", txtNomeAvaliacoes.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet dados = new DataSet(); 
            adaptador.Fill(dados); 
            gvAvaliacoes.DataSource = dados;
            gvAvaliacoes.DataBind();

            if (dados.Tables[0].Rows.Count == 0)
            {
                lblAviso.Text = "nada por aqui...";
            }
            conexaoIMC.Close();
        }

        protected void gvAvaliacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data;

            txtNumAvaliacao.Text = HttpUtility.HtmlDecode(gvAvaliacoes.SelectedRow.Cells[1].Text);
            txtNumClienteDieta.Text = HttpUtility.HtmlDecode(gvAvaliacoes.SelectedRow.Cells[4].Text);
            txtPeso.Text = HttpUtility.HtmlDecode(gvAvaliacoes.SelectedRow.Cells[7].Text);
            txtAltura.Text = HttpUtility.HtmlDecode(gvAvaliacoes.SelectedRow.Cells[8].Text);

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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
            SqlCommand comando = new SqlCommand();
            if (txtNomeBuscarDieta.Text == "")
            {
                comando.CommandText = "ps_GridDietaNomePro";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;
                comando.Parameters.Clear();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);//traduz a tabela que vem do banco de dados
                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria
                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set
                gvDietas.DataSource = dados;
                gvDietas.DataBind();
                conexaoIMC.Close();
            }
            else
            {
                comando.CommandText = "ps_GridDietaDataPro";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("nomeUsu", txtNomeBuscarDieta.Text);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);//traduz a tabela que vem do banco de dados
                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria
                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set
                gvDietas.DataSource = dados;
                gvDietas.DataBind();
                conexaoIMC.Close();
            }
        }

        protected void gvDietas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());

                SqlCommand comando = new SqlCommand();

                comando.CommandText = "pu_Profissional";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;

                if (txtNomeAtualizarPro.Text == "" || txtSobrenomeAtualizarPro.Text == "" || txtSenhaAtualizarPro.Text == "" || txtDataNascAtualizarPro.Text == "" || txtPerfilAtualizarPro.Text == "" || txtCelAtualizarPro.Text == "")
                {
                    lblErroAtualizacao.Text = "Preencha os campos vázios!!";
                    lblErroAtualizacao.Style.Add("color", "red");
                }
                else
                {

                    MD5 criaCripto = MD5.Create();

                    byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenhaAtualizarPro.Text); //criptografando senha
                    byte[] vetorHash = criaCripto.ComputeHash(vetorByte);

                    StringBuilder senhaCriptografada = new StringBuilder();

                    for (int i = 0; i < vetorHash.Length; i++)
                    {
                        senhaCriptografada.Append(vetorHash[i].ToString("x2"));
                    }

                    comando.Parameters.AddWithValue("nomePro", txtNomeAtualizarPro.Text);
                    comando.Parameters.AddWithValue("sobreNomePro", txtSobrenomeAtualizarPro.Text);
                    comando.Parameters.AddWithValue("senhaPro", senhaCriptografada.ToString());
                    comando.Parameters.AddWithValue("dataNascimentoPro", DateTime.Parse(txtDataNascAtualizarPro.Text));
                    comando.Parameters.AddWithValue("perfilPro", txtPerfilAtualizarPro.Text);
                    comando.Parameters.AddWithValue("telefonePro", txtCelAtualizarPro.Text);
                    conexaoIMC.Open();
                    comando.ExecuteReader();
                    lblErroAtualizacao.Style.Add("color", "#A67153");

                    Response.Redirect("../default.aspx");

                    linkPerfil.Text = txtNomeAtualizarPro.Text;
                }
            }
            catch (SqlException)
            {
                lblErroAtualizacao.Text = "Credencial já existente!!";
                lblErroAtualizacao.Style.Add("color", "red");
            }
        }

        protected void btnCadastrarAvaliacao_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "pi_Avaliacao";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;
                conexaoIMC.Open();
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("idUsuario", txtNumCliente.Text);
                comando.Parameters.AddWithValue("idProfissional", txtNumPro.Text);
                comando.Parameters.AddWithValue("dataAval", txtDtAvaliacao.Text);
                comando.Parameters.AddWithValue("peso", Decimal.Parse(txtPesoCliente.Text.Replace(".", ",")));
                comando.Parameters.AddWithValue("altura", Decimal.Parse(txtAlturaCliente.Text.Replace(".", ",")));
                comando.ExecuteNonQuery();
                conexaoIMC.Close();
                Response.Write("<script>alert('Avaliação cadastrada com Sucesso!!')</script>");
                txtNumCliente.Text = "";
                txtNumPro.Text = "";
                txtDtAvaliacao.Text = "";
                txtPesoCliente.Text = "";
                txtAlturaCliente.Text = "";
                lblErroAvaliacoes.Text = "";
            }
            catch (SqlException)
            {
                lblErroAvaliacoes.Text = "Peso ou altura inválido!!";
            }
            catch (FormatException)
            {
                lblErroAvaliacoes.Text = "Preencha os campos vazios!!";
            }
        }
    
        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "ps_ListaUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexaoIMC;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("nomeUsu", txtNomeBuscarCliente.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet dados = new DataSet();
            adaptador.Fill(dados);
            gvCliente.DataSource = dados;
            gvCliente.DataBind();
            conexaoIMC.Close();
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumCliente.Text = HttpUtility.HtmlDecode(gvCliente.SelectedRow.Cells[1].Text);
        }

        protected void btnCadastrarDieta_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "pi_Dieta";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexaoIMC;
                conexaoIMC.Open();
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("idUsuario", txtNumClienteDieta.Text);
                comando.Parameters.AddWithValue("idProfissional", txtNumProDieta.Text);
                comando.Parameters.AddWithValue("idAvaliacao", txtNumAvaliacao.Text);
                comando.Parameters.AddWithValue("dataDieta", txtDtDieta.Text);
                comando.Parameters.AddWithValue("restricoesAlimentares", txtRestAlim.Text);
                comando.Parameters.AddWithValue("dieta", txtDieta.Text);
                comando.ExecuteNonQuery();
                conexaoIMC.Close();
                Response.Write("<script>alert('Avaliação cadastrada com Sucesso!!')</script>");
                txtNumClienteDieta.Text = "";
                txtNumProDieta.Text = "";
                txtNumAvaliacao.Text = "";
                txtDtDieta.Text = "";
                txtRestAlim.Text = "";
                txtDieta.Text = "";
                lblErroDieta.Text = "";
            }
            catch (FormatException)
            {
                lblErroAvaliacoes.Text = "Preencha os campos vazios!!";
            }
        }

        protected void btnCadastrarPro_Click(object sender, EventArgs e)
        {
            if (txtNomeCadastrarPro.Text == "" || txtSobrenomeCadastrarPro.Text == "" || txtCredencialCadastrarPro.Text == "" || txtLoginCadastrarPro.Text == "" || txtSenhaCadastrarPro.Text == "" || txtDataNascCadastrarPro.Text == "" || txtCelCadastrarPro.Text == "")
            {
                lblErroCadastrarPro.CssClass = "avisoErro";
                lblErroCadastrarPro.Text = "Preencha os campos vazios!";
            }
            else
            {
                try
                {
                    SqlConnection conexaoIMC = new SqlConnection(ConfigurationManager.ConnectionStrings["PrjBemEstar.Properties.Settings.cnx"].ToString());

                    SqlCommand comando = new SqlCommand();

                    comando.CommandText = "pi_Profissional";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexaoIMC;

                    MD5 Cripto = MD5.Create();

                    byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenhaCadastrarPro.Text);
                    byte[] vetorHash = Cripto.ComputeHash(vetorByte);

                    StringBuilder senhaCriptografada = new StringBuilder();

                    for (int i = 0; i < vetorHash.Length; i++)
                    {
                        senhaCriptografada.Append(vetorHash[i].ToString("x2"));
                    }

                    conexaoIMC.Open();

                    comando.Parameters.Clear();

                    comando.Parameters.AddWithValue("nomePro", txtNomeCadastrarPro.Text);
                    comando.Parameters.AddWithValue("sobreNomePro", txtSobrenomeCadastrarPro.Text);
                    comando.Parameters.AddWithValue("credencial", txtCredencialCadastrarPro.Text);
                    comando.Parameters.AddWithValue("loginPro", txtLoginCadastrarPro.Text);
                    comando.Parameters.AddWithValue("senhaPro", senhaCriptografada.ToString());
                    comando.Parameters.AddWithValue("dataNascimentoPro", DateTime.Parse(txtDataNascCadastrarPro.Text));
                    comando.Parameters.AddWithValue("telefonePro", txtCelCadastrarPro.Text);
                    comando.Parameters.AddWithValue("perfilPro", DropPerfilCadastrarPro.Text);

                    comando.ExecuteNonQuery();

                    conexaoIMC.Close();

                    Response.Write("<script>alert('Usuário cadastrado com sucesso!!')</script>");


                    txtNomeCadastrarPro.Text = "";
                    txtSobrenomeCadastrarPro.Text = "";
                    txtCredencialCadastrarPro.Text = "";
                    txtLoginCadastrarPro.Text = "";
                    txtSenhaCadastrarPro.Text = "";
                    txtDataNascCadastrarPro.Text = "";
                    txtCelCadastrarPro.Text = "";
                    DropPerfilCadastrarPro.Text = "";

                }
                catch (SqlException)
                {
                    lblErroCadastrarPro.CssClass = "avisoErro";
                    lblErroCadastrarPro.Text = "Login ou Credencial já está em uso!";
                }
            }
        }
    }
}   
