<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="diceRoller._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center;">
        <h1>Let the good times roll...</h1>

        <asp:Label ID="numberLabel" runat="server" Text="How many dice would you like to roll?"></asp:Label>&nbsp;
    <asp:TextBox ID="numBox" runat="server" MaxLength="2" ToolTip="Please enter a number greater then 0." TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="sideLabel" runat="server" Text="How many sides does your dice have?"></asp:Label>&nbsp;
    <asp:TextBox ID="sideBox" runat="server" MaxLength="3" ToolTip="Please enter a number greater then 0." TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <br />
        <center>
        <div style="border-radius: 15px; background-color: cornflowerblue; width: 150px; height: 25px; text-align: center; border-radius: 25px;">
            <asp:Button ID="RollBtn" runat="server" Text="Let 'em roll!" OnClick="RollBtn_Click" BackColor="Transparent" ForeColor="White" BorderStyle="None" Style="width: 100%; height: 100%"/>
        </div>
            </center>
        <br />
        <br />
        <br />
        <div id="outputDiv" runat="server"></div>
    </div>
</asp:Content>
