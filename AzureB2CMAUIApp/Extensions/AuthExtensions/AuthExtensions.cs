using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureB2CMAUIApp.Extensions.AuthExtensions 
{
    public static class AuthExtensions 
    {
        public static StringContent ToJsonStringContent(this object o) => new(JsonConvert.SerializeObject(o));

        public static string[] ToStringArray(this NestedSettings[] nestedSettings) 
        {
            string[] result = new string[nestedSettings.Length];

            for (int i = 0; i < nestedSettings.Length; i++) 
            {
                result[i] = nestedSettings[i].Value;
            }

            return result;
        }
    }
}
