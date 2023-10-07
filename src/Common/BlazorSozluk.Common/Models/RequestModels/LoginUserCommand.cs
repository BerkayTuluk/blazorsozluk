using BlazorSozluk.Common.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.RequestModels;

public class LoginUserCommand : IRequest<LoginUserViewModel>
{
    //Dışarıdan Aldığımız Veriler
    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public LoginUserCommand(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }

    public LoginUserCommand()
    {

    }
}
