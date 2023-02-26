
//test();
//async Task test()
//{
//     LongProcess();
//     ShortProcess();
//    Console.ReadKey();
//}
// async Task LongProcess()
//{
//    Console.WriteLine("LongProcess Started");
//    Thread.Sleep(3000); 
//    Console.WriteLine("LongProcess Completed");
//}

// async Task ShortProcess()
//{
//    Console.WriteLine("ShortProcess Started");

//    Thread.Sleep(1000);

//    Console.WriteLine("ShortProcess Completed");
//}

using System.Net.Http;
using System.Net.Http.Json;

HttpClient _httpClient = new HttpClient();
var state = await _httpClient.GetFromJsonAsync<DTOState>("api/State/GetStateById?" + 2);

public class DTOState
{
    public int StateId { get; set; }
    public string Name { get; set; }
}
