<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PrjBemEstar._default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="css/reset.css"/>
    <link rel="stylesheet" href="css/default.css"/>
    <link rel="stylesheet" type="text/css" href="fontawesome/css/all.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"/> 
</head>
<body>            
    <form id="Login" runat="server">             <%--  PARTE DO LOGIN--%>
        <img src="img/LOGO.gif" alt="Logotipo" id="LOGO"/>       
        <div id="logar" runat="server">
            <h1> Faça o seu Login: </h1> <br/>
            <i class="fa-solid fa-user"></i> <asp:TextBox ID="txtLogin" runat="server" Height="25px" Width="80%" placeholder="Digite o seu login"></asp:TextBox> <br/>
            <i class="fa-solid fa-lock"></i> <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Height="25px" Width="80%" placeholder="Digite a sua senha"></asp:TextBox>  
            <asp:Button ID="btnAcessar" runat="server" Text="Acessar" OnClick="btnAcessar_Click"/> <br/>
        
            <i class="fa-solid fa-user-tie"></i> <asp:LinkButton ID="Cliente" runat="server" OnClick="Cliente_Click">Cadastrar Cliente</asp:LinkButton>
            <asp:Label ID="lblErro" runat="server" Text=""></asp:Label> 
        </div>
        <div id="ParteCadastrar" runat="server">      <%--  PARTE DO CADASTRO--%>
                <h1> Faça o seu Cadastro: </h1> <br/>
            <div id="txt" >   
                <i class="fa-regular fa-user"></i> <asp:TextBox ID="txtNome" runat="server" Height="25px" Width="80%" placeholder="Digite o seu nome"></asp:TextBox> <br/> 
                <i class="fa-solid fa-user-tag"></i> <asp:TextBox ID="txtSobrenome" runat="server" Height="25px" Width="78%" placeholder="Digite o seu sobrenome"></asp:TextBox> <br/>
                <i class="fa-solid fa-user"></i> <asp:TextBox ID="txtLoginCadastrar" runat="server" Height="25px" Width="80%" placeholder="Digite o seu login"></asp:TextBox><br/> 
                <i class="fa-solid fa-lock"></i> <asp:TextBox ID="txtSenhaCadastrar" runat="server" TextMode="Password" Height="25px" Width="80%" placeholder="Digite a sua senha"></asp:TextBox> <br/> 
                <i class="fa-solid fa-calendar-days"></i> <asp:TextBox ID="txtDataNasc" runat="server" Height="25px" Width="81%" placeholder="xx/xx/xxxx" TextMode="Date" MaxLength="11" Wrap="True"></asp:TextBox>  <br/> 
                <i class="fa-solid fa-mobile"></i> <asp:TextBox ID="txtCel" runat="server" Height="25px" Width="80%" placeholder="xx xxxxxxxxx" TextMode="Phone"></asp:TextBox> <br/>
                <div id="perfil" runat="server"> <i class="fa-solid fa-address-card"> </i> <asp:TextBox ID="txtTipo" runat="server" Height="25px" Width="78%" Enabled="False"></asp:TextBox> <br /> </div>
<%--               <div id="credencial" runat="server" visible="True"> 
                     
                </div><br/>--%>
            </div> <br/>                

            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click"/> <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"/> <br/>
            <asp:Label ID="lblErroCadastrar" runat="server" Text=""></asp:Label>
        </div>            

        <footer>    
            <address>
                &copy;Desenvolvido por Rafael Gomes
            </address>
        </footer>
    </form>
    <img src="img/IMC.jpeg" alt="Foto Banner" id="IMC"/>
</body>
</html>
