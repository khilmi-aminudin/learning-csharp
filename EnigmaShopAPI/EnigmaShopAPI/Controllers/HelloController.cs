using Microsoft.AspNetCore.Mvc;

namespace EnigmaShopAPI.Controllers;

[ApiController]
[Route("/api/hello")]
public class HelloController
{
     [HttpGet]
     public string SayHello()
     {
         return "Hello World";
     }
//
//     [HttpGet("get-object")]
//     public object GetObject()
//     {
//         return new
//         {
//             Id = Guid.NewGuid(),
//             Name = "Budi",
//             Date = DateTime.Now
//         };
//     }
//     
//     [HttpGet("get-array")]
//     public List<Object> GetArray()
//     {
//         return new List<object>
//         {
//             new
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "Agus",
//                 Date = DateTime.Now
//             },
//             new
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "Budi",
//                 Date = DateTime.Now
//             },
//             new
//             {
//                 Id = Guid.NewGuid(),
//                 Name = "Caca",
//                 Date = DateTime.Now
//             },
//         };
//     }
//     
//     [HttpGet("{name}")]
//     public Object GetHello(string name)
//     {
//         return new
//         {
//             Id = Guid.NewGuid(),
//             Name = name,
//             Date = DateTime.Now
//         };
//     }
//
//
//     [HttpGet("query-params")]
//     public Object QueryParam([FromQuery] string name, [FromQuery] bool isActive)
//     {
//         
//         return new
//         {
//             Name = name,
//             IsActive = isActive
//         };
//     }
}