using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Services
{
    public class PhoneNumberChecker
    {
        public static bool FindOccurances(string num, string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (num == arr[i])
                {
                    return true;
                }
            }
            return false;
        }
       public  static bool CheckPhoneNumber(string number)
        {
            string[] arr = new string[] { "91", "99", "96", "43", "33", "79", "55", "95",
                "41", "44", "66", "50", "93", "94", "77","98", "49", "22" };
            int length = number.Length;

            if (length == 9)
            {
                string n = number[1].ToString() + number[2].ToString();
                if (number[0] == '0' && FindOccurances(n, arr))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
