
using AutoMapper;
using Notepad.Business.DTOs.Note;
using Notepad.Core.Entities;

namespace Notepad.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Note
            CreateMap<NoteDto, Note>().ReverseMap();
            CreateMap<CreateNoteDto, Note>().ReverseMap();
            CreateMap<UpdateNoteDto, Note>().ReverseMap();
            #endregion
        }
    }
}
