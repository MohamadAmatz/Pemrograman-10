using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Repository;
using PerpustakaanAppMVC.Model.Context;

namespace PerpustakaanAppMVC.Controller
{
    public class MahasiswaController
    {
        private MahasiswaRepository _repository;
        public int Create(Mahasiswa mhs)
        {
            int result = 0;
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("NPM harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                MessageBox.Show("Angkatan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (dbContext context = new dbContext())
            {
                _repository = new MahasiswaRepository(context);
                result = _repository.Create(mhs);
            }
            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }
        public int Update(Mahasiswa mhs)
        {
            int result = 0;
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("NPM harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                MessageBox.Show("Angkatan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (dbContext context = new dbContext())
            {
                _repository = new MahasiswaRepository(context);
                result = _repository.Create(mhs);
            }
            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil diperbarui !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal diperbarui !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }
        public int Delete(Mahasiswa mhs)
        {
            int result = 0;
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("NPM harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            
            using (dbContext context = new dbContext())
            {
                _repository = new MahasiswaRepository(context);
                result = _repository.Create(mhs);
            }
            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil dihapus !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal dihapus !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }
        public List<Mahasiswa> ReadByNama(string nama)
        {
            List<Mahasiswa> list = new List<Mahasiswa>();
            using (dbContext context = new dbContext())
            {
                _repository = new MahasiswaRepository(context);
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
        public List<Mahasiswa> ReadAll()
        {
            List<Mahasiswa> list = new List<Mahasiswa>();
            using (dbContext context = new dbContext())
            {
                _repository = new MahasiswaRepository(context);
                list = _repository.ReadAll();
            }
            return list;
        }

    }

}
