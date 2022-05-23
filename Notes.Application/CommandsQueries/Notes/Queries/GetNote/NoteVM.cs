using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNote;

public class NoteVM: IMapWith<Note>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public DateTime? EditDate { get; set; }
    public Guid? Folder { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteVM>()
            .ForMember(noteVM => noteVM.Title,
                options =>
                options.MapFrom(note => note.Title))
            .ForMember(noteVM => noteVM.Text,
                options =>
                options.MapFrom(note => note.Text))
            .ForMember(noteVM => noteVM.Id,
            options =>
                options.MapFrom(note => note.Id))
            .ForMember(noteVM => noteVM.EditDate,
            options =>
                options.MapFrom(note => note.EditDate))
            .ForMember(noteVM => noteVM.Folder,
            options =>
                options.MapFrom(note => note.FolderId));
    }
}