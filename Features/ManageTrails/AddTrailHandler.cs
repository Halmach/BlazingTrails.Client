using System.Net.Http.Json;
using MediatR;

namespace BlazingTrails.Client.Features.ManageTrails
{
    // обработчики запросов реализуют интерфейс IRequestHandler<TRequest,TResponse>.
    // TRequestHandler - это тип запроса, который обрабатывает обработчик.
    // TResponse - тип ответа, который вернет обработчик
    public class AddTrailHandler: IRequestHandler<AddTrailRequest,AddTrailRequest.Response>
    {
        private readonly HttpClient _httpClient;

        // Внедряем экземпляр HttpClient и сохраняем
        // в поле, которое будет использоваться для вызовов API
        public AddTrailHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Метод Handler определяется интерфейсом IRequestHandler и вызывается для обработки запроса MediatR
        public async Task<AddTrailRequest.Response> Handle(AddTrailRequest request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync(AddTrailRequest.RouteTemplate, request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var trailId = await response.Content.ReadFromJsonAsync<int>(cancellationToken:cancellationToken);
                return new AddTrailRequest.Response(trailId);
            }
            else
            {
                return new AddTrailRequest.Response(-1);
            }
        }
    }
}
