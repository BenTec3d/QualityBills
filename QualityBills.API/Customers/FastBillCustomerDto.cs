using Newtonsoft.Json;

namespace QualityBills.API.Customers
{
    public class FastBillCustomerDto
    {
        [JsonProperty("CUSTOMER_ID")]
        public int CustomerId { get; set; }
        //public string CustomerId { get; set; } = string.Empty;

        [JsonProperty("CUSTOMER_NUMBER")]
        public string CustomerNumber { get; set; } = string.Empty;

        [JsonProperty("DAYS_FOR_PAYMENT")]
        public int DaysForPayment { get; set; }
        //public string DaysForPayment { get; set; } = string.Empty;

        [JsonProperty("CREATED")]
        public DateTime Created { get; set; }
        //public string Created { get; set; } = string.Empty;

        [JsonProperty("PAYMENT_TYPE")]
        public int PaymentType { get; set; }
        //public string PaymentType { get; set; } = string.Empty;

        [JsonProperty("BANK_NAME")]
        public string BankName { get; set; } = string.Empty;

        [JsonProperty("BANK_ACCOUNT_NUMBER")]
        public string BankAccountNumber { get; set; } = string.Empty;

        [JsonProperty("BANK_CODE")]
        public string BankCode { get; set; } = string.Empty;

        [JsonProperty("BANK_ACCOUNT_OWNER")]
        public string BankAccountOwner { get; set; } = string.Empty;

        [JsonProperty("BANK_IBAN")]
        public string BankIban { get; set; } = string.Empty;

        [JsonProperty("BANK_BIC")]
        public string BankBic { get; set; } = string.Empty;

        [JsonProperty("BANK_ACCOUNT_MANDATE_REFERENCE")]
        public string BankAccountMandateReference { get; set; } = string.Empty;

        [JsonProperty("SHOW_PAYMENT_NOTICE")]
        public string ShowPaymentNotice { get; set; } = string.Empty;
        //public int ShowPaymentNotice { get; set; }

        [JsonProperty("CUSTOMER_ACCOUNT")]
        public string CustomerAccount { get; set; } = string.Empty;

        [JsonProperty("CUSTOMER_TYPE")]
        public string CustomerType { get; set; } = string.Empty;

        [JsonProperty("TOP")]
        public int Top { get; set; }
        //public string Top { get; set; } = string.Empty;

        [JsonProperty("NEWSLETTER_OPTIN")]
        public int NewsletterOptin { get; set; }
        //public string NewsletterOptin { get; set; } = string.Empty;

        [JsonProperty("ORGANIZATION")]
        public string Organization { get; set; } = string.Empty;

        [JsonProperty("POSITION")]
        public string Position { get; set; } = string.Empty;

        [JsonProperty("ACADEMIC_DEGREE")]
        public string AcademicDegree { get; set; } = string.Empty;

        [JsonProperty("SALUTATION")]
        public string Salutation { get; set; } = string.Empty;

        [JsonProperty("FIRST_NAME")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("LAST_NAME")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("ADDRESS")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty("ADDRESS_2")]
        public string Address2 { get; set; } = string.Empty;

        [JsonProperty("ZIPCODE")]
        public string ZipCode { get; set; } = string.Empty;

        [JsonProperty("CITY")]
        public string City { get; set; } = string.Empty;

        [JsonProperty("COUNTRY_CODE")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty("SECONDARY_ADDRESS")]
        public string SecondaryAddres { get; set; } = string.Empty;

        [JsonProperty("PHONE")]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty("PHONE_2")]
        public string Phone2 { get; set; } = string.Empty;

        [JsonProperty("FAX")]
        public string Fax { get; set; } = string.Empty;

        [JsonProperty("MOBILE")]
        public string Mobile { get; set; } = string.Empty;

        [JsonProperty("EMAIL")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("WEBSITE")]
        public string Website { get; set; } = string.Empty;

        [JsonProperty("VAT_ID")]
        public string VatId { get; set; } = string.Empty;

        [JsonProperty("CURRENCY_CODE")]
        public string CurrencyCode { get; set; } = string.Empty;

        [JsonProperty("LASTUPDATE")]
        public DateTime LastUpdate { get; set; }
        //public string LastUpdate { get; set; } = string.Empty;

        [JsonProperty("TAGS")]
        public string Tags { get; set; } = string.Empty;

        [JsonProperty("DOCUMENT_HISTORY_URL")]
        public string DocumentHistoryUrl { get; set; } = string.Empty;
    }
}
