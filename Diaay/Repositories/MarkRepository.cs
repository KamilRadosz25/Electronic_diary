using Diary.Database;
using Diary.Helpers;
using System;

namespace Diary.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly IDatabaseConnection dbConnection;

        public MarkRepository(IDatabaseConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void Add(string firstName, string lastName, string subject, string type, int mark)
        {
            var sql = string.Format("INSERT INTO marks(id_student,id_subject,id_type,mark) VALUES((select id_student from students where first_name='{0}' and last_name='{1}'),(select id_subject from subjects where name='{2}'),(select id_type from type_marks where type_mark='{3}'),{4})", firstName, lastName, subject, type, mark);
            dbConnection.ExecuteNonQuery(sql);
            ConsoleHelpers.WriteLineWithColor("Ocena Dodana", ConsoleColor.Green);
        }
    }
}
