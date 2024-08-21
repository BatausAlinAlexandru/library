using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

using LibraryApplication.API.Domain.Book;

namespace LibraryApplication.API.Domain.User
{
    public class UserValidator
    {
        public UserValidator() { }

        public static void ValidateUserName(string userName)
        {
            if (userName == string.Empty)
                throw new Exception("The name it's empty.");

            BookValidator.CheckDigits(userName, "The name has digits.");
        }

        public static void ValidatePassword(string password)
        {
            // Trebuie facuta o noua clasa pentru a valida 
            // dintre nume si parola daca sunt similaritati

            if (string.IsNullOrEmpty(password))
                throw new Exception("The password it's empty or null.");


            // REGEX 
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(password))
                throw new Exception("The password not matched (ex: Password1234$ )");

        }

        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new Exception("The email it's empty or null.");

            // CICA ARE CEVA BUILT IN DIN .NET, SA VEDEM 
            // PORCARIE DE CLASA CU TOATE CE EXISTA
            //MailAddress mailAddress = new MailAddress(email);


            // TRECEM LA REGEX :D
            string pattern = @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
                throw new Exception("Email it's not valid.");

        }

    }
}
