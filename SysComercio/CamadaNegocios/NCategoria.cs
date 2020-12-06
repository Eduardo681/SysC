using System;
using System.Collections.Generic;
using System.Text;
using CamadaDados;
using System.Data;
namespace CamadaNegocios
{
    public class NCategoria
    {
        // CRUD do OBJ de categoria
        public static string Inserir(string nome, string descricao)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Inserir(Obj);
        }
        public static string Editar(int idcategoria, string nome, string descricao)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Editar(Obj);
        }
        public static string Excluir(int idcategoria)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Excluir(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        public static DataTable BuscarNome(string textoBuscar)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
