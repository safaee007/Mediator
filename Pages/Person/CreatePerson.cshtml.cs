using MediatR;
using MediatR_SampleProject.Application.Persons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediatR_SampleProject.Pages.Person
{
    public class CreatePersonModel : PageModel
    {
        private readonly IMediator _mediator;
        public CreatePersonModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var resoponse = await _mediator.Send(new CreatePerson.Command
            { 
                Name = "Saeed Safaee", 
                Age = 1                
            });
            
            return RedirectToPage("Index");
        }
    }
}
