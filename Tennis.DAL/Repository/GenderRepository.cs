using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Tennis.DAL.Models;
using Tennis.DAL.Repository.Interface;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository
{
    public class GenderRepository : GenericRepository<Gender, GenderReadDTO>, IGenderRepository
    {
        public GenderRepository(DbContext context, IMapper mapper) : base(context, mapper) { }

        public override List<GenderReadDTO> GetAll()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text
            };

            List<GenderReadDTO> genders = new List<GenderReadDTO>();

            using (SqlConnection cnn = new SqlConnection(DALExtenstion.CONNECTIONSTRING))
            {
                cmd.Connection = cnn;
                cnn.Open();
                cmd.CommandText = "SELECT * FROM tbl_gender";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = (int)reader["id"];
                        var name = (string)reader["name"];
                        genders.Add(new GenderReadDTO { Id = id, Name = name });
                    }
                }
            }

            return genders;
        }
    }
}
