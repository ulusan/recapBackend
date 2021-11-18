using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class RentalMessages
    {
        public static string RentalAddFailed = "Araç kiralanamadı.";
        public static string RentalAdded = "Araç başarıyla kiralandı.";
        public static string RentalDeleteFailed = "Araç Kiralama iptal edilemedi!";
        public static string RentalDeleted = "Araç Kiralama iptal edildi.";
        public static string RentalUpdateFailed = "Araç Kiralama güncellenenedi.";
        public static string RentalUpdate = "Araç Kiralama güncellendi.";
        public static string RentalListed = "Araç Kiraları listelendi.";
        public static string CarCountOfCategoryError = "Bir Markada en fazla 15 araba olabilir.";
        public static string CarNameAlreadyExists = "Böyle Bir İsimde araba var";
        public static string BrandLimitExceded = "Marka Sınırı Aşıldı";
        public static string ColorCountLimitExceded = "Renk Toplamı Sınırı Aşıldı";

    }
}
