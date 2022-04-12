using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Queries.GetFolder;

public class FolderVM: IMapWith<Folder>
{
    public Guid Id { get; set;}
    public Guid UserId { get; set;}
    public string Name { get; set;}
    public List<Note> Notes { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Folder, FolderVM>()
            .ForMember(folderVM => folderVM.Id,
                options =>
                    options.MapFrom(folder => folder.Id))
            .ForMember(folderVM => folderVM.UserId,
                options =>
                    options.MapFrom(folder => folder.UserId))
            .ForMember(folderVM => folderVM.Name,
                options =>
                    options.MapFrom(folder => folder.Name))
            .ForMember(folderVM => folderVM.Notes,
                options =>
                    options.MapFrom(folder => folder.Notes));
    }
}