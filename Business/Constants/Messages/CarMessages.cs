using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class CarMessages
    {
        public static string MaintenanceTime = "Sistem Bakımda";

        public static string CarAdded = "Araba Eklendi";
        public static string CarNameInvalid = "Araba İsmi Geçersiz";
        public static string CarListed = "Arabalar Listelendi";
        public static string CarUpdate = "Arabalar Güncellendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarNameAlreadyExists = "Araba İsmi zaten var";
        public static string ColorCountLimitExceded = "Renk Limiti aşıldı";
        
        public static string CarCountOfCategoryError = "Araba Sayısı Kategorisi aşıldı"; 

    }
}
