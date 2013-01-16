<%@ Page Title="" Language="C#" MasterPageFile="~/Muzyka/Zalogowany/Zalogowany.Master" AutoEventWireup="true" CodeBehind="MainZalogowany.aspx.cs" Inherits="ProjektMuzyka.Muzyka.Zalogowany.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div id="Newsy" class="FloatLeft">
                <h1>Newsy</h1>
                <asp:Panel ID="Panel1" runat="server" >
                </asp:Panel>
            </div>
            <div id="InfoProjekt" class="FloatRight">
                <h1>O Projekcie</h1>
                Projekt wykonany na potrzeby zajęć z Technologii Tworzenia Stron Internetowych
            </div>
</asp:Content>
