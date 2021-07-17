using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using CRM.Data;

namespace CRM.Models.Mapping
{
    public static class ProfileMapper
    {
        public static ProfileDataModel Map(this Profile entities)
        {
            return new ProfileDataModel()
            {
                UserId = entities.UserId,
                FName = entities.FName,
                LName = entities.LName
            };
        }


        public static string FirstCharacterUpperCase(this string input)
        {
            return $"{input.Substring(0, 1).ToUpper()}{input.ToLower().Substring(1, input.Length - 1)}";
        }
    }
}