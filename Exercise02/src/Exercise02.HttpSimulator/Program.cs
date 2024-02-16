using Exercise02.HttpSimulator;
using System.Net.Http.Json;
using System.Text.Json;

var baseUrl = "http://localhost:8080/";
var uri = "/customers";

var customerGenerator = new CustomerGenerator();

using var httpClient = new HttpClient()
{
    BaseAddress = new Uri(baseUrl)
};

var maxNumberOfRequests = 100;

var tasks = new List<Task>();

for (int i = 0; i < maxNumberOfRequests; i++)
{
    tasks.Add(SendPostCustomer());
    tasks.Add(SendGetCustomers());
}

async Task SendPostCustomer()
{
    var customers = customerGenerator.GenerateCustomers(RandomCustom.Next(2, 5));

    var result = await httpClient.PostAsJsonAsync(uri, customers);

    var response = await result.Content.ReadAsStringAsync();

    Console.WriteLine($"POST /customers {result.StatusCode} - {JsonSerializer.Serialize(customers)} - {response}");
}

async Task SendGetCustomers() 
{
    var result = await httpClient.GetAsync(uri);

    Console.WriteLine($"GET /customers {result.StatusCode}");
}

await Task.WhenAll(tasks);

Console.ReadKey();







