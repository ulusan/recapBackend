using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class BrandMessages
    {
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandNameInvalid = "Marka İsmi Geçersiz";
        public static string BrandListed = "Markalar Listelendi";
        public static string BrandUpdate = "Markalar Güncellendi";
        public static string BrandDeleted = "Marka Silindi";

        public static string SameNameExist { get; internal set; }
        public static string BrandGet { get; internal set; }
    }
}
