using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvnonDemo.Domain.Message;

namespace AvnonDemo.DataAccess.Messages
{
    public class ImageDbContext
    {
        public List<ImageDto> GetImagesByMessageId(int messageId)
        {
            SqlConnection conn = null;
            SqlCommand sqlComm = null;
            SqlParameter paramMessageId = null;
            SqlDataReader sqlDataReader = null;
            List<ImageDto> imageList = null;
            try
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvnonDemoContext"].ConnectionString);
                conn.Open();

                sqlComm = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "udp_GetImagesByMessageId"
                };

                paramMessageId = new SqlParameter("@MessageId", messageId)
                {
                    SqlDbType = SqlDbType.Int
                };
                sqlComm.Parameters.Add(paramMessageId);

                sqlComm.Connection = conn;
                sqlDataReader = sqlComm.ExecuteReader();

                imageList = new List<ImageDto>();

                while (sqlDataReader.Read())
                {
                    ImageDto dto = null;
                    try
                    {
                        dto = new ImageDto
                        {
                            Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                            Url = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Url"))
                        };

                        imageList.Add(dto);
                    }
                    finally
                    {
                        dto = null;
                    }
                }

                conn.Close();

                return imageList;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                paramMessageId = null;
                imageList = null;
                sqlDataReader = null;
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    conn = null;
                }
                sqlComm = null;
            }
        }

        public ImageDto Save(ImageDto imageDto)
        {
            SqlConnection conn = null;
            SqlCommand sqlComm = null;
            SqlParameter paramUserId = null;
            SqlParameter paramImageId = null;
            SqlParameter paramImageUrl = null;
            SqlParameter paramIsDeleted = null;
            SqlParameter paramMessageId = null;
            SqlDataReader sqlDataReader = null;
            ImageDto messageDto = null;
            try
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvnonDemoContext"].ConnectionString);
                conn.Open();

                sqlComm = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "udp_SaveImage"
                };

                paramUserId = new SqlParameter("@UserId", imageDto.UserId)
                {
                    SqlDbType = SqlDbType.Int
                };
                sqlComm.Parameters.Add(paramUserId);

                paramImageId = new SqlParameter("@ImageId", imageDto.Id)
                {
                    SqlDbType = SqlDbType.Int
                };
                sqlComm.Parameters.Add(paramImageId);

                paramMessageId = new SqlParameter("@MessageId", imageDto.MessageId)
                {
                    SqlDbType = SqlDbType.Int
                };
                sqlComm.Parameters.Add(paramMessageId);

                paramImageUrl = new SqlParameter("@ImageUrl", imageDto.Url ?? string.Empty)
                {
                    SqlDbType = SqlDbType.VarChar
                };
                sqlComm.Parameters.Add(paramImageUrl);

                paramIsDeleted = new SqlParameter("@IsDeleted", imageDto._deleted)
                {
                    SqlDbType = SqlDbType.Bit
                };
                sqlComm.Parameters.Add(paramIsDeleted);

                sqlComm.Connection = conn;
                sqlDataReader = sqlComm.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    messageDto = new ImageDto
                    {
                        Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                        Url = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Url"))
                    };
                    break;
                }

                conn.Close();

                return messageDto;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                paramUserId = null;
                paramImageId = null;
                paramImageUrl = null;
                paramIsDeleted = null;
                paramMessageId = null;
                messageDto = null;
                sqlDataReader = null;
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    conn = null;
                }
                sqlComm = null;
            }
        }
    }
}
