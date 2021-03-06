using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz.";
        public static string CarDelede = "Araba silindi.";
        public static object CarUpdate ="Araba Güncellendi.";
        public static string CarInvalid="Geçersiz araba aciklaması.";
        public static string CarListed = "Arabalar Listelendi.";


        public static string ColorAdded = "Color eklendi.";
        public static string ColorDelete = "Color silindi";
        public static string ColorUpdate = "Color Güncellendi.";

        public static string BrandAdded = "Brand eklendi.";
        public static string BrandDelete = "Brand silindi";
        public static string BrandUpdate = "Brand Güncellendi.";
        public static string MaintenanceTime="Sistemimiz bakımdadır.";

        public static string InvalidSale="Geçersiz Kiralama";
        public static string RentalAdded = "Arabayı Kiraladınız.";
        public static string RentalNotAdded = "Malesef arabayı kiralayamazsınız. ";
        public static string RentalList = "Kiralana İşlemleri listelendi.";

        public static string UderAdd ="User eklendi.";

        public static string UserList ="User listelendi.";
        public static string CustomerAdd = "Customer eklendi.";
        public static string CustomerList ="Customer listelendi.";

        public static string CarNotInvalid = "Arabanın ücreti 0 olamaz.";

        public static string CarImageAdded = "Araba resmi eklendi.";
        public static string CarImageDelete = "Arabanın resmi silindi.";
        public static string CarImageUpdate = "Arabanın resmi güncellendi.";

        public static string CarImageNotFound = "";
        public static string FailAddedImageLimit = "Fotograf koyma limitiniz dolmuştur.";

        public static string CarImageIsNotExists { get; internal set; }
    }
}
