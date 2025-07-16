using ProjectClientHub.Communication.Requests;
using ProjectClientHub.Communication.Responses;
using ProjectClientHub.Exceptions.ExceptionsBase;

namespace ProjectClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(RequestClientJson request)
    {

        var validator = new RegisterClientValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList(); 

            throw new ErrorOnValidationException(errors);
        }

        // CONTINUA A REGRA DE NEGOCIO

        return new ResponseClientJson();

    }

}
