using AutoMapper;
using Notes.Application.Common.Mappings;

namespace Notes.Application.CommandsQueries.Tasks.Queries.GetTask;

public class TaskVm: IMapWith<Domain.Tasks>
{
    public Guid Id { get; set;}
    public string Title { get; set; }
    public DateTime EditDate { get; set; }
    public bool isCompleted { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Tasks, TaskVm>()
            .ForMember(taskVM => taskVM.Id,
                options =>
                    options.MapFrom(task => task.Id))
            .ForMember(taskVM => taskVM.Title,
                options =>
                    options.MapFrom(task => task.Title))
            .ForMember(taskVM => taskVM.EditDate,
                options =>
                    options.MapFrom(task => task.EditDate))
            .ForMember(taskVM => taskVM.isCompleted,
                options =>
                    options.MapFrom(task => task.isCompleted));
    }
}