var PROGRAM_NAME = "ATG.Collector.Source.Solar.KostalSource";
var TABSYMBOL = "\t";

Console.WriteLine(
    $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}Start"
);

// construct the http client
var authString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes("pvserver:pvwr"));
var client = new HttpClient();
client.DefaultRequestHeaders.Clear();
client.DefaultRequestHeaders.Add("Authorization", "Basic " + authString);
client.Timeout = TimeSpan.FromSeconds(10);

Console.WriteLine(
    $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}Client constructed, fetching results now"
);

//var response = await client.GetAsync("http://192.168.178.150");
var response = await client.GetAsync("http://kostal-piko.fritz.box");
response.EnsureSuccessStatusCode();

Console.WriteLine(
    $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}Results received, printing"
);

var result = await response.Content.ReadAsStringAsync();
Console.WriteLine(result);
