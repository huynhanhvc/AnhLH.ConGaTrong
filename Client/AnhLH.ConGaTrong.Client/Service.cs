using AnhLH.ConGaTrong.Client.Dtos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnhLH.ConGaTrong.Client
{
    public class Service
    {
        private static string linkAPI = "https://localhost:44343";
        
        public static CustomersDto GetCustomer(string phoneNumber)
        {
            var options = new RestClientOptions(linkAPI)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/customers/" + phoneNumber, Method.Get);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<CustomersDto>(response.Content);
           
        }

        public static List<CustomersDto> GetListCustomer()
        {
            var options = new RestClientOptions(linkAPI)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/customers", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<CustomersDto>>(response.Content);

        }

        public static CustomersDto CreatedCustomer(CustomersDto customersDto)
        {
            var options = new RestClientOptions(linkAPI)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/customers/created", Method.Post);
            request.AddBody(customersDto);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<CustomersDto>(response.Content);

        }

        public static OrderResponseDto CreatedOrder(OrderDto orderDto)
        {
            var options = new RestClientOptions(linkAPI)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/orders/created", Method.Post);
            request.AddBody(orderDto);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<OrderResponseDto>(response.Content);

        }

        public static List<OrderResponseDto> GetListOrder()
        {
            var options = new RestClientOptions(linkAPI)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/orders", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                
                return null;
            }

            return JsonConvert.DeserializeObject<List<OrderResponseDto>>(response.Content);

        }

        public static List<TicketResultsDto> GetListTicket()
        {
            var options = new RestClientOptions(linkAPI)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/ticket", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<TicketResultsDto>>(response.Content);

        }

        public static void CreatedTicket()
        {
            var options = new RestClientOptions(linkAPI)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/ticket/created", Method.Get);
            RestResponse response = client.Execute(request);

        }
    }
}
