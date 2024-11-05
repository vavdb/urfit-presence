using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using urfit_presence;
using urfit_presence.Data;

public class SubscriptionService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IFlurlClient _informerFlurlClient;

     public SubscriptionService(IFlurlClientCache clients, UserManager<ApplicationUser> userManager)
     {
         _informerFlurlClient = clients.Get("InformerApi");
         _userManager = userManager;
     }


    public async Task SyncSubscriptionsToUsers()
    {
        try
        {
            // var _informerFlurlClient = clients.Get("InformerApi");
            // var _userManager = userManager;
            
            var subscriptions = await _informerFlurlClient.Request()
                                                         .AppendPathSegment("subscriptions")
                                                         .SetQueryParams()
                                                         .GetJsonAsync<SubscriptionRootObject>();

            var relations = await _informerFlurlClient.Request()
                                                          .AppendPathSegment("relations")
                                                          .SetQueryParams()
                                                          .GetJsonAsync<RelationRootObject>();


            var subscribedRelationIds = subscriptions.Subscriptions.Select(x => x.Value.RelationId);

            var bootcampers = relations.Relation.Where(r => subscribedRelationIds.Contains(r.Key));


            foreach (var b in bootcampers)
            {
                var user = await _userManager.FindByEmailAsync(b.Value.Email.ToLower());
                if (user is null)
                {
                    var newUsername = (b.Value.FirstName.ToLower().Trim() + b.Value.SurnamePrefix.ToLower().Trim() + b.Value.Surname.ToLower().Trim()).Replace(" ", "");
                    if (string.IsNullOrWhiteSpace(newUsername))
                    {
                        continue;
                    }
                    user = new ApplicationUser
                           {
                               UserName = newUsername,
                               Email = b.Value.Email
                           };
                    
                    var p = b.Value.Zip.ToLower().Trim() + b.Value.HouseNumber.ToLower().Trim() + b.Value.HouseNumberSuffix.ToLower().Trim();

                    try
                    {
                        var result = await _userManager.CreateAsync(user, p);
                        user = await _userManager.FindByEmailAsync(b.Value.Email.ToLower());
                    } catch (Exception ex)
                    {
                        throw;
                    }
                }

                if (user is null)
                {
                    var xxx1 = '1';
                }


                if (user.InformationRelationId != b.Key) user.InformationRelationId = b.Key;
                if (user.FirstName != b.Value.FirstName) user.FirstName = b.Value.FirstName;
                if (user.SurNamePrefix != b.Value.SurnamePrefix) user.SurNamePrefix = b.Value.SurnamePrefix;
                if (user.SurName != b.Value.Surname) user.SurName = b.Value.Surname;
                if (user.EmailConfirmed != true) user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                var s = subscriptions.Subscriptions.FirstOrDefault(s => s.Value.RelationId == user.InformationRelationId).Value;
                var subscriptionEndDateString = s.SubscriptionEndDate ?? DateTime.MinValue.ToString("yyyy-MM-dd");
                var subscriptionEndDate = DateOnly.Parse(subscriptionEndDateString);
                if (subscriptionEndDate > DateOnly.FromDateTime(DateTime.Now))
                {
                    await _userManager.AddToRoleAsync(user, "Bootcamper");
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, "Bootcamper");
                }
            }
        } catch (HttpRequestException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }


    public class LineItem
    {
        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("qty")]
        public string Qty { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("discount")]
        public string Discount { get; set; }

        [JsonPropertyName("vat_id")]
        public string VatId { get; set; }

        [JsonPropertyName("vat_percentage")]
        public string VatPercentage { get; set; }

        [JsonPropertyName("ledger_account_id")]
        public string LedgerAccountId { get; set; }

        [JsonPropertyName("costs_id")]
        public string CostsId { get; set; }
    }

    public class Subscription
    {
        [JsonPropertyName("relation_id")]
        public string RelationId { get; set; }

        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("contact_name")]
        public string ContactName { get; set; }

        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }

        [JsonPropertyName("payment_condition_id")]
        public string PaymentConditionId { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("date")]
        public string  Date { get; set; }

        [JsonPropertyName("expiry_days")]
        public string ExpiryDays { get; set; }

        [JsonPropertyName("expiry_date")]
        public string  ExpiryDate { get; set; }

        [JsonPropertyName("expired")]
        public string Expired { get; set; }

        [JsonPropertyName("total_price_excl_vat")]
        public string  TotalPriceExclVat { get; set; }

        [JsonPropertyName("total_price_incl_vat")]
        public string  TotalPriceInclVat { get; set; }

        [JsonPropertyName("vat_option")]
        public string VatOption { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("footer_text")]
        public string FooterText { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("concept")]
        public string Concept { get; set; }

        [JsonPropertyName("subscription_type_id")]
        public string SubscriptionTypeId { get; set; }

        [JsonPropertyName("subscription_frequency")]
        public string SubscriptionFrequency { get; set; }

        [JsonPropertyName("subscription_start_date")]
        public string  SubscriptionStartDate { get; set; }

        [JsonPropertyName("subscription_invoice_date")]
        public string  SubscriptionInvoiceDate { get; set; }

        [JsonPropertyName("subscription_end_date")]
        public string  SubscriptionEndDate { get; set; }

        [JsonPropertyName("subscription_restriction")]
        public string SubscriptionRestriction { get; set; }

        [JsonPropertyName("subscription_times")]
        public string SubscriptionTimes { get; set; }

        [JsonPropertyName("subscription_send")]
        public string SubscriptionSend { get; set; }

        [JsonPropertyName("reminder_status")]
        public string ReminderStatus { get; set; }

        [JsonPropertyName("last_reminder_date")]
        public string  LastReminderDate { get; set; }

        [JsonPropertyName("invoice_url")]
        public string InvoiceUrl { get; set; }

        [JsonPropertyName("line")]
        public Dictionary<string, LineItem> Line { get; set; }
    }

    public class SubscriptionRootObject
    {
        [JsonPropertyName("subscriptions")]
        public Dictionary<string, Subscription> Subscriptions { get; set; }
    }
    
    
public class Contact
{
    [JsonPropertyName("initials")]
    public string Initials { get; set; }

    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }

    [JsonPropertyName("surname_prefix")]
    public string SurnamePrefix { get; set; }

    [JsonPropertyName("surname")]
    public string Surname { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("function")]
    public string Function { get; set; }

    [JsonPropertyName("department")]
    public string Department { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("mobile")]
    public string Mobile { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
}

public class RelationId
{
    [JsonPropertyName("relation_number")]
    public string RelationNumber { get; set; }

    [JsonPropertyName("relation_type")]
    public string RelationType { get; set; }

    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }

    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }

    [JsonPropertyName("surname_prefix")]
    public string SurnamePrefix { get; set; }

    [JsonPropertyName("surname")]
    public string Surname { get; set; }

    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("house_number")]
    public string HouseNumber { get; set; }

    [JsonPropertyName("house_number_suffix")]
    public string HouseNumberSuffix { get; set; }

    [JsonPropertyName("zip")]
    public string Zip { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("fax_number")]
    public string FaxNumber { get; set; }

    [JsonPropertyName("web")]
    public string Web { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("coc")]
    public string Coc { get; set; }

    [JsonPropertyName("vat")]
    public string Vat { get; set; }

    [JsonPropertyName("iban")]
    public string Iban { get; set; }

    [JsonPropertyName("bic")]
    public string Bic { get; set; }

    [JsonPropertyName("email_invoice")]
    public string EmailInvoice { get; set; }

    [JsonPropertyName("sales_invoice_template_id")]
    public string SalesInvoiceTemplateId { get; set; }

    [JsonPropertyName("payment_condition_id")]
    public string PaymentConditionId { get; set; }

    [JsonPropertyName("contacts")]
    public Contact Contacts { get; set; }
}

public class Relation
{
    [JsonPropertyName("id")]
    public RelationId Id { get; set; }
}

public class RelationRootObject
{
    [JsonPropertyName("relation")]
    public Dictionary<string, RelationId> Relation { get; set; }
}
}