using MediatR;
using MediatR_SampleProject.ApplicationContext;

namespace MediatR_SampleProject.Application.Persons
{
    public class CreatePerson
    {
        public class Command : IRequest<Response>
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Response
        {
            public int Id { get; set; } 
        }

        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly AppDbContext _db;
            public Handler(AppDbContext db)
            {
                _db = db;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var model = _db.Persons.Add(new Entities.Person
                {
                    Name = request.Name,
                    Age = request.Age
                });
                await _db.SaveChangesAsync();

                return new Response
                {
                    Id = model.Entity.Id
                };
            }
        }
    }
}
