using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Utility
{
    public static class Helper
    {
        //Location
        public static string Polokwane = "Polokwane";
        public static string Mogale = "Mogale";
        public static string Pretoria = "Pretoria";
        //Systems
        public static string CreditControl = "Credit Control";
        public static string Indigent = "Indigent";
        public static string Vatting = "Vatting";
        public static string OtherSystem = "Other";
        //Device
        public static string Computer = "Computer";
        public static string MobilePhone = "Mobile Phone";
        public static string Tablet = "Tablet";
        public static string OtherDevice = "Other";
        //Priority
        public static string Low = "Low";
        public static string Medium = "Medium";
        public static string High = "High";

        public static List<SelectListItem> GetPriorityDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Low,Text=Helper.Low},
                    new SelectListItem{Value=Helper.Medium,Text=Helper.Medium},
                    new SelectListItem{Value=Helper.High,Text=Helper.High},
                };
        }

        public static List<SelectListItem> GetLocationDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Polokwane,Text=Helper.Polokwane},
                    new SelectListItem{Value=Helper.Mogale,Text=Helper.Mogale},
                    new SelectListItem{Value=Helper.Pretoria,Text=Helper.Pretoria}
                };
        }

        public static List<SelectListItem> GetSystemDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.CreditControl,Text=Helper.CreditControl},
                    new SelectListItem{Value=Helper.Indigent,Text=Helper.Indigent},
                    new SelectListItem{Value=Helper.Vatting,Text=Helper.Vatting},
                    new SelectListItem{Value=Helper.OtherSystem,Text=Helper.OtherSystem}
                };
        }

        public static List<SelectListItem> GetDeviceDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Computer,Text=Helper.Computer},
                    new SelectListItem{Value=Helper.MobilePhone,Text=Helper.MobilePhone},
                    new SelectListItem{Value=Helper.Tablet,Text=Helper.Tablet},
                    new SelectListItem{Value=Helper.OtherDevice,Text=Helper.OtherDevice}
                };
        }


    }
}
