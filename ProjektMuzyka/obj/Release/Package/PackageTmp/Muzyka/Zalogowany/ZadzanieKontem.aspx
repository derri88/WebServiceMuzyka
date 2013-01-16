<%@ Page Title="" Language="C#" MasterPageFile="~/Muzyka/Zalogowany/Zalogowany.Master" AutoEventWireup="true" CodeBehind="ZadzanieKontem.aspx.cs" Inherits="ProjektMuzyka.Muzyka.Zalogowany.ZarzadzanieKontem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="TabelaDanych" class="Centered GornaKreska GornyOdstep DolnyOdstep">
        <div class="TableHead">Twoje dane:</div>
        <asp:Table ID="TwojeDane" CssClass="Centered" runat="server">
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Nick</asp:TableCell>
                <asp:TableCell ID="Nick" CssClass="KomorkaTabeli"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Imie</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:TextBox ID="Imie" CssClass="SzerokoscBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Nazwisko</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:TextBox ID="Nazwisko" CssClass="SzerokoscBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Data urodzenia</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:TextBox ID="DataUrodzenia" CssClass="SzerokoscBox" runat="server" TextMode="DateTime"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Płeć</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:DropDownList ID="Plec" CssClass="SzerokoscBox" runat="server">
                        <asp:ListItem>Mężczyzna</asp:ListItem>
                        <asp:ListItem>Kobieta</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">e-mail</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:TextBox ID="Mail" CssClass="SzerokoscBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Kraj</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:TextBox ID="Kraj" CssClass="SzerokoscBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Miasto</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:TextBox ID="Miasto" CssClass="SzerokoscBox" runat="server" AutoCompleteType="None"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell CssClass="KomorkaTabeli">Status</asp:TableCell>
                <asp:TableCell CssClass="KomorkaTabeli">
                    <asp:Label ID="Status" CssClass="SzerokoscBox" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
            <asp:Button ID="ZapiszZmiany" runat="server" Text="Zapisz zmiany" OnClick="ZapiszZmiany_Click" />
    </section>
</asp:Content>
