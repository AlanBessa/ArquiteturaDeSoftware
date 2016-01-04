namespace MWS.Domain.Commands.CategoryCommands
{
    public class EditCategoryCommand
    {
        public EditCategoryCommand(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }

        public string Title { get; set; }
    }
}