using Login.DBContexts;
using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.LoginRepository
{
    public class RegisterLoginRepository : IRegisterLoginRepository
    {
        private readonly LoginContext _dbContext;

        public RegisterLoginRepository(LoginContext loginContext)
        {

            _dbContext = loginContext;
            //users = new List<UserLoginDetails> {
            //     new UserLoginDetails()
            //     {
            //          AccountCreated=DateTime.Now,
            //           Age=25,
            //            Gender="Male",
            //             Name="Asif Hussain",
            //              UserID="asif123@gmail.com",
            //              Password="Asif@Hussain123",
            //               UserType="Admin"
            //     },
            //     new UserLoginDetails()
            //     {
            //          AccountCreated=DateTime.Now,
            //           Age=30,
            //            Gender="Male",
            //             Name="Aman Kumar",
            //              UserID="aman1213@gmail.com",
            //              Password="aman@kumar1213",
            //               UserType="User"
            //     }
            //};
        }
        public object Login(string userId, string password)
        {
            try
            {
                var data = _dbContext.UserLoginDetails.FirstOrDefault(x => 
                x.UserID.ToLower().Equals(userId.ToLower()) 
                && x.Password.ToLower().Equals(password.ToLower()));

                if (data != null)
                {
                    return new
                    {
                        username = data.Name,
                        userid = data.UserID,
                        usertype = data.UserType
                    };
                }
                return null;                                
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public bool Registration(UserLoginDetails regDetails)
        {
            try
            {
                if (!_dbContext.UserLoginDetails.Any(x => x.UserID.ToLower().Equals(regDetails.UserID.ToLower())))
                {
                    _dbContext.UserLoginDetails.Add(regDetails);
                    Save();
                    return true;
                }
                else
                {
                    return false;                
                }
                
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
