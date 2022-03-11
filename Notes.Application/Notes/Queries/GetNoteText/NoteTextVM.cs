using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class NoteTextVM: IMapWith<Note>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteTextVM>()
            .ForMember(noteVM => noteVM.Title,
                options =>
                    options.MapFrom(note => note.Title))
            .ForMember(noteVM => noteVM.Text,
                options =>
                    options.MapFrom(note => note.Text))
            .ForMember(noteVM => noteVM.Id,
            options =>
                options.MapFrom(note => note.Id))
            .ForMember(noteVM => noteVM.CreationDate,
            options =>
                options.MapFrom(note => note.CreationDate))
            .ForMember(noteVM => noteVM.EditDate,
            options =>
                options.MapFrom(note => note.EditDate));
    }
}