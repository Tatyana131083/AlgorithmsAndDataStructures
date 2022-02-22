
namespace Ilesson
{
    public interface ILesson
    {
        public string LessonID { get; }
        public string Description { get; }
        public void Print();
    }
}
