using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class CarImageMessages
    {
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImagesListed = "Araba resimleri listelendi";
        public static string CarImageLimitExceded = "Araba resim limiti aşıldığı için yeni resim eklenemiyor";
    }
}
