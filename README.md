# Conekta .Net Core v1

This is a .net library that allows interaction with https://api.conekta.io API.

## Installation

Obtain the latest version of the Conekta .Net Core bindings with:

    git clone https://github.com/jcgaribayr/conekta-.net.git

To get started, add the following to your .NET script:

    using conekta;

## Usage

    Api.ApiKey = "";
    Api.Version = "1.0.0";
    Api.Locale = "es";

    Charge charge = new Charge();
    charge.Description = "Test Charge";
    charge.Amount = 29000;
    charge.Currency = "MXN";
    charge.ReferenceId = "2017-01-10";
    charge.Card = "tok_test_visa_4242";

    charge.Details = new Details();
    charge.Details.Name = "Juan Carlos Garibay Ruiz";
    charge.Details.Phone = "0000000000";
    charge.Details.Email = "hola@charlygaribay.com";

    charge.Details.Customer = new Customer();
    charge.Details.Customer.LoggedIn = true;
    charge.Details.Customer.SuccessfulPurchases = 1;
    charge.Details.Customer.CreatedAt = 1379784950;
    charge.Details.Customer.UpdatedAt = 1379784950;
    charge.Details.Customer.OfflinePayments = 1;
    charge.Details.Customer.Score = 9;

    charge.Details.LineItems = new List<LineItem>();
    charge.Details.LineItems.Add(new LineItem
    {
        Name = "Test Item",
        Description = "Test Item",
        UnitPrice = 29000,
        Quantity = 1,
        SKU = "1",
        Category = "Test Category"
    });

    charge.Details.BillingAddress = new BillingAddress();
    charge.Details.BillingAddress.Street1 = "Av. Faro 2350";
    charge.Details.BillingAddress.Street2 = "Planta Baja";
    charge.Details.BillingAddress.Street3 = "Mind Mexico";
    charge.Details.BillingAddress.Zip = "44550";
    charge.Details.BillingAddress.City = "Guadalajara";
    charge.Details.BillingAddress.State = "Jalisco";
    charge.Details.BillingAddress.Country = "Mexico";

    charge.Details.BillingAddress.Phone = "0000000000";
    charge.Details.BillingAddress.Email = "hola@charlygaribay.com";
    charge.Details.BillingAddress.TaxId = "xmn671212drx";

    charge.Details.BillingAddress.CompanyName = "Personal";

    var result = charge.Create(charge.ToJson()).Result;

## Documentation

Please see https://www.conekta.io/docs/api for up-to-date documentation.

License
-------

Developed by [Conekta](https://www.conekta.io). Available with [MIT License](LICENSE).

We are hiring
-------------

If you are a comfortable working with a range of backend languages (Java, Python, Ruby, PHP, ASP.NET, etc) and frameworks, you have solid foundation in data structures, algorithms and software design with strong analytical and debugging skills. 
Send your CV, github to quieroser@conekta.io