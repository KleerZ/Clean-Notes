using Microsoft.Extensions.DependencyInjection;
using Notes.Services.Services;

namespace Notes.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<NoteService>();

        return services;
    }
}