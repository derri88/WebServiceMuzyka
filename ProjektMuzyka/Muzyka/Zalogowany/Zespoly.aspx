<%@ Page Title="" Language="C#" MasterPageFile="~/Muzyka/Zalogowany/Zalogowany.Master" AutoEventWireup="true" CodeBehind="Zespoly.aspx.cs" Inherits="ProjektMuzyka.Muzyka.Zalogowany.Zespoly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="SzukajZespoly" class="FloatLeft GornyOdstep">
        <table>
            <tr>
                <td class="Width30">Nazwa:</td>
                <td class="Width70">
                    <asp:TextBox ID="NazwaZespolu" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="Width30">Gatunek:</td>
                <td class="Width70">
                    <asp:DropDownList ID="GatunekZespolu" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="Width30">Rok założenia:</td>
                <td class="Width70">od:
                    <asp:DropDownList ID="RokZalozeniaZespoluOd" runat="server"></asp:DropDownList>
                    do:
                    <asp:DropDownList ID="RokZalozeniaZespoluDo" runat="server"></asp:DropDownList></td>
            </tr>
<%--            <tr>
                <td class="Width30">Warunki roku założenia:</td>
                <td class="Width70">
                    <asp:RadioButton ID="RZ_Mniejsze" Text="<" CssClass="RadioButton" runat="server" />
                    <asp:RadioButton ID="RZ_MniejszeRowne" Text="<=" CssClass="RadioButton" runat="server" />
                    <asp:RadioButton ID="RZ_Rowne" Text="=" CssClass="RadioButton" Checked="true" runat="server" />
                    <asp:RadioButton ID="RZ_WiekszeRowne" Text=">=" CssClass="RadioButton" runat="server" />
                    <asp:RadioButton ID="RZ_Wieksze" Text=">" CssClass="RadioButton" runat="server" />
                </td>
            </tr>--%>
            <tr>
                <td class="Width30">Rok końcowy:</td>
                <td class="Width70">od:
                    <asp:DropDownList ID="RokKoncowyZespoluOd" runat="server"></asp:DropDownList>
                    do:
                    <asp:DropDownList ID="RokKoncowyZespoluDo" runat="server"></asp:DropDownList></td>
            </tr>
        </table>
        <asp:Button ID="Szukaj" runat="server" CssClass="Centered" Text="Szukaj" OnClick="Szukaj_Click" />
    </section>

    <section id="UpdatePanelWyszukaneZespoly" class="FloatRight">
        <asp:UpdatePanel ID="WyszukaneZespoly" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Szukaj" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:Table ID="ZespolyDane" CssClass="Centered" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableCell>Nazwa</asp:TableCell>
                        <asp:TableCell>Gatunek</asp:TableCell>
                        <asp:TableCell>Rok założenia</asp:TableCell>
                        <asp:TableCell>Rok końcowy</asp:TableCell>
                        <asp:TableCell>Liczba płyt</asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <asp:TextBox ID="StatusWyszukiwania" runat="server"></asp:TextBox>

            </ContentTemplate>
        </asp:UpdatePanel>
        <%--        <asp:Table ID="ZespolyDane" CssClass="Centered" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell>Nazwa</asp:TableCell>
                <asp:TableCell>Gatunek</asp:TableCell>
                <asp:TableCell>Rok założenia</asp:TableCell>
                <asp:TableCell>Rok końcowy</asp:TableCell>
                <asp:TableCell>Liczba płyt</asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:TextBox ID="StatusWyszukiwania" runat="server"></asp:TextBox>--%>
    </section>

</asp:Content>
