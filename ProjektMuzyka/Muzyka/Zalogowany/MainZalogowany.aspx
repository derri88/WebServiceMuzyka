<%@ Page Title="" Language="C#" MasterPageFile="~/Muzyka/Zalogowany/Zalogowany.Master" AutoEventWireup="true" CodeBehind="MainZalogowany.aspx.cs" Inherits="ProjektMuzyka.Muzyka.Zalogowany.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div id="Newsy" class="FloatLeft DolnyOdstep">
        <h1>Newsy</h1>
        <asp:Panel ID="News0" CssClass="News DolnyOdstep" runat="server">
            <h1>Struktura newsów</h1>
            <div>
                Newsy mają domyślnie być dodawane automatycznie z bazy danych.
                <br />
                To jest tylko test, by nie było pusto ;)
            </div>
        </asp:Panel>
        <asp:Panel ID="News1" CssClass="News DolnyOdstep" runat="server">
            <h1>Struktura</h1>
            <div>I mają wygladać tak</div>
        </asp:Panel>
    </div>
    <div id="InfoProjekt" class="FloatRight News GornyOdstep GornaKreska">
        <h1>O Projekcie</h1>
        <div id="oProjekcie">Projekt wykonany na potrzeby zajęć z Technologii Tworzenia Stron Internetowych</div>
    </div>
</asp:Content>
