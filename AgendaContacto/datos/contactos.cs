using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace datos
{
     public class contactos
    {
        public bool acceso;
        
         

        private Bdconexion Conexion  = new Bdconexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

       
        public DataTable mostrarContactos()
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "select * from contactos where ID_usuario="+User.user;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Conexion.CerrarConexion();
            return tabla;


        }

        public bool Login(string Usuario, string Contraseña) 
        {
           
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SELECT Nombre_usuario, Contraseña FROM usuario where Nombre_usuario='" + Usuario + "' And Contraseña='" + Contraseña + "'";
            leer = comando.ExecuteReader();
            if (leer.Read())
            {
                acceso = true;
            }
            else {
                acceso = false;
            }

            Conexion.CerrarConexion();
            comando.Connection = Conexion.AbrirConexion();

            string query = "SELECT ID_usuario FROM usuario where Nombre_usuario='" + Usuario + "' And Contraseña='" + Contraseña + "'";
            comando.CommandText = query;

            User.user = Convert.ToInt32(comando.ExecuteScalar());
            
            Conexion.CerrarConexion();


            return acceso;

        }

        public void Insertar(string Nombre, String Apellido, String Nombre_usuario, string Contraseña, string Confirmar_contraseña) {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "insert into usuario values ('" + Nombre + "','" + Apellido + "','" + Nombre_usuario + "','" + Contraseña + "','" + Confirmar_contraseña + "')";

            comando.ExecuteNonQuery();



        }

        

        public void Editar(int ID_contacto,string Nombre, string Apellido, string direccion, string Nummero_personal,string Numero_trabajo)
        {

            SqlCommand comando = new SqlCommand();


            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "editar ";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idUser", User.user);
            comando.Parameters.AddWithValue("@nom", Nombre);
            comando.Parameters.AddWithValue("@Apel", Apellido);
            comando.Parameters.AddWithValue("@Dire", direccion);
            comando.Parameters.AddWithValue("@Nump", Nummero_personal);
            comando.Parameters.AddWithValue("@Numt", Numero_trabajo);
            comando.Parameters.AddWithValue("@ID", ID_contacto);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();




        }

        public void Eliminar (int ID_contacto)
        {


            

            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText= "Eliminar";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("IDc", ID_contacto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void insertarC(string Nombre, String Apellido, String Direccion , string Numero_personal, string Numero_trabajo)
        {
            

            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "insert into contactos values ('"+User.user+"','" + Nombre + "','" + Apellido + "','" + Direccion + "','" + Numero_personal + "','" + Numero_trabajo + "')";

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void eliminar (int Id_contacto)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "Eliminar";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("IDc", Id_contacto);

            comando.BeginExecuteNonQuery();

            comando.Parameters.Clear();

        }

        public void eliminiar(String ID_contactos)
        {
            
        }

    }
}
