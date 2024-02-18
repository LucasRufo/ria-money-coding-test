using Exercise02.HttpSimulator;
using System.Net.Http.Json;
using System.Text.Json;

//This delay is necessary when the apps are running using docker-compose.
//The "depends_on" option on docker-compose does not ensure that the API container is totally ready for execution.
//We could use a retry on the HTTP call, but for simplicity we are using a delay.
await Task.Delay(2000);

var baseUrlFromEnv = Environment.GetEnvironmentVariable("CUSTOMERS_API_URL");

var baseUrl = baseUrlFromEnv ?? "http://localhost:8080/";
var path = "/customers";

//Change this number to increase or decrease the number of requests.
var maxNumberOfRequests = 500;

var customerGenerator = new CustomerGenerator();

using var httpClient = new HttpClient()
{
    BaseAddress = new Uri(baseUrl)
};

var tasks = new List<Task>();

for (int i = 0; i < maxNumberOfRequests; i++)
{
    tasks.Add(SendPostCustomer());
    tasks.Add(SendGetCustomers());
}

async Task SendPostCustomer()
{
    var customers = customerGenerator.GenerateCustomers(RandomCustom.Next(2, 5));

    var result = await httpClient.PostAsJsonAsync(path, customers);

    var response = await result.Content.ReadAsStringAsync();

    Console.WriteLine($"POST /customers {result.StatusCode} - {JsonSerializer.Serialize(customers)} - {response}");
}

async Task SendGetCustomers() 
{
    var result = await httpClient.GetAsync(path);

    Console.WriteLine($"GET /customers {result.StatusCode}");
}

await Task.WhenAll(tasks);

Console.Read();