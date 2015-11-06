using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Personas : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        Telefonos telefono = new Telefonos();

        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int sexo { get; set; }
        public int EstadoCivil { get; set; }
        public List<Telefonos> Telefono { get; set; }

        public Personas()
        {
            this.PersonaId = 0;
            this.Nombre = "";
            this.Direccion = "";
            this.sexo = 0;
            this.EstadoCivil = 0;
            Telefono = new List<Telefonos>();
        }


        public void AgregarTelefonos(int TelefonoId, string Telefono)
        {
            this.Telefono.Add(new Telefonos(TelefonoId,Telefono));
        }

        public void LimpiarList()
        {
            this.Telefono.Clear();
        }
        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dtTelefono = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos(String.Format("select  * from Personas where PersonaId = {0}",IdBuscado));
                this.Nombre = dt.Rows[0]["Nombres"].ToString();
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.sexo = Convert.ToInt32(dt.Rows[0]["Sexo"]);
                this.EstadoCivil = Convert.ToInt32(dt.Rows[0]["EstadoCivil"]);
                
                dtTelefono = conexion.ObtenerDatos(String.Format( "select p.Nombres, pt.Telefono as Telefono from Personas p inner join PersonasTelefonos pt on p.PersonaId = pt.PersonaId where p.PersonaId = {0}",IdBuscado));
                LimpiarList();
                foreach (DataRow row in dtTelefono.Rows)
                {
                    AgregarTelefonos(1,row["Telefono"].ToString());
                }
                
                    
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public override bool Editar()
        {
            StringBuilder comando = new StringBuilder();
            bool retorno = false;
            try
            {
                

                retorno = conexion.Ejecutar(String.Format("update Personas set Nombres ='{0}',Direccion ='{1}',Sexo = {2},EstadoCivil = {3} where PersonaId = {4}",
                    this.Nombre,this.Direccion,this.sexo,this.EstadoCivil,this.PersonaId));

                retorno = conexion.Ejecutar("delete from PersonasTelefonos where PersonaId = "+this.PersonaId);

                foreach(var telefono in this.Telefono)
                {
                    comando.AppendLine(String.Format("insert into PersonasTelefonos(PersonaId,Telefono) values({0},'{1}')", this.PersonaId, telefono.Telefono));
                }

                retorno = conexion.Ejecutar(comando.ToString());
            }
            catch (Exception)
            {

                return false;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            StringBuilder comando = new StringBuilder();
            try
            {
                comando.AppendLine(String.Format("delete from Personas where PersonaId = {0};", this.PersonaId ));
                comando.AppendLine(String.Format("delete from PersonasTelefonos where PersonaId = {0};", this.PersonaId));
                retorno = conexion.Ejecutar(comando.ToString());
            }
            catch (Exception)
            {
                return false;
            }
            return retorno;
        } 

        public override bool Insertar()
        {
            StringBuilder comando = new StringBuilder();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("insert into Personas(Nombres,Direccion,Sexo,EstadoCivil) Values('{0}','{1}',{2},{3})",
                    this.Nombre,this.Direccion,this.sexo,this.EstadoCivil));
                
                this.PersonaId = (int)conexion.ObtenerDatos("select MAX(PersonaId) as PersonaId from Personas").Rows[0]["PersonaId"];

                foreach (var telefono in this.Telefono)
                {
                    comando.AppendLine(String.Format("insert into PersonasTelefonos(PersonaId,Telefono) values({0},'{1}')",this.PersonaId,telefono.Telefono));///////////
                }

                retorno = conexion.Ejecutar(comando.ToString());
            }
            catch (Exception)
            {

                return false;
            }
            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            try
            {
                return conexion.ObtenerDatos("select "+Campos +" from Personas where "+Condicion+" "+Orden);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
