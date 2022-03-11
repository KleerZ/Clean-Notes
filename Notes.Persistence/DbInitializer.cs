namespace Notes.Persistence;

public class DbInitializer
{
    public static void Initialize(NoteDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
    }
}