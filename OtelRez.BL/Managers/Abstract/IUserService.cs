using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.BL.Managers.Abstract
{
    public interface IUserService
    {
        bool SendForgotPasswordEmail(string email);
    }
}
