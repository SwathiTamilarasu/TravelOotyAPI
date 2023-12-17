﻿namespace TravelOoty.API.Model
{
    public class TransactionDetails
    {
        public int PaymentDetailsId { get; set; }

        public string order_id { get; set; }

        public string cf_payment_id { get; set; }

        public string payment_amount { get; set; }

        public string payment_currency { get; set; }

        public string bank_reference { get; set; }

        public string payment_group { get; set; }

        public string payment_status { get; set; }
    }
}
