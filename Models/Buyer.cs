using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBN_Application.Models
{
    public class Buyer
    {
        [Key]
        public int Id_Buyer { get; set; }
        public string Nama_Buyer { get; set; }
        public string No_Telp { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string No_Rek { get; set; }
        public DateTime Created_At { get; set; }
    }

}
