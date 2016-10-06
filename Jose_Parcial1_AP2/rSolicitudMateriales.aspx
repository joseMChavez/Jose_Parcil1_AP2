<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="rSolicitudMateriales.aspx.cs" Inherits="Jose_Parcial1_AP2.rSolicitudMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 229px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="IdLabel" runat="server" Text="Id:"></asp:Label>
                <asp:TextBox ID="IdTextBox" runat="server" Width="112px"></asp:TextBox>
                <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
            </td>
            <td><asp:Label ID="RazonLabel" runat="server" Text="Razon:"></asp:Label>
                <asp:TextBox ID="RazonTextBox" runat="server" Width="288px"></asp:TextBox></td>
           
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="MateriaLabel" runat="server" Text="Materia"></asp:Label>
            </td>
            <td>
                <asp:Label ID="CantidadLabel" runat="server" Text="Cantidad"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td class="auto-style1"><asp:TextBox ID="MateriaTextBox" runat="server" Width="225px"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="CantidadTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td>
                <asp:GridView ID="MaterialesGridView" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Material" HeaderText="Material" ReadOnly="True" SortExpression="Material" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ReadOnly="True" SortExpression="Cantidad" />
                    </Columns>

                </asp:GridView>
            </td>
            
            
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td>
                <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />


            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
