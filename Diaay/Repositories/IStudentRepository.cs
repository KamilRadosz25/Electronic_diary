namespace Diary.Repositories
{
    public interface IStudentRepository
    {
        void Add(string firstName, string lastName);

        void Delete(string firstName, string lastName);

        void GetAll();
    }
}