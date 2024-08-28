using BlazingTrails.Client.Features.Home;
using BlazingTrails.Shared.Features.ManageTrails;
using FluentValidation;
using MediatR;

namespace BlazingTrails.Client.Features.ManageTrails
{
    public record AddTrailRequest(TrailDto Trail):IRequest<AddTrailRequest.Response>
    {
        // адрес конечной точки API запроса
        public const string RouteTemplate = "/api/trails";

        // вложенная запись определяет данные ответа на запрос
        public record Response(int TrailId);
    }

    // Валидатор запроса.Он будет выполняться API, чтобы убедиться, что данные запроса корректны
    public class AddTrailRequestValidator : AbstractValidator<AddTrailRequest>
    {
        public AddTrailRequestValidator()
        {
            // Опеределяет TrailValidator в качестве валидатора свойства Trail.
            // Позволяет повторно использовать созданные нами ранее правила валидации
            RuleFor(x => x.Trail).SetValidator(new TrailValidator());
        }
    }
}
