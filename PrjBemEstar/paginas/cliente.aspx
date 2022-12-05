<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="PrjBemEstar.cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="../css/reset.css"   />    
    <link rel="stylesheet" type="text/css" href="../css/Cliente.css"   />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/all.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"/> 
    <title>Bem Estar</title>
</head>
<body>
    <form id="cliente" runat="server">
        <div id="menu" runat="server">
            <asp:LinkButton ID="linkInicio" runat="server" OnClick="linkInicio_Click"><i class="fa-sharp fa-solid fa-house"></i> Início</asp:LinkButton> 
            <asp:LinkButton ID="linkIMC" runat="server" OnClick="linkIMC_Click"><i class="fa-regular fa-clipboard"></i> IMC</asp:LinkButton> 
            <asp:LinkButton ID="linkDieta" runat="server" OnClick="linkDieta_Click"><i class="fa-solid fa-thumbtack"></i>  Visualizar Dieta</asp:LinkButton>
            <i class="fa-solid fa-circle-user"></i> <asp:LinkButton ID="linkPerfil" runat="server" OnClick="linkPerfil_Click"></asp:LinkButton>      
            <asp:LinkButton ID="linkSair" runat="server" OnClick="linkSair_Click"> <i class="fa-sharp fa-solid fa-right-from-bracket"></i> Sair</asp:LinkButton>
            <asp:LinkButton ID="DADOSLOGIN" runat="server" Visible="False"></asp:LinkButton>

        </div> <hr/> 
        <div id="FUNDO" runat="server"> 
            <h1>BemEstar</h1>   <hr/>    <h3>Sua saúde no melhor estado</h3>
        </div>
        <div id="pagIMC" runat="server">
            <h1>Índice de Massa Corporal</h1>
            <div id="figure" runat="server">
                <img src="../img/abaixo.png" id="abaixo" alt="Figura Abaixo do Peso" runat="server"/>
                <img src="../img/normal.png" id="normal" alt="Figura do Peso Normal" runat="server"/>
                <img src="../img/acima.png" id="acima" alt="Figura Acima do Peso" runat="server"/>
                <img src="../img/obesidade1.png" id="obesidade1" alt="Figura Obesidade 1" runat="server"/>
                <img src="../img/obesidade2.png" id="obesidade2" alt="Figura Obesidade 2" runat="server"/>
            </div>
            <div id="container">
                <div id="calculoIMC">
                    <h1>Cálculo IMC</h1> <br />
                    <i class="fa-solid fa-weight-scale"></i> <asp:TextBox ID="txtPeso" runat="server" placeholder="Peso" Height="25px" Enabled="False" ></asp:TextBox> <br/>
                    <i class="fa-solid fa-street-view"></i> <asp:TextBox ID="txtAltura" runat="server" placeholder="Altura" Height="25px" Enabled="False" ></asp:TextBox> <br/>
                    <i class="fa-solid fa-scale-unbalanced-flip"></i> <asp:Label ID="lblIMC" runat="server" Text="IMC:"></asp:Label>
                    <asp:TextBox ID="txtResultadoIMC" runat="server" Height="50px" Width="20%" Enabled="False" placeholder="IMC"></asp:TextBox> <br/>
                    <asp:Label ID="lblAviso" runat="server" Text="Seu IMC tem que ficar entre XXkg á XXkg"></asp:Label>
                </div>
                <div id="buscar" runat="server">
                    <asp:Button ID="btnAvaliacoes" runat="server" Text="Buscar Avaliações" Height="30px" Width="100%" OnClick="btnAvaliacoes_Click"/>
                                    

                    <asp:GridView ID="gvAvaliacoes" runat="server" Columns="6" AlternatingRowStyle-BorderStyle="Solid" AlternatingRowStyle-BorderWidth="2px" AlternatingRowStyle-BorderColor="#D99E89" AlternatingRowStyle-BackColor="#A67153" AlternatingRowStyle-CssClass="animate__fadeIn" AlternatingRowStyle-ForeColor="White" EditRowStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-BackColor="#A67153" CellSpacing="1" CellPadding="5" EditRowStyle-HorizontalAlign="Right" AllowCustomPaging="True" AllowPaging="True" HorizontalAlign="Center" PageIndex="2" PageSize="100" AutoGenerateSelectButton="True" GridLines="Vertical" OnSelectedIndexChanged="gvAvaliacoes_SelectedIndexChanged">
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
            </div> <br/>
        </div>
        <div id="pagDieta" runat="server">
            <h1>Dietas Solicitadas:</h1> <br />
            <i class="fa-solid fa-calendar-days"></i> <asp:Label ID="lblData" runat="server" Text="Selecione a data da Avaliação:"></asp:Label>
            <div id="areaBuscar">
                <asp:TextBox ID="txtData" runat="server" Height="30px" Width="300px" TextMode="Date"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div> <br />

            <hr />
            <asp:GridView ID="gvDietas" runat="server" Columns="6" AlternatingRowStyle-BorderStyle="Solid" AlternatingRowStyle-BorderWidth="2px" AlternatingRowStyle-BorderColor="#D99E89" AlternatingRowStyle-BackColor="#A67153" AlternatingRowStyle-CssClass="animate__fadeIn" AlternatingRowStyle-ForeColor="White" EditRowStyle-BorderStyle="None" HeaderStyle-BorderStyle="None" HeaderStyle-BackColor="#A67153" CellSpacing="1" CellPadding="5" EditRowStyle-HorizontalAlign="Right" AllowCustomPaging="True" AllowPaging="True" HorizontalAlign="Center" OnSelectedIndexChanged="gvDietas_SelectedIndexChanged" PageIndex="2" PageSize="100">
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
            <i class="fa-regular fa-user"></i> <asp:Label ID="lblNome" runat="server" Text="Nome:"> </asp:Label>
            <asp:TextBox ID="txtNome" runat="server" Height="25px" Width="80%" placeholder="Digite o seu nome"></asp:TextBox> <br/> 
            <i class="fa-solid fa-user-tag"></i> <asp:Label ID="lblSobrenome" runat="server" Text="Sobrenome:"></asp:Label> 
            <asp:TextBox ID="txtSobrenome" runat="server" Height="25px" Width="78%" placeholder="Digite o seu sobrenome"></asp:TextBox> <br/>
            <i class="fa-solid fa-user"></i> <asp:Label ID="lblLogin" runat="server" Text="Login:"></asp:Label> 
            <asp:TextBox ID="txtLoginCadastrar" runat="server" Height="25px" Width="80%" placeholder="Digite o seu login" Enabled="False"></asp:TextBox><br/> 
            <i class="fa-solid fa-lock"></i> <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label> 
            <asp:TextBox ID="txtSenhaCadastrar" runat="server" TextMode="Password" Height="25px" Width="80%" placeholder="Digite a sua senha"></asp:TextBox> <br/> 
            <i class="fa-solid fa-calendar-days"></i> <asp:Label ID="lblDataNasc" runat="server" Text="Data de Nascimento:"></asp:Label>  
            <asp:TextBox ID="txtDataNasc" runat="server" Height="25px" Width="81%" placeholder="xx/xx/xxxx" TextMode="DateTime" MaxLength="10" Wrap="True"></asp:TextBox>  <br/> 
            <i class="fa-solid fa-mobile"></i> <asp:Label ID="lblCel" runat="server" Text="Telefone:"></asp:Label> 
            <asp:TextBox ID="txtCel" runat="server" Height="25px" Width="80%" placeholder="xx xxxxxxxxx" TextMode="Phone"></asp:TextBox> <br/> 
            <div id="perfil"> <i class="fa-solid fa-address-card"> </i> <asp:TextBox ID="txtPerfil" runat="server" Height="25px" Width="80%" TextMode="SingleLine" Text="Cliente" Enabled="False"></asp:TextBox></div><br/>
            <asp:Label ID="lblErroAtualizacao" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" /><br/>
            

            <span><i class="fa-solid fa-circle-exclamation"></i> <pre>Obs: após a atualização, o usuário 
será desconectado automaticamente para atualização de dados. </pre> </span>
                                                                 
               

        </div>        
    <footer>
            <hr/> <p>&copy;Desenvolvido por Rafael Gomes</p>
    </footer>
    </form>
</body>
</html>
