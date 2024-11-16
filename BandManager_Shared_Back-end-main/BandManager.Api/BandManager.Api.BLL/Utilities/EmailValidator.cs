using System.Net.Mail;

namespace BandManager.Api.BLL.Utilities;

/// <summary>
/// Class to validate emails
/// Contains the function <see cref="IsValidEmail"/>
/// </summary>
public static class EmailValidator
{
    /// <summary>
    /// Function to check if an email is in a valid format
    /// This function can not check if the email is real or not, only if it is in a valid format
    /// </summary>
    /// <param name="email">The email to check</param>
    /// <returns>True if the email is in a valid format, false if not</returns>
    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch(FormatException)
        {
            //This exception is thrown when the email is not in the correct format (aka not an email)
            return false;
        }
    }
}