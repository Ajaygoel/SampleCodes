using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AvnonDemo.Domain.Message;

namespace AvnonDemo.DataAccess.Messages
{
    public class MessageDbContext
    {
        public List<MessageDto> GetMessagesByUserId(int userId)
        {
            SqlConnection conn = null;
            SqlCommand sqlComm = null;
            SqlParameter paramUserId = null;
            SqlDataReader sqlDataReader = null;
            List<MessageDto> messagesList = null;
            ImageDbContext objImageDbContext = null;
            try
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvnonDemoContext"].ConnectionString);
                conn.Open();

                sqlComm = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "udp_GetAllMessagesByUserId"
                };

                paramUserId = new SqlParameter("@UserId", userId)
                {
                    SqlDbType = SqlDbType.Int
                };
                sqlComm.Parameters.Add(paramUserId);

                sqlComm.Connection = conn;
                sqlDataReader = sqlComm.ExecuteReader();

                messagesList = new List<MessageDto>();
                objImageDbContext = new ImageDbContext();

                while (sqlDataReader.Read())
                {
                    MessageDto messageDto = null;
                    try
                    {
                        messageDto = new MessageDto
                        {
                            Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                            Text = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MessageBody"))
                        };

                        messageDto.Images = objImageDbContext.GetImagesByMessageId(messageDto.Id);

                        messagesList.Add(messageDto);
                    }
                    finally
                    {
                        messageDto = null;
                    }
                }

                conn.Close();

                return messagesList;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                paramUserId = null;
                messagesList = null;
                sqlDataReader = null;
                objImageDbContext = null;
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                    conn = null;
                }
                sqlComm = null;
            }
        }

        public MessageDto Save(MessageDto message)
        {
            SqlConnection conn = null;
            SqlCommand sqlComm = null;
            SqlParameter paramUserId = null;
            SqlParameter paramMessageId = null;
            SqlParameter paramMessageText = null;
            SqlParameter paramIsDeleted = null;
            SqlDataReader sqlDataReader = null;
            MessageDto messageDto = null;
            ImageDbContext objImageDbContext = null;
            try
            {
                conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AvnonDemoContext"].ConnectionString);
                conn.Open();

                sqlComm = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "udp_SaveMessage"
                };

                paramUserId = new SqlParameter("@UserId", message.UserId)
                {
                    SqlDbType = SqlDbType.Int
                };
                sqlComm.Parameters.Add(paramUserId);

                paramMessageId = new SqlParameter("@MessageId", message.Id)
                {
                    SqlDbType = SqlDbType.Int
                };
                sqlComm.Parameters.Add(paramMessageId);

                paramMessageText = new SqlParameter("@MessageText", message.Text ?? string.Empty)
                {
                    SqlDbType = SqlDbType.VarChar
                };
                sqlComm.Parameters.Add(paramMessageText);

                paramIsDeleted = new SqlParameter("@IsDeleted", message._deleted)
                {
                    SqlDbType = SqlDbType.Bit
                };
                sqlComm.Parameters.Add(paramIsDeleted);

                sqlComm.Connection = conn;
                sqlDataReader = sqlComm.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    messageDto = new MessageDto
                    {
                        Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                        Text = sqlDataReader.GetString(sqlDataReader.GetOrdinal("MessageBody"))
                    };
                    break;
                }

                conn.Close();

                if (messageDto != null)
                {
                    objImageDbContext = new ImageDbContext();
                    foreach (var imageDto in message.Images)
                    {
                        imageDto.MessageId = messageDto.Id;
                        imageDto.UserId = messageDto.UserId;
                        objImageDbContext.Save(imageDto);
                    }
                }

                return messageDto;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                paramUserId = null;
                paramMessageId = null;
                paramMessageText = null;
                paramIsDeleted = null;
                messageDto = null;
                sqlDataReader = null;
                objImageDbContext = null;
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
