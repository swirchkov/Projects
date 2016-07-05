using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Util.Comparators
{
    public class UserComparator : IEqualityComparer<UserDTO>
    {
        public bool Equals(UserDTO x, UserDTO y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return (x.Id == y.Id);
            }
        }

        public int GetHashCode(UserDTO obj)
        {
            return obj.GetHashCode();
        }
    }
}