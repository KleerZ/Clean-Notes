using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class NoteLookupDto: IMapWith<Note>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime EditDate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteLookupDto>()
            .ForMember(noteDto => noteDto.Id,
                options =>
                    options.MapFrom(note => note.Id))
            .ForMember(noteDto => noteDto.Title,
                options =>
                    options.MapFrom(note => note.Title))
            .ForMember(noteDto => noteDto.Text,
                options =>
                    options.MapFrom(note => note.Text))
            .ForMember(noteDto => noteDto.EditDate,
                options =>
                    options.MapFrom(note => note.EditDate));
    }
}