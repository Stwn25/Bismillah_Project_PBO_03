﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_03.Model
{
    internal class m_PeminjamanBuku
    {
        [Key]
        public int id_peminjaman { get; set; }
        public int id_pengguna { get; set; }
        public int id_status { get; set; }
        public string isbn_buku { get; set; }
        public DateTime tgl_pengambilan { get; set; }
        public DateTime tgl_pengembalian { get; set; }
    }
}
