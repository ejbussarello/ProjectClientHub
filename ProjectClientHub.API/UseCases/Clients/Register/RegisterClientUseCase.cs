using ProjectClientHub.API.Entities;
using ProjectClientHub.API.Infrastructure;
using ProjectClientHub.Communication.Requests;
using ProjectClientHub.Communication.Responses;
using ProjectClientHub.Exceptions.ExceptionsBase;

namespace ProjectClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(RequestClientJson request)
    {
        Validate(request);

        var dbContext = new ProjectClientHubDbContext();

        var entity = new Client
        {
            Name = request.Name,
            Email = request.Email
        };

        dbContext.Clients.Add(entity);
        dbContext.SaveChanges();

        return new ResponseClientJson
        {
            Id = entity.Id,
            Name = entity.Name
        };

    }

    private void Validate(RequestClientJson request)
    {
        var validator = new RegisterClientValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }

}
