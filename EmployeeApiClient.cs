using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Clientapp
{
    internal class EmployeeApiClient
    {
        static Uri url = new Uri("http://localhost:5088/");
        public static async Task CallGetAllEmployee(){
            using (var client = new HttpClient() ){ //
                client.BaseAddress = url;
                HttpResponseMessage response = await client.GetAsync("api/Employee");
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode){
                  String x = await response.Content.ReadAsStringAsync();
                  await Console.Out.WriteLineAsync(x);
                }
            }
        }
     
        public static async Task GetEmployeeById(int id){
            using(var client = new HttpClient()){
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"api/Employee/{id}?id={id}");
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode){
                    String json = await response.Content.ReadAsStringAsync();
                    EmpViewModel emp = JsonConvert.DeserializeObject<EmpViewModel>(json);
                    Console.WriteLine(emp.EmpId + " " + emp.Firstname + " " + emp.Lastname );
                }
            }
        }
        public static async Task AddEmployee(){
            using (var client = new HttpClient()){
                client.BaseAddress = url;
                EmpViewModel emp = new EmpViewModel(){
                    Firstname = "Rajesh",
                    Lastname = "Kumar",
                    Title = "Manager",
                    city = "Bangalore",
                    Birthdate = DateTime.Now,
                    Hiredate = DateTime.Now,
                    ReportsTo = 1
              
                };
                var myContent = JsonConvert.SerializeObject(emp);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //httppost
                HttpResponseMessage response = await client.PostAsync("api/Employee/addemployee", byteContent);
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode){
                  System.Console.WriteLine("Employee added successfully");
                  await Console.Out.WriteAsync (response.StatusCode.ToString());
                }
            }
        }
        public static async Task UpdateEmployee(){
            using (var client = new HttpClient()){
                client.BaseAddress = url;
                EmpViewModel emp = new EmpViewModel(){
                    EmpId = 12,
                    Firstname = "Rajesh",
                    Lastname = "Kumar",
                    Title = "Manager",
                    city = "Bangalore",
                    Birthdate = DateTime.Now,
                    Hiredate = DateTime.Now,
                    ReportsTo = 1
              
                };
                var myContent = JsonConvert.SerializeObject(emp);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //httppost
                HttpResponseMessage response = await client.PutAsync($"/api/Employee/{emp.EmpId}", byteContent);
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode){
                  System.Console.WriteLine("Employee updated successfully");
                  await Console.Out.WriteAsync (response.StatusCode.ToString());
                }
            }
        }
        public static async Task DeleteEmployee(int empid){
            using (var client = new HttpClient()){
                client.BaseAddress = url;
                HttpResponseMessage response = await client.DeleteAsync($"api/Employee/{empid}?id={empid}");
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode){
                  System.Console.WriteLine("Employee deleted successfully");
                  await Console.Out.WriteAsync (response.StatusCode.ToString());
                }
            }
        }
        
    }
}