﻿    using Project_PBO_03.Core;
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Project_PBO_03.Model;

namespace Project_PBO_03.Context
{
    internal class AdminContext : DBconnection
    {
        private static string table = "administrator";


        public static DataTable all()
        {
            string query = $"SELECT * FROM {table}";
            DataTable dataAdministrator = queryExecutor(query);
            return dataAdministrator;
        }

        public static DataTable read(int idadmin)
        {
            string query = $"SELECT * FROM {table} WHERE idadmin = @idadmin";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@idadmin", NpgsqlDbType.Integer) { Value = idadmin }
            };
            DataTable dataAdministrator = queryExecutor(query, parameters);
            return dataAdministrator;
        }

        public static void create(m_Administrator newAdmin)
        {
            string query = $"INSERT INTO {table} (kodeverifikasi, namaadmin, telpadmin, usrnmeadmin, pwadmin, emailadmin) VALUES(@kodeverifikasi, @namaadmin, @telpadmin, @usrnmeadmin, @pwadmin, @emailadmin)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@kodeverifikasi", NpgsqlDbType.Varchar){Value = newAdmin.kode_verif},
                new NpgsqlParameter("@namaadmin", NpgsqlDbType.Varchar){Value = newAdmin.nama_admin},
                new NpgsqlParameter("@telpadmin", NpgsqlDbType.Varchar){Value = newAdmin.telp_admin},
                new NpgsqlParameter("@usrnmeadmin", NpgsqlDbType.Varchar){Value = newAdmin.username_admin},
                new NpgsqlParameter("@pwadmin", NpgsqlDbType.Varchar){Value = newAdmin.pass_admin},
                new NpgsqlParameter("@emailadmin", NpgsqlDbType.Varchar){Value = newAdmin.email_admin},
            };
            commandExecutor(query, parameters);
        }


        public static void delete(int id)
        {
            string query = $"DELETE FROM {table} WHERE idadmin = @idadmin";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@idadmin", NpgsqlDbType.Integer){Value = id},
            };
            commandExecutor(query, parameters);
        }

        public static void update(m_Administrator editAdmin)
        {
            string query = $"UPDATE {table} SET kodeverifikasi = @kodeverifikasi, namaadmin = @namaadmin, telpadmin = @telpadmin, usrnmeadmin = @usrnmeadmin, pwadmin = @pwadmin, emailadmin = @emailadmin WHERE idadmin = @idadmin";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@idadmin", NpgsqlDbType.Integer){Value = editAdmin.id_admin },
                new NpgsqlParameter("@kodeverifikasi", NpgsqlDbType.Varchar){Value = editAdmin.kode_verif},
                new NpgsqlParameter("@namaadmin", NpgsqlDbType.Varchar){Value = editAdmin.nama_admin},
                new NpgsqlParameter("@telpadmin", NpgsqlDbType.Varchar){Value = editAdmin.telp_admin},
                new NpgsqlParameter("@usrnmeadmin", NpgsqlDbType.Varchar){Value = editAdmin.username_admin},
                new NpgsqlParameter("@pwadmin", NpgsqlDbType.Varchar){Value = editAdmin.pass_admin},
                new NpgsqlParameter("@emailadmin", NpgsqlDbType.Varchar){Value = editAdmin .email_admin},
            };
            commandExecutor(query, parameters);
        }
        public static DataTable dataadmin(string inputs)
        {
            string query = "SELECT * FROM administrator WHERE usrnmeadmin = @usrnmeadmin";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@usrnmeadmin", inputs){NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar}
            };
            return queryExecutor(query, parameters);
        }

        public static DataTable loginadmin(string username_admin, string password_admin)
        {
            string query = "SELECT * FROM administrator WHERE usrnmeadmin = @inputs AND pwadmin =@pw";
            NpgsqlParameter[] parameters =
            {
                    new NpgsqlParameter("@inputs", DbType.String) {Value = username_admin},
                    new NpgsqlParameter("@pw", DbType.String) {Value = password_admin },
                };
            return queryExecutor(query, parameters);
        }

    }
}
