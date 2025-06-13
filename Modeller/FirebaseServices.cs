using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselFinal.Modeller
{
    public class FirebaseServices
    {
        static string projectId = "gorselfinal-35fd7";
        static string ApiKey = "AIzaSyCeujXAzABRWb5A4xjJZ2fyuDo7WMWEXfA";
        static string AuthDomain = $"{projectId}.firebaseapp.com";

        static FirebaseAuthConfig authConfig = new FirebaseAuthConfig()
        {
            ApiKey = ApiKey,
            AuthDomain = AuthDomain,
            Providers = new FirebaseAuthProvider[] { new EmailProvider() }
        };

        public static async Task<User> Login(string email, string password)
        {
            try
            {

                var client = new FirebaseAuthClient(authConfig);
                var res = await client.SignInWithEmailAndPasswordAsync(email, password);
                return res.User;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<User> Register(string name, string email, string password)
        {
            try
            {

                var client = new FirebaseAuthClient(authConfig);
                var res = await client.CreateUserWithEmailAndPasswordAsync(email, password, name);
                return res.User;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
