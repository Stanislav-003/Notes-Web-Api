using FluentValidation;
using Notes.Application.Notes.Commands.CreateNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator() 
        {
            RuleFor(updtaeNoteCommand => updtaeNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updtaeNoteCommand => updtaeNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updtaeNoteCommand => updtaeNoteCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}
