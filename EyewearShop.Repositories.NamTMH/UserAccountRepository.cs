using System;
using eyeWearShop.Repositories.Basis;
using EyewearShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EyewearShop.Repositories.NamTMH;

public class UserAccountRepository : GenericRepo<UserAccount>
{
    public UserAccountRepository()
    {
    }   
    public UserAccountRepository(Prn222EyewearshopContext context)
    {
        _context = context;
    }

    public async Task<UserAccount> GetUserAccountAsync(string userName, string password)
    {
        // login by username
        return await _context.UserAccounts.FirstOrDefaultAsync(account => 
        account.UserName == userName  
        && account.Password == password 
        && account.IsActive == true) 
        ?? new UserAccount();

        //login by email

        //login by phonenumber

        //login by employeeCode
    }

    
}
