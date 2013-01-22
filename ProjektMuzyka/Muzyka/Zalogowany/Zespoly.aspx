<%@ Page Title="" Language="C#" MasterPageFile="~/Muzyka/Zalogowany/Zalogowany.Master" AutoEventWireup="true" CodeBehind="Zespoly.aspx.cs" Inherits="ProjektMuzyka.Muzyka.Zalogowany.Zespoly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 30%;
            text-align: right;
            height: 54px;
        }
        .auto-style2 {
            width: 70%;
            text-align: left;
            height: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="GornyOdstep GornaKreska">
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
            <%--        <asp:Button ID="Szukaj" runat="server" CssClass="Centered" Text="Szukaj" OnClick="Szukaj_Click" />--%>
            <asp:Button ID="DodajZespol" runat="server" Text="Dodaj nowy zespół" OnClick="DodajZespol_Click" />
            <asp:Button ID="SzukajZespol" runat="server" Text="Szukaj" OnClick="SzukajZespol_Click" />
            <section id="InfoEdycja">
                <asp:Label ID="InfoEdycjaText" runat="server" Visible="false"></asp:Label>
            </section>
            <asp:Panel ID="EdycjaZespol" runat="server" Visible="false">
                <asp:Label ID="EdycjaZespolNaglowek" CssClass="GornyOdstep GornaKreska Centered" runat="server">Edytuj dane zespołu</asp:Label>
                <table class="GornaKreska GornyOdstep Centered">
                    <tr>
                        <td class="Width30">Nazwa:</td>
                        <td class="Width70">
                            <asp:TextBox ID="EdytujNazwa" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="Width30">Gatunek:</td>
                        <td class="Width70">
                            <asp:DropDownList ID="EdytujGatunek" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Rok założenia:</td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="EdytujRokZalozenia" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="Width30">Rok końcowy:</td>
                        <td class="Width70">
                            <asp:DropDownList ID="EdytujRokKoncowy" runat="server"></asp:DropDownList></td>
                    </tr>
                </table>
                <section id="ZleDaneEdycji">
                    <asp:Label ID="ZleDaneEdycjiText" Visible="false" runat="server">Nie można zaktualizować danych, sprawdź czy wszystkie pola zostały wypełnione poprawnie</asp:Label>
                </section>
                <asp:Button ID="EdycjaAnuluj" CssClass="Centered" runat="server" Text="Anuluj" OnClick="EdycjaAnuluj_Click" />
                <asp:Button ID="EdycjaZapisz" CssClass="Centered" runat="server" Text="Zapisz" OnClick="EdycjaZapisz_Click" />
            </asp:Panel>
        </section>

        <section id="UpdatePanelWyszukaneZespoly" class="FloatRight">
            <%-- <asp:UpdatePanel ID="WyszukaneZespoly" runat="server">
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
        </asp:UpdatePanel>--%>
            <asp:SqlDataSource ID="SqlDataLiczbaPlyt" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataZespoly" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"></asp:SqlDataSource>
            <section class="Centered GornyOdstep GornaKreska">
                <asp:GridView ID="ZespolyWidok" runat="server" CssClass="Centered" AutoGenerateColumns="false" DataSourceID="SqlDataZespoly" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="ZespolyWidok_SelectedIndexChanged">

                    <Columns>
                        <asp:BoundField DataField="Nazwa" HeaderText="Zespol" ReadOnly="True" />
                        <asp:BoundField DataField="Nazwa1" HeaderText="Gatunek" ReadOnly="true" />
                        <%--SortExpression="Gatunek" />--%>
                        <asp:BoundField DataField="Rok_start" HeaderText="Rok założenia" ReadOnly="true" />
                        <%--SortExpression="Rok założenia" />--%>
                        <asp:BoundField DataField="Rok_end" HeaderText="Rok Końcowy" ReadOnly="true" />
                        <%--SortExpression="Rok końcowy" />--%>
                        <asp:BoundField DataField="ID_zespol" HeaderText="ID zespolu" ReadOnly="true" Visible="true" />
                        <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Edytuj" />
                    </Columns>

                </asp:GridView>
            </section>
        </section>
    </section>
</asp:Content>
