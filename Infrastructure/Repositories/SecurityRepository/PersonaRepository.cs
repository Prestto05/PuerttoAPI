using Core.Puertto.DTOs.Security;
using Core.Puertto.Exceptions;
using Infrastructure.Context.Security;
using Infrastructure.Entities.Security;
using Infrastructure.Interfaces.Security;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Audit = Core.Puertto.DTOs.Security.Audit;

namespace Infrastructure.Repositories.SecurityRepository
{
    public class PersonaRepository : EntityFrameworkRepositoryAlt<SecurityContext, PersonEntity, Guid>,  IPersonaRepository
    {
        public PersonaRepository(SecurityContext dbContext) : base(dbContext)
        {
        }        

        public async Task<RespuestaCrearComprad> CreateUsuarioComprador(string correo, string contraseña, string keyunique, Entities.Security.Audit audit)
        {
            try
            {
                var usuario = new RespuestaCrearComprad();
                await using (var context = _dbContext)
                {
                    var connection = new MySqlConnection(context.Database.GetConnectionString());
                    MySqlCommand mySqlCommand = new MySqlCommand();
                    mySqlCommand.Connection = connection;
                    mySqlCommand.CommandText = "CrearRegistroComprador";
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    mySqlCommand.Parameters.AddWithValue("correo", correo);
                    mySqlCommand.Parameters.AddWithValue("clave", contraseña);
                    mySqlCommand.Parameters.AddWithValue("keyunique", keyunique);
                    mySqlCommand.Parameters.AddWithValue("ippublica", audit.IpPublicAudit);
                    mySqlCommand.Parameters.AddWithValue("macaddress", audit.MacAddressAudit);
                    mySqlCommand.Parameters.AddWithValue("longitud", audit.LongitudeAudit);
                    mySqlCommand.Parameters.AddWithValue("latitud", audit.LatitudeAudit);
                    connection.Open();
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {
                        usuario.Id = (mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("IdUsuario")) == false ? mySqlDataReader.GetGuid("IdUsuario") : Guid.NewGuid()).ToString();
                        usuario.Correo = (mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("Correo")) == false ? mySqlDataReader.GetString("Correo") : string.Empty);                          
                     
                    }

                    connection.Close();

                    return usuario;

                }
            }
            catch (Exception ex)
            {               
      
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
        }

        public override Task UpsertAsync(params PersonEntity[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
