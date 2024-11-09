using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024_BO;

namespace GermanyEuro2024_Repo
{
    public class UefaaccountRepo
    {
        private GermanyEuro2024DbContext _context;

        public UefaaccountRepo()
        {
            _context = new GermanyEuro2024DbContext();
        }

        public Uefaaccount? GetAccount(string email, string password) => _context.Uefaaccounts.FirstOrDefault(u => u.AccountEmail.Equals(email) && u.AccountPassword.Equals(password));
    }
}
