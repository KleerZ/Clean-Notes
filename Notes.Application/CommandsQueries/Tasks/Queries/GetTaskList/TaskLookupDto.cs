using AutoMapper;
using Notes.Application.Common.Mappings;

namespace Notes.Application.Tasks.Queries.GetTaskList;

public class TaskLookupDto: IMapWith<Domain.Tasks>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Dictionary<string, string[]> TaskItems { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Tasks, TaskLookupDto>()
            .ForMember(taskDto => taskDto.Id,
                options =>
                    options.MapFrom(task => task.Id))
            .ForMember(taskDto => taskDto.Title,
                options =>
                    options.MapFrom(task => task.Title));
    }
}