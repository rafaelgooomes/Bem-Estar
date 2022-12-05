<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profissional.aspx.cs" Inherits="PrjBemEstar.profissional" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="../css/reset.css"   />    
    <link rel="stylesheet" type="text/css" href="../css/profissional.css"   />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/all.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"/> 
    <title>Bem Estar</title>
</head>
<body>
    <form id="profissional" runat="server">
 <div id="menu" runat="server">
            <asp:LinkButton ID="linkInicio" runat="server" OnClick="linkInicio_Click"><i class="fa-sharp fa-solid fa-house"></i> Início</asp:LinkButton> 
            <asp:LinkButton ID="linkAvaliacao" runat="server" OnClick="linkAvaliacao_Click"> <i class="fa-regular fa-clipboard"></i> Avaliação</asp:LinkButton> 
            <asp:LinkButton ID="linkIMC" runat="server" OnClick="linkIMC_Click"> <i class="fa-solid fa-scale-unbalanced-flip"></i> IMC</asp:LinkButton> 
            <asp:LinkButton ID="linkDieta" runat="server" OnClick="linkDieta_Click"><i class="fa-solid fa-thumbtack"></i>  Visualizar Dieta</asp:LinkButton>
            <i class="fa-solid fa-circle-user"></i> <asp:LinkButton ID="linkPerfil" runat="server" OnClick="linkPerfil_Click"></asp:LinkButton>
            <asp:LinkButton ID="linkCadastrarPro" runat="server" OnClick="linkCadastrarPro_Click"><i class="fa-solid fa-user-doctor"></i>  Cadastrar Profissional</asp:LinkButton>
            <asp:LinkButton ID="linkSair" runat="server" OnClick="linkSair_Click"> <i class="fa-sharp fa-solid fa-right-from-bracket"></i> Sair</asp:LinkButton>
            <asp:LinkButton ID="DADOSLOGIN" runat="server" Visible="False"></asp:LinkButton>
            <asp:LinkButton ID="DADOSID" runat="server" Visible="False"></asp:LinkButton>
        </div> <hr/> 
        <div id="FUNDO" runat="server"> 
            <h1>BemEstar</h1>   <hr/>    <h3>Sua saúde no melhor estado</h3>
        </div>
        <div id="pagAvaliacao" runat="server">
            <div id="avaliacao">
                <h1>Cadastrar Avaliação: <i class="fa-solid fa-arrow-up-right-from-square"></i></h1> <br/>
                <i class="fa-solid fa-user-plus"></i> <asp:TextBox ID="txtNumCliente" runat="server" placeholder="Cliente" Height="25px" Width="45px" Enabled="False"></asp:TextBox>
                <i class="fa-solid fa-user-nurse"></i> <asp:TextBox ID="txtNumPro" runat="server" placeholder="Doutor" Height="25px" Width="45px" Enabled="False"></asp:TextBox> <br/><br/>
                <i class="fa-solid fa-weight-scale"></i> <asp:TextBox ID="txtPesoCliente" runat="server" placeholder="Peso" Height="25px" Width="65px"></asp:TextBox> 
                <i class="fa-solid fa-street-view"></i> <asp:TextBox ID="txtAlturaCliente" runat="server" placeholder="Altura" Height="25px" Width="65px"></asp:TextBox> <br/><br/>
                <i class="fa-solid fa-calendar-days"></i> <asp:TextBox ID="txtDtAvaliacao" runat="server" Height="25px"  placeholder="xx/xx/xxxx" TextMode="DateTime" MaxLength="10" Wrap="True"></asp:TextBox><br/><br/>
                <asp:Button ID="btnCadastrarAvaliacao" runat="server" Text="Cadastrar" OnClick="btnCadastrarAvaliacao_Click"/> <br/><br/>
                <div id="ERRO">
                    <asp:Label ID="lblErroAvaliacoes" runat="server" Text=""></asp:Label>
                </div>
            </div>
            
            <div id="buscarCliente" runat="server">
                <h2>Selecione um cliente para cadastrá-lo em uma avaliação:</h2> <br />
                <i class="fa-solid fa-user"></i> <asp:TextBox ID="txtNomeBuscarCliente" runat="server" placeholder="Digite o nome do Cliente" Height="25px"></asp:TextBox> <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar" OnClick="btnBuscarCliente_Click" />
                <br/>
                <asp:GridView ID="gvCliente" runat="server" Columns="6" AlternatingRowStyle-BorderStyle="Solid" AlternatingRowStyle-BorderWidth="2px" AlternatingRowStyle-BorderColor="#D99E89" AlternatingRowStyle-BackColor="#A67153" AlternatingRowStyle-CssClass="animate__fadeIn" AlternatingRowStyle-ForeColor="White" EditRowStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-BackColor="#A67153" CellSpacing="1" CellPadding="8" EditRowStyle-HorizontalAlign="Right" AllowCustomPaging="True" AllowPaging="True" HorizontalAlign="Center" PageIndex="2" PageSize="100" AutoGenerateSelectButton="True" GridLines="Vertical" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#D99E89" BorderColor="#A67153" BorderWidth="2px" BorderStyle="Solid" CssClass="animate__fadeIn" ForeColor="White" Font-Overline="False" Font-Size="Medium" HorizontalAlign="Center" Wrap="True"></AlternatingRowStyle>
                <EditRowStyle HorizontalAlign="Center" BorderStyle="None"></EditRowStyle>
                <EmptyDataRowStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
                <FooterStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="#A67153" BorderStyle="Solid" BorderColor="#A67153" BorderWidth="2px" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                <RowStyle BackColor="#D99E89" BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" Font-Size="Medium" ForeColor="White" HorizontalAlign="Center" />
                <SortedAscendingCellStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
                <SortedDescendingCellStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
                </asp:GridView>
            </div>
        </div>
        <div id="pagIMC" runat="server">
            <h1>Índice de Massa Corporal</h1>
                <div id="container">
                    <div id="calculoIMC">
                        <h1>Cálculo IMC</h1> <br />
                        <i class="fa-solid fa-weight-scale"></i> <asp:TextBox ID="txtPeso" runat="server" placeholder="Peso" Height="25px" Enabled="False" ></asp:TextBox> <br/>
                        <i class="fa-solid fa-street-view"></i> <asp:TextBox ID="txtAltura" runat="server" placeholder="Altura" Height="25px" Enabled="False" ></asp:TextBox> <br/>
                        <i class="fa-solid fa-scale-unbalanced-flip"></i> <asp:Label ID="lblIMC" runat="server" Text="IMC:"></asp:Label> 
                        <asp:TextBox ID="txtResultadoIMC" runat="server" Height="50px" Width="20%" Enabled="False"></asp:TextBox> <br />
                        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>                

                    </div>                        
                    <div id="figure" runat="server">
                        <img src="../img/abaixo.png" id="abaixo" alt="Figura Abaixo do Peso" runat="server"/>
                        <img src="../img/normal.png" id="normal" alt="Figura do Peso Normal" runat="server"/>
                        <img src="../img/acima.png" id="acima" alt="Figura Acima do Peso" runat="server"/>
                        <img src="../img/obesidade1.png" id="obesidade1" alt="Figura Obesidade 1" runat="server"/>
                        <img src="../img/obesidade2.png" id="obesidade2" alt="Figura Obesidade 2" runat="server"/>
                    </div>
                </div>
                <div id="container2">
                    <div id="cadastrarDieta">
                        <h1>Adicionar Dieta</h1> <br/>
                        <i class="fa-solid fa-user-plus"></i> <asp:TextBox ID="txtNumClienteDieta" runat="server" placeholder="Cliente" Height="25px" Width="45px" Enabled="False"></asp:TextBox>
                        <i class="fa-solid fa-user-nurse"></i> <asp:TextBox ID="txtNumProDieta" runat="server" placeholder="Doutor" Height="25px" Width="45px" Enabled="False"></asp:TextBox>                 
                        <i class="fa-solid fa-user-plus"></i> <asp:TextBox ID="txtNumAvaliacao" runat="server" placeholder="Aval." Height="25px" Width="45px" Enabled="False"></asp:TextBox><br/><br/>
                        <i class="fa-solid fa-calendar-days"></i> <asp:TextBox ID="txtDtDieta" runat="server" Height="25px"  placeholder="xx/xx/xxxx" TextMode="DateTime" MaxLength="10" Wrap="True"></asp:TextBox> <br /><br />
                        <div id="descricao">                        
                            <i class="fa-solid fa-weight-scale"></i> <asp:TextBox ID="txtRestAlim" runat="server" placeholder="Restrições alimentares" Height="80px" Width="200px"></asp:TextBox> 
                            <i class="fa-solid fa-street-view"></i> <asp:TextBox ID="txtDieta" runat="server" placeholder="Descrição da dieta..." Height="80px" Width="200px" TextMode="SingleLine"></asp:TextBox> <br/><br/>
                        </div>
                        <asp:Button ID="btnCadastrarDieta" runat="server" Text="Adicionar" OnClick="btnCadastrarDieta_Click" /><br /><br />
                        <asp:Label ID="lblErroDieta" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="buscar" runat="server">
                        <h1>Buscar Cliente</h1>
                        <i class="fa-regular fa-clipboard"></i> <asp:TextBox ID="txtNomeAvaliacoes" runat="server" placeholder="Digite o nome do cliente.." Height="25px" Enabled="True" ></asp:TextBox> <asp:Button ID="btnAvaliacoes" runat="server" Text="Buscar" Height="30px" OnClick="btnAvaliacoes_Click"/>
                        <asp:GridView ID="gvAvaliacoes" runat="server" Columns="6" AlternatingRowStyle-BorderStyle="Solid" AlternatingRowStyle-BorderWidth="2px" AlternatingRowStyle-BorderColor="#D99E89" AlternatingRowStyle-BackColor="#A67153" AlternatingRowStyle-CssClass="animate__fadeIn" AlternatingRowStyle-ForeColor="White" EditRowStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-BackColor="#A67153" CellSpacing="5" CellPadding="10" EditRowStyle-HorizontalAlign="Right" AllowCustomPaging="True" AllowPaging="True" HorizontalAlign="Center" PageIndex="2" PageSize="100" AutoGenerateSelectButton="True" GridLines="Vertical" OnSelectedIndexChanged="gvAvaliacoes_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#D99E89" BorderColor="#A67153" BorderWidth="2px" BorderStyle="Solid" CssClass="animate__fadeIn" ForeColor="White" Font-Overline="False" Font-Size="Medium" HorizontalAlign="Center" Wrap="True"></AlternatingRowStyle>
                        <EditRowStyle HorizontalAlign="Center" BorderStyle="None"></EditRowStyle>
                        <EmptyDataRowStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#A67153" BorderStyle="Solid" BorderColor="#A67153" BorderWidth="2px" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                        <RowStyle BackColor="#D99E89" BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" Font-Size="Medium" ForeColor="White" HorizontalAlign="Center" />
                        <SortedAscendingCellStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
                        <SortedDescendingCellStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
                        </asp:GridView>
                    </div>
                </div>
        </div>
        <div id="pagDieta" runat="server">
            <h1>Dietas Solicitadas:</h1> <br />
            <i class="fa-solid fa-magnifying-glass"></i> <asp:Label ID="lblDieta" runat="server" Text="Buscar Dietas:"></asp:Label>
            <div id="areaBuscar">
                <asp:TextBox ID="txtNomeBuscarDieta" runat="server" Height="30px" Width="300px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div> <br />

            <hr />
            <asp:GridView ID="gvDietas" runat="server" Columns="6" AlternatingRowStyle-BorderStyle="Solid" AlternatingRowStyle-BorderWidth="2px" AlternatingRowStyle-BorderColor="#D99E89" AlternatingRowStyle-BackColor="#A67153" AlternatingRowStyle-CssClass="animate__fadeIn" AlternatingRowStyle-ForeColor="White" EditRowStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-BackColor="#A67153" CellSpacing="5" CellPadding="10" EditRowStyle-HorizontalAlign="Right" AllowCustomPaging="True" AllowPaging="True" HorizontalAlign="Center" OnSelectedIndexChanged="gvDietas_SelectedIndexChanged" PageIndex="2" PageSize="100">
            <AlternatingRowStyle BackColor="#D99E89" BorderColor="#A67153" BorderWidth="2px" BorderStyle="Solid" CssClass="animate__fadeIn" ForeColor="White" Font-Overline="False" Font-Size="Medium" HorizontalAlign="Center" Wrap="True"></AlternatingRowStyle>
            <EditRowStyle HorizontalAlign="Center" BorderStyle="None"></EditRowStyle>
            <EmptyDataRowStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
            <FooterStyle HorizontalAlign="Center" />
            <HeaderStyle BackColor="#A67153" BorderStyle="Solid" BorderColor="#A67153" BorderWidth="2px" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
            <RowStyle BackColor="#D99E89" BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" Font-Size="Medium" ForeColor="White" />
            <SortedAscendingCellStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px" />
            <SortedDescendingCellStyle BorderColor="#A67153" BorderStyle="Solid" BorderWidth="2px"/>
            </asp:GridView>
        </div>
        <div id="pagPerfil" runat="server">
            <h1>Atualizar Perfil</h1>
            <i class="fa-regular fa-user"></i> <asp:Label ID="lblNomeAtualizarPro" runat="server" Text="Nome:"> </asp:Label>
            <asp:TextBox ID="txtNomeAtualizarPro" runat="server" Height="25px" Width="80%" placeholder="Digite o seu nome"></asp:TextBox> <br/> 
            <i class="fa-solid fa-user-tag"></i> <asp:Label ID="lblSobrenomeAtualizarPro" runat="server" Text="Sobrenome:"></asp:Label> 
            <asp:TextBox ID="txtSobrenomeAtualizarPro" runat="server" Height="25px" Width="78%" placeholder="Digite o seu sobrenome"></asp:TextBox> <br/>
            <i class="fa-solid fa-id-card-clip"></i> <asp:Label ID="lblCredencialAtualizarPro" runat="server" Text="Credencial:"></asp:Label>
            <asp:TextBox ID="txtCredencialAtualizarPro" runat="server" Height="25px" Width="80%" placeholder="Digite o seu Credencial"></asp:TextBox> <br />
            <i class="fa-solid fa-user"></i> <asp:Label ID="lblLoginAtualizarPro" runat="server" Text="Login:"></asp:Label> 
            <asp:TextBox ID="txtLoginAtualizarPro" runat="server" Height="25px" Width="80%" placeholder="Digite o seu login" Enabled="False"></asp:TextBox><br/> 
            <i class="fa-solid fa-lock"></i> <asp:Label ID="lblSenhaAtualizarPro" runat="server" Text="Senha:"></asp:Label> 
            <asp:TextBox ID="txtSenhaAtualizarPro" runat="server" TextMode="Password" Height="25px" Width="80%" placeholder="Digite a sua senha"></asp:TextBox> <br/> 
            <i class="fa-solid fa-calendar-days"></i> <asp:Label ID="lblDataNascAtualizarPro" runat="server" Text="Data de Nascimento:"></asp:Label>  
            <asp:TextBox ID="txtDataNascAtualizarPro" runat="server" Height="25px" Width="81%" placeholder="xx/xx/xxxx" TextMode="DateTime" MaxLength="10" Wrap="True"></asp:TextBox>  <br/> 
            <i class="fa-solid fa-mobile"></i> <asp:Label ID="lblCelAtualizarPro" runat="server" Text="Telefone:"></asp:Label> 
            <asp:TextBox ID="txtCelAtualizarPro" runat="server" Height="25px" Width="80%" placeholder="xx xxxxxxxxx" TextMode="Phone"></asp:TextBox> <br/>
            <div id="perfilAtualizarPro"> <i class="fa-solid fa-address-card"> </i> <asp:TextBox ID="txtPerfilAtualizarPro" runat="server" Height="25px" Width="80%" TextMode="SingleLine" Text="Profissional" Enabled="False"></asp:TextBox></div><br/>
            <asp:Label ID="lblErroAtualizacao" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" /><br/>
            

            <span><i class="fa-solid fa-circle-exclamation"></i> <pre>Obs: após a atualização, o usuário 
será desconectado automaticamente para atualização de dados. </pre> </span>
                                                                 
               

        </div>
        <div id="CadastrarProfissional" runat="server">
            <h1>Cadastrar Profissional</h1>
            <i class="fa-regular fa-user"></i> <asp:Label ID="lblNomeCadastrarPro" runat="server" Text="Nome:"> </asp:Label>
            <asp:TextBox ID="txtNomeCadastrarPro" runat="server" Height="25px" Width="80%" placeholder="Digite o seu nome"></asp:TextBox> <br/> 
            <i class="fa-solid fa-user-tag"></i> <asp:Label ID="lblSobrenomeCadastrarPro" runat="server" Text="Sobrenome:"></asp:Label> 
            <asp:TextBox ID="txtSobrenomeCadastrarPro" runat="server" Height="25px" Width="78%" placeholder="Digite o seu sobrenome"></asp:TextBox> <br/>
            <i class="fa-solid fa-id-card-clip"></i> <asp:Label ID="lblCredencialCadastrarPro" runat="server" Text="Credencial:"></asp:Label>
            <asp:TextBox ID="txtCredencialCadastrarPro" runat="server" Height="25px" Width="80%" placeholder="Digite o seu Credencial"></asp:TextBox> <br />
            <i class="fa-solid fa-user"></i> <asp:Label ID="lblLoginCadastrarPro" runat="server" Text="Login:"></asp:Label> 
            <asp:TextBox ID="txtLoginCadastrarPro" runat="server" Height="25px" Width="80%" placeholder="Digite o seu login"></asp:TextBox><br/> 
            <i class="fa-solid fa-lock"></i> <asp:Label ID="lblSenhaCadastrarPro" runat="server" Text="Senha:"></asp:Label> 
            <asp:TextBox ID="txtSenhaCadastrarPro" runat="server" TextMode="Password" Height="25px" Width="80%" placeholder="Digite a sua senha"></asp:TextBox> <br/> 
            <i class="fa-solid fa-calendar-days"></i> <asp:Label ID="lblDataNascCadastrarPro" runat="server" Text="Data de Nascimento:"></asp:Label>  
            <asp:TextBox ID="txtDataNascCadastrarPro" runat="server" Height="25px" Width="81%" placeholder="xx/xx/xxxx" TextMode="DateTime" MaxLength="10" Wrap="True"></asp:TextBox>  <br/> 
            <i class="fa-solid fa-mobile"></i> <asp:Label ID="lblCelCadastrarPro" runat="server" Text="Telefone:"></asp:Label> 
            <asp:TextBox ID="txtCelCadastrarPro" runat="server" Height="25px" Width="80%" placeholder="xx xxxxxxxxx" TextMode="Phone"></asp:TextBox> <br/>
            <i class="fa-solid fa-address-card"></i> <asp:Label ID="lblPerfilCadastrarPro" runat="server" Text="Perfil do Profissional:" ></asp:Label>
            <asp:DropDownList ID="DropPerfilCadastrarPro" runat="server" Height="25px" Width="80%">
                <asp:ListItem>Cliente</asp:ListItem>
                <asp:ListItem>Profissional</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:DropDownList><br />

            <asp:Button ID="btnCadastrarPro" runat="server" Text="Cadastrar" OnClick="btnCadastrarPro_Click" /><br />
            <br />
            <asp:Label ID="lblErroCadastrarPro" runat="server" Text=""></asp:Label>
        </div>
    <footer id="footer" runat="server">
            <hr/> <p>&copy;Desenvolvido por Rafael Gomes</p>
    </footer>
    </form>
</body>
</html>
