using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBN_Application.Models
{
    public class SBN
    {
        public int Id_Sbn { get; set; }
        public string Nama_Sbn { get; set; }
        public string Kode_Sbn { get; set; }
        public string Deskripsi { get; set; }
        public string Tipe_Investor { get; set; }
        public int Min_Beli { get; set; }
        public double Fixed_Rate { get; set; }
        public DateTime Created_At { get; set; }
    }

}
