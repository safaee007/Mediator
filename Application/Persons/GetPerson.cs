using MediatR;
using MediatR_SampleProject.ApplicationContext;
using MediatR_SampleProject.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MediatR_SampleProject.Application.Persons
{
    public class GetPerson
    {
        public class Query : IRequest<Response>
        {

        }

        public class Response
        {
            public IList<PersonDto> Persons { get; set; }
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly AppDbContext _db;
            public Handler(AppDbContext db)
            {
                _db = db;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                IList<PersonDto> model = await _db.Persons.Select(s => new PersonDto(s.Id, s.Name, s.Age)).ToListAsync();

                return new Response
                {
                    Persons = model
                };
            }
        }
    }
}
