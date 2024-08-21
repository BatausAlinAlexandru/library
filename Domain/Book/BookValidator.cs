using System.Text.RegularExpressions;

namespace LibraryApplication.API.Domain.Book
{
    public class BookValidator
    {
        public BookValidator() { }

        public static void JustString(string value, string errorMessage)
        {
            string pattern = @"^[a-zA-z\s]+$";
            //Regex regex = new Regex(pattern, RegexOptions.Compiled); // pentru baza de date mare
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(value))
                throw new Exception(errorMessage);
        }

        public static void CheckDigits(string value, string errorMesage)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                {
                    throw new Exception(errorMesage);
                }
            }
        }

        public static void ValidateTitle(string title)
        {
            if (title == string.Empty)
                throw new Exception("Title it's empty.");
            
            // heckDigits(title, "Title has digits."); AICI MI-AM DAT SEAMA CA POTI AVEA CIFRE IN TITLU
            JustString(title, "The title has other characters than letters."); // SI AICI MA GANDESC CA POTI AVEA UN . SAU ! ? DOAMNE IA-MA
        }

        public static void ValidateAuthor(string author)
        {
            if (author == string.Empty)
                throw new Exception("Author it's empty.");

            CheckDigits(author, "Author has digits.");
            JustString(author, "The author has other characters than letters.");
        }

        // INCA NU STIU SI NICI NU-MI BAT CAPUL, AM LUAT FUNCTIA DE PE INTERNET
        public static void ValidateISBN(string isbn)
        {
            if (isbn.Length != 13 || !long.TryParse(isbn, out _))
                throw new Exception("ISBN wrong format ! (13 digits)");

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = isbn[i] - '0';
                sum += digit * (i % 2 == 0 ? 1 : 3);
            }

            int checkDigit = 10 - (sum % 10);
            if (checkDigit == 10)
                checkDigit = 0;

            if (checkDigit == (isbn[12] - '0'))
                throw new Exception("ISBN wrong !");
        }


        public static void ValidatePrice(float price)
        {
            if (price < 0)
                throw new Exception("The price cannot be negative.");
        }
    }
}
