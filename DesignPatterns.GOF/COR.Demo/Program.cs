using COR.Demo.Handlers.Core;
using COR.Demo.Handlers.Infra;
using COR.Demo.Handlers.Infra.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;


Console.WriteLine("COR Demo");
var user = new User
{
    Id = 1,
    Password = "password",
    Age = 21,
    Country = "ind",
    Email = "a@b.c"
};




IHandler<User> handler1 = new AgeHandler();

//handler1=user.Country switch
//{
//    "ind" => handler1.Next(new CountryHandler()).Next(new HashPasswordHandler()).Next(new EmailSignUpHandler()),
//    "US" => handler1.Next(new HashPasswordHandler()),
//    "SWE" => handler1.Next(new EmailSignUpHandler()),
//    _ => throw new Exception("No Match found")
//};

//IHandler<User> handler1 = new AgeHandler();
handler1.Next(new CountryHandler())
       .Next(new HashPasswordHandler())
       .Next(new EmailSignUpHandler());

handler1.Handle(user);

Console.WriteLine(user.ToString());
Console.ReadKey();
Console.WriteLine("-------------End-------------");

IServiceProvider provider = ConfigureServices();

IServiceProvider ConfigureServices()
{
    return new ServiceCollection()
           .BuildServiceProvider();
}




