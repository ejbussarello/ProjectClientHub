using ProjectClientHub.Communication.Requests;
using ProjectClientHub.Communication.Responses;

namespace ProjectClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(RequestClientJson request)
    {

        var validator = new RegisterClientValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            throw new ArgumentException("ERRO NOS DADOS RECEBIDOS");
        }

        // CONTINUA A REGRA DE NEGOCIO

        return new ResponseClientJson();

    }

}
