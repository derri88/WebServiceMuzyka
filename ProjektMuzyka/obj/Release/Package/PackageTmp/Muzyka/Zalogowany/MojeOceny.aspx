<%@ Page Title="" Language="C#" MasterPageFile="~/Muzyka/Zalogowany/Zalogowany.Master" AutoEventWireup="true" CodeBehind="MojeOceny.aspx.cs" Inherits="ProjektMuzyka.Muzyka.Zalogowany.MojeOceny" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="TabelaPlyty" class="Centered GornaKreska GornyOdstep DolnyOdstep">
        <h6 class="Width100">&nbsp</h6>
    <asp:Table ID="MojePlyty" runat="server" CssClass="Centered DolnyOdstep">
        <asp:TableHeaderRow CssClass="TableHead">
            <asp:TableCell>Plyta</asp:TableCell>
            <asp:TableCell>Zespol</asp:TableCell>
            <asp:TableCell>Gatunek</asp:TableCell>
            <asp:TableCell>Rok wydania</asp:TableCell>
            <asp:TableCell>Sciezki</asp:TableCell>
            <asp:TableCell>Ocena</asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
        <h6 class="Width100">&nbsp</h6>
<%--    <asp:TextBox ID="Zmiana" runat="server" TextMode="MultiLine" Width="300" Height="300"></asp:TextBox>--%>
    <asp:Button ID="ZapiszOceny" runat="server" Text="Zapisz oceny" CssClass="Centered GornyOdstep" OnClick="ZapiszOceny_Click" />
        <h6><asp:Label ID="MojeOcenyInfo" runat="server" Text="Zaaktualizowano oceny użytkownika" CssClass="Width100 Centered Info" Visible="false"></asp:Label></h6>
    </section>
</asp:Content>
