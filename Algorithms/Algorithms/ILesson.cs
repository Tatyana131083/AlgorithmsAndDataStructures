
namespace Algorithms
{
    internal interface ILesson
    {
        public string LessonID { get; }
        public string Description { get; }
        public void Print();
    }
}
