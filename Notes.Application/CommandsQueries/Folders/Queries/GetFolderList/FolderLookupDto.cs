using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;

public class FolderLookupDto: IMapWith<Folder>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Folder, FolderLookupDto>()
            .ForMember(noteDto => noteDto.Id,
                options =>
                    options.MapFrom(folder => folder.Id))
            .ForMember(noteDto => noteDto.Name,
                options =>
                    options.MapFrom(folder => folder.Name));
    }
}