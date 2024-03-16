using System;
using System.Linq;
using System.Text.RegularExpressions;
using static Credit_Card_Validator.CreditCardValidator;

namespace Credit_Card_Validator
{
    public partial class Validator : System.Web.UI.Page
    {
        CreditCardValidator validator = new CreditCardValidator();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                cardTypeImage.ImageUrl = "";
                // Validating Credit Card Number 
                if (cardNumber.Text.Length == 0)
                    throw new Exception(validator.GetErrorMessage(2));
                if (cardNumber.Text.Length != 16)
                    throw new Exception(validator.GetErrorMessage(5));

                // Validating Cardholder Name
                if (!Regex.IsMatch(cardholderName.Text, @"^[a-zA-Z\s]+$"))
                    throw new Exception(validator.GetErrorMessage(5));

                // Validating CVV length
                if (cardCVV.Text.Length != 3)
                    throw new Exception(validator.GetErrorMessage(6));

                // Validating Expiration Date
                if (expirationMonth.SelectedIndex == 0 || expirationYear.SelectedIndex == 0)
                    throw new Exception(validator.GetErrorMessage(8));

                // Validating Credit Card Number
                var result = validator.validateCreditCardNumber(creditCardNumber: cardNumber.Text);
                if (result==true) // Validated
                {
                    string creditCardType = validator.GetCardType(cardNumber.Text);
                    if (creditCardType == CardType.Mastercard.ToString())
                    {
                        cardTypeImage.ImageUrl = "https://w7.pngwing.com/pngs/962/794/png-transparent-mastercard-credit-card-mastercard-logo-mastercard-logo-love-text-heart.png";
                    }
                    else if (creditCardType == CardType.Visa.ToString())
                    {
                        cardTypeImage.ImageUrl = "https://logowik.com/content/uploads/images/t_visa-payment-card1873.jpg";
                    }
                    else
                    {
                        cardTypeImage.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/e2/Unknown_toxicity_icon.png";
                    }

                    errorMessageLabel.Visible = false;
                }
                else
                {
                    throw new Exception(validator.GetErrorMessage(1));
                }
            }
            catch (Exception ex)
            {
                errorMessageLabel.Text = ex.Message;
                errorMessageLabel.Visible = true;
            }
        }

    }
    class CreditCardValidator
    {
        public bool validateCreditCardNumber(string creditCardNumber)
        {
            string cleanedNumber = string.Concat(creditCardNumber.Where(char.IsDigit));

            if (string.IsNullOrEmpty(cleanedNumber))
            {
                return false;
            }

            int sum = 0;
            bool isSecondDigit = false;

            for (int i = cleanedNumber.Length - 1; i >= 0; i--)
            {
                int digit = cleanedNumber[i] - '0';

                // Double every second digit
                if (isSecondDigit)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = digit % 10 + 1;
                    }
                }
                sum += digit;
                isSecondDigit = !isSecondDigit;
            }

            bool isValid = sum % 10 == 0;

            return isValid;
        }

        public string GetCardType(string cardNumber)
        {
            string[] visaPrefixes = { "4" };
            string[] mastercardPrefixes = { "51", "52", "53", "54", "55" };

            if (visaPrefixes.Any(prefix => cardNumber.StartsWith(prefix)))
            {
                return CardType.Visa.ToString();
            }

            if (mastercardPrefixes.Any(prefix => cardNumber.StartsWith(prefix)))
            {
                return CardType.Mastercard.ToString();
            }
            return CardType.Unknown.ToString();
        }

        public enum CardType
        {
            Visa,
            Mastercard,
            Unknown
        }

        public string GetErrorMessage(int code)
        {
            switch (code)
            {
                case 1:
                    return "Unknown card type";
                case 2:
                    return "No card number provided";
                case 3:
                    return "Credit card number is in invalid format";
                case 4:
                    return "Credit card number is invalid";
                case 5:
                    return "Invalid cardholder name.";
                case 6:
                    return "Invalid CVV length.";
                case 7:
                    return "Credit card number has an inappropriate number of digits";
                case 8:
                    return "Expiration date is invalid.";
                default:
                    return "Unknown error";
            }
        }
    }
}
