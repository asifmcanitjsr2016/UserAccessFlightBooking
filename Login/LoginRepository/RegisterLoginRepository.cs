using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.LoginRepository
{
    public class RegisterLoginRepository : IRegisterLoginRepository
    {
        private List<UserLoginDetails> users;

        public RegisterLoginRepository()
        {
            users = new List<UserLoginDetails> {
                 new UserLoginDetails()
                 {
                      AccountCreated=DateTime.Now,
                       Age=25,
                        Gender="Male",
                         Name="Asif Hussain",
                          UserID="asif123",
                          Password="Asif@Hussain123",
                           UserType="Admin"
                 },
                 new UserLoginDetails()
                 {
                      AccountCreated=DateTime.Now,
                       Age=30,
                        Gender="Male",
                         Name="Aman Kumar",
                          UserID="aman1213",
                          Password="aman@kumar1213",
                           UserType="User"
                 }
            };
        }
        public string Login(string userId, string password)
        {
            try
            {
                return users.Find(x => 
                x.UserID.ToLower().Equals(userId.ToLower()) 
                && x.Password.ToLower().Equals(password.ToLower()))?.UserType;                
                
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
                if (!users.Any(x => x.UserID.ToLower().Equals(regDetails.UserID.ToLower())))
                {
                    users.Add(regDetails);
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
    }
}
