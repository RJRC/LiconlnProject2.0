using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessDataLayer;
using Entities;

namespace BusinessLogicLayer
{
    public class BLL
    {

        private ADL accessDataLayer = new ADL();


        /*Login*/
        public int authenticate(String userName, String pass)
        {
            List<Login> list = accessDataLayer.getUsers();

            foreach (Login login in list)
            {
                if (userName == login.Username)
                {
                    if (pass == login.PasswordLogin)
                    {
                        if (login.TypeOfUser == "a")
                        {
                            return 1;
                        }
                        if (login.TypeOfUser == "o")
                        {
                            return 2;
                        }
                        /****Admin=1  User=2 ****/
                    }
                }

            }
            return 0; /*si no coincide retorna 0*/
        }

    }
}
