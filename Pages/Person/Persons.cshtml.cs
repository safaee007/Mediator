using MediatR;
using MediatR_SampleProject.Application.Persons;
using MediatR_SampleProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediatR_SampleProject.Pages.Person
{
    public class PersonsModel : PageModel
    {
        public IList<PersonDto> PersonList { get; set; }
        private readonly IMediator _mediator;
        public PersonsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGet()
        {
            var res = await _mediator.Send(new GetPerson.Query());
            PersonList = res.Persons;

            return Page();
        }
    }
}
