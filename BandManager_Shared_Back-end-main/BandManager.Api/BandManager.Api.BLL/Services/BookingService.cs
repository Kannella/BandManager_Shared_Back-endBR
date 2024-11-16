using BandManager.Api.BLL.Utilities;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BandManager.Api.BLL.Services
{
    public class BookingService : DirectDbService<Booking>
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void ShareOnFacebook(int bookingId)
        {
            var booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                throw new KeyNotFoundException("Evento não encontrado.");
            }

            // Acessando os dados do Booking para o post
            string title = booking.Name ?? "Event";
            string date = booking.ShowStartTime?.ToString("dd/MM/yyyy HH:mm") ?? "Date not specified";
            string location = booking.Venue != null ? booking.Venue.Address : "Location not specified";
            string description = booking.Description ?? "No description available";

            // Definir o token de acesso e a URL da API do Facebook
            string accessToken = "EAARFbXMNqhwBO4v8GrRMes3aYqtaXYMcZAHqfypKZAfNbdMA7EzoFXw2xVF2syuXdMGfwpGjvEZCxnO9ZB6wCtah7uB3eWnAhKnBTfE9pUZBROlqSTOmlMyfdUA5lMLm2wDK5E9FEOC6nA6s7nKilgH0MAvnLf4HquFS3ZCe3ZCZCzMY3N55z8gtYVfiKyGy1qmlOyM28W0Ybs7LfE9nYAZDZD";
            string pageId = "1202236290869788";
            string url = $"https://graph.facebook.com/{pageId}/feed?access_token={accessToken}";

            // Criar o conteúdo do post com base nos dados do evento
            var postContent = new
            {
                message = $"Confira nosso evento: {title}\nData: {date}\nLocal: {location}\nDescrição: {description}"
            };

            using var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(postContent), Encoding.UTF8, "application/json");

            // Enviar a requisição POST para o Facebook
            var response = client.PostAsync(url, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao compartilhar o evento no Facebook: " + response.ReasonPhrase);
            }
        }
    }
}
