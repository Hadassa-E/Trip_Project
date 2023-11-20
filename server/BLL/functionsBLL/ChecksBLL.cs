using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BLL.functionsBLL
{
    public static class ChecksBLL
    {
        //עבור בדיקות תקינות
        public static bool CheckName(string name)
        {
            for (int i = 0; i < name.Length; i++)
                if ((name[i] < 'א' || name[i]>'ת')&& name[i] !=' ')
                    return false;
            return true;
        }
        public static bool CheckPhone(string phone)
        {
            if(phone.Length!=10) return false;
            for (int i = 0; i < phone.Length; i++)
                if(phone[i] < '0' || phone[i] > '9')
                    return false;
            return true;
        }
        public static bool CheckMail(string mail)
        {
            if (Regex.IsMatch(mail, "[a-zA-Z0-9]+@gmail.com"))
                return true;
            return false;
        }
        public static bool CheckPassword(string password)
        {
            if(password.Length<6) return false;
            bool ch = false, d = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= '0' && password[i] <= '9')d= true;
                if ((password[i] >= 'א' && password[i] <= 'ת')|| (password[i] >= 'A' || password[i] <= 'Z')|| (password[i] >= 'a' || password[i] <= 'z')) ch = true;
            }
            return ch&&d;
        }
    }
}
