using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBN_Application.Models
{
    public class Asset
    {
        [Key]
        public int Id_Asset { get; set; }

        [ForeignKey("Buyer")]
        public int Id_Buyer { get; set; }

        [ForeignKey("Sbn")]
        public int Id_Sbn { get; set; }

        public int Modal { get; set; }
        public int Tenor { get; set; } // dalam bulan
        public double Total_Diterima { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;

        // Relasi ke tabel lain
        public Buyer Buyer { get; set; }
        public SBN Sbn { get; set; }

        // Method bantu untuk menghitung Total_Diterima
        public void HitungTotalDiterima()
        {
            if (Sbn != null)
            {
                Total_Diterima = Modal + (Modal * Sbn.Fixed_Rate * (Tenor / 12.0));
            }
            else
            {
                Total_Diterima = 0;
            }
        }
    }
}
