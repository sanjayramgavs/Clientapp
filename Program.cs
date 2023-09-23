using Clientapp;

System.Console.WriteLine("api client");
//EmployeeApiClient.CallGetAllEmployee().Wait();
EmployeeApiClient.DeleteEmployee(12).Wait();
Console.ReadLine();
