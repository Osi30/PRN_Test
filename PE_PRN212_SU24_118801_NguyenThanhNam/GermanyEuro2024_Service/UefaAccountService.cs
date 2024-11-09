using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024_BO;
using GermanyEuro2024_Repo;

namespace GermanyEuro2024_Service
{
    public class UefaAccountService
    {
        private UefaaccountRepo repo=new();

        public Uefaaccount Login(string email, string password) => repo.GetAccount(email, password);
    }
}
