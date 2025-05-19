
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notepad.Business.DTOs.Note;
using Notepad.Business.Services.Interfaces;
using Notepad.Core.Entities;
using Notepad.Core.Settings;
using Notepad.DAL.Repositories.Interfaces;
using Notepad.DAL.Repositories.Interfaces.Generics;
using Notepad.DAL.UnitOfWorks;

namespace Notepad.Business.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _save;
        private readonly INoteRepo _command;
        private readonly IQueryRepository<Note> _query;
        private readonly Link _link;

        public NoteService(IQueryRepository<Note> query, INoteRepo command, IUnitOfWork save, IMapper mapper, IOptions<Link> link)
        {
            _query = query;
            _command = command;
            _save = save;
            _mapper = mapper;
            _link = link.Value;
        }
        private string NoteUrl(Guid id)
        {
            return $"{_link.env}/api/note/{id}";
        }

        public async Task<NoteDto> CreateAsync(CreateNoteDto dto)
        {
            var note = _mapper.Map<Note>(dto);
            var newNote = await _command.CreateAsync(note);
            await _save.SaveChangesAsync();
            var noteDto = _mapper.Map<NoteDto>(newNote);
            noteDto.NoteUrl = NoteUrl(newNote.Id);
            return noteDto;
        }

        public async Task DeleteAsync(Guid id)
        {
            var noteId = await _query.GetByIdAsync(id);
            if (noteId == null) throw new ArgumentNullException($"Not idsine gore tapilmadi. Id: {id}");
            await _command.DeleteAsync(noteId);
            await _save.SaveChangesAsync();
        }

        public async Task<ICollection<NoteDto>> GetAllNote()
        {
           var allNote = await _query.GetAllAsync().ToListAsync();
           var noteDtos = _mapper.Map<ICollection<NoteDto>>(allNote);

            foreach (var noteDto in noteDtos)
            {
                noteDto.NoteUrl = NoteUrl(noteDto.Id);
            }
            return noteDtos;
        }
        public async Task<NoteDto> GetNoteById(Guid id)
        {
            var noteId = await _query.GetByIdAsync(id);
            if (noteId == null) throw new ArgumentNullException($"Not idsine gore tapilmadi. Id: {id}");
            var noteDto =  _mapper.Map<NoteDto>(noteId);
            noteDto.NoteUrl= NoteUrl(noteDto.Id);
            return noteDto;
        }

        public async Task UpdateAsync(UpdateNoteDto dto)
        {
            var noteId = await _query.GetByIdAsync(dto.Id);
            if (noteId == null) throw new ArgumentNullException($"Not idsine gore tapilmadi. Id: {dto.Id}");
            await _command.UpdateAsync(noteId);
            await _save.SaveChangesAsync();
        }
    }
}
