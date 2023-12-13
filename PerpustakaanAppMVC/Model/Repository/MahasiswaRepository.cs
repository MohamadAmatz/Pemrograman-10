using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Context;

namespace PerpustakaanAppMVC.Model.Repository
{
    public class MahasiswaRepository
    {
        private OleDbConnection _conn;
        public MahasiswaRepository(dbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Mahasiswa mhs)
        {
            int result = 0;
            string sql = @"insert into mahasiswa (npm, nama, angkatan) values (@npm, @nama, @angkatan)";
            using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@npm", mhs.Npm);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@angkatan", mhs.Angkatan);
                try
                {
                result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }
        public int Update(Mahasiswa mhs)
        {
            int result = 0;
            string sql = @"update mahasiswa (npm, nama, angkatan) values (@npm, @nama, @angkatan) where npm = @npm";
            using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@npm", mhs.Npm);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@angkatan", mhs.Angkatan);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }
            return result;
        }
        public int Delete(Mahasiswa mhs)
        {
            int result = 0;
            string sql = @"delete mahasiswa (npm, nama, angkatan) where npm = @npm";
            using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@npm", mhs.Npm);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@angkatan", mhs.Angkatan);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }
            return result;
        }
        public List<Mahasiswa> ReadAll()
        {
            List<Mahasiswa> list = new List<Mahasiswa>();
            try
            {
                string sql = @"select npm, nama, angkatan from mahasiswa order by nama";
                using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
                { 
                    using (OleDbDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.Npm = dtr["npm"].ToString();
                            mhs.Nama = dtr["nama"].ToString();
                            mhs.Angkatan = dtr["angkatan"].ToString();
                            list.Add(mhs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }
        public List<Mahasiswa> ReadByNama(string nama)
        {
            List<Mahasiswa> list = new List<Mahasiswa>();
            try
            {
                string sql = @"select npm, nama, angkatan from mahasiswa where nama like @nama order by nama";
                using (OleDbCommand cmd = new OleDbCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", "%" + nama + "%"); 
                    using (OleDbDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.Npm = dtr["npm"].ToString();
                            mhs.Nama = dtr["nama"].ToString();
                            mhs.Angkatan = dtr["angkatan"].ToString();
                            list.Add(mhs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}",
               ex.Message);
            }
            return list;
        }


    }
}
