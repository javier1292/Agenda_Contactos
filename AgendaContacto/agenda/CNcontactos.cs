using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using datos;

namespace agenda
{
    public class CNcontactos
    {
        public bool acceso;
        public int ID_usuario;

        private contactos objetocd = new contactos();

        

        private Bdconexion Conexion = new Bdconexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable mostrarcontacto()
        {

            DataTable tabla = new DataTable();
            tabla = objetocd.mostrarContactos();
            return tabla;
        }


        public void insertarusuario(string Nombre, String Apellido, String Nombre_usuario, string Contraseña, string Confirmar_contraseña)
        {
            objetocd.Insertar(Nombre, Apellido, Nombre_usuario, Contraseña, Confirmar_contraseña);


        }
        public void Editar(string Nombre, String Apellido, String Direccion,string Numero_personal,string Numero_trabajo, int ID_contacto)
        {

            objetocd.Editar (ID_contacto, Nombre, Apellido, Direccion, Numero_personal,Numero_trabajo);

        }
        public void Login(string Usuario, string Contraseña) 
        {
             
            objetocd.Login(Usuario, Contraseña);
            acceso = objetocd.acceso;

        }


        public void insertarC(string Nombre, String Apellido, String Direccion, string Numero_personal, string Numero_trabajo)
        {

           
            objetocd.insertarC(Nombre, Apellido, Direccion, Numero_personal, Numero_trabajo);


        }

        public void eliminiar(String ID_contactos)
        {

            objetocd.eliminar(Convert.ToInt32(ID_contactos));

        }


    }


}
