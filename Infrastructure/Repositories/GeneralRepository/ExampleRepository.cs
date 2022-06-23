using AutoMapper;
using Core.Puertto.Exceptions;
using Infrastructure.Context.General;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.GeneralRepository
{
    public class ExampleRepository : EntityFrameworkRepository<GeneralContext, ExampleEntity, int>, IExaampleRepository
    {
        public ExampleRepository(GeneralContext dbContext) : base(dbContext)
        {
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(ExampleEntity example)
        {
            await using (var context = _dbContext)
            {
                var x = new MySqlConnection(context.Database.GetConnectionString());

                MySqlCommand mySqlCommand = new MySqlCommand();

                mySqlCommand.Connection = x;
                mySqlCommand.CommandText = "Test";
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("numero", 789);
                mySqlCommand.Parameters.AddWithValue("value", "dasdas");

                x.Open();
                mySqlCommand.ExecuteNonQuery();

                x.Close();

            }
        }

        public async Task<List<ExampleEntity>> Reaad()
        {
            try
            {
                var newValue = new List<ExampleEntity>();
                await using (var context = _dbContext)
                {
                    var connection = new MySqlConnection(context.Database.GetConnectionString());

                    MySqlCommand mySqlCommand = new MySqlCommand();
                    mySqlCommand.Connection = connection;
                    mySqlCommand.CommandText = "allread";
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                    //var x = Mapper.Map<IDataReader, IEnumerable<ExampleEntity>>(mySqlDataReader);
                    while (mySqlDataReader.Read())
                    {
                        newValue.Add(new ExampleEntity()
                        {
                            Id = (mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("Id")) == false ? mySqlDataReader.GetInt32("Id") : 0),
                            Data = (mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("Data")) == false ? mySqlDataReader.GetString("Data") : string.Empty),
                            Number = (mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("Number")) == false ? mySqlDataReader.GetInt32("Number") : 0)
                        });
                    }
                    connection.Close();
                }

                return newValue;
            }
            catch (Exception ex)
            {
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
         
        }

        public Task Update(ExampleEntity example)
        {
            throw new NotImplementedException();
        }

        public override Task UpsertAsync(params ExampleEntity[] entities)
        {
            throw new NotImplementedException();
        }


        //public void Then_an_automapper_exception_should_be_thrown()
        //{
        //    var passed = false;
        //    try
        //    {
        //        Mapper.Map<IDataReader, IEnumerable<DTOObject>>(_dataReader).FirstOrDefault();
        //    }
        //    catch (AutoMapperMappingException)
        //    {
        //        passed = true;
        //    }

        //    passed.ShouldBeTrue();
        //}
    }
}
