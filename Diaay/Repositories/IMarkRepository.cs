namespace Diary.Repositories
{
    public interface IMarkRepository
    {
        void Add(string firstName, string lastName, string subject, string type, int mark);
    }
}