
using MusicLessonSiteApi.Models;
using MusicLessonSiteApi.Controllers;
using MusicLessonSiteApi.Filters;
namespace MusicLessonSiteApi.Models.Repositories
{
    public class CourseRepository2
    {
        private static List<Course> courses = new List<Course>()
        {
            new Course { Id = 1, Instrument = "Guitar", PlayerLevel = "Advanced", Price = 10 },
            new Course { Id = 2, Instrument = "Bass" , PlayerLevel = "Beginner", Price = 12 },
            new Course { Id = 3, Instrument = "Piano", PlayerLevel = "Moderate", Price = 9 },
            new Course { Id = 4, Instrument = "Saxophone", PlayerLevel = "Beginner", Price = 15 },
            new Course { Id = 5, Instrument = "Guitar", PlayerLevel = "Moderate", Price = 11 }
        };

        public static List<Course> GetCourses()
        {
            return courses;
        }

        public static bool CourseExists(int id)
        {
            return courses.Any(x => x.Id == id);
        }

        public static Course? GetCourseById(int id)
        {
            return courses.FirstOrDefault(x => x.Id == id);
        }

        public static Course? GetCourseByProperties(string? instrument, string? playerLevel)
        {
            return courses.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(x.Instrument) &&
                x.Instrument.Equals(instrument, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(x.PlayerLevel) &&
                x.PlayerLevel.Equals(playerLevel, StringComparison.OrdinalIgnoreCase));
        }

        public static void AddCourse(Course newCourse)
        {
            int maxId = courses.Max(x => x.Id);
            newCourse.Id = maxId + 1;
            courses.Add(newCourse);
        }

        public static void UpdateCourse(Course updatedCourse)
        {
            var courseToUpdate = courses.FirstOrDefault(x => x.Id == updatedCourse.Id);
            if (courseToUpdate != null)
            {
                courseToUpdate.Instrument = updatedCourse.Instrument;
                courseToUpdate.PlayerLevel = updatedCourse.PlayerLevel;
                courseToUpdate.Price = updatedCourse.Price;
            }
        }

        public static void DeleteCourse(int id)
        {
            var courseToDelete = GetCourseById(id);
            if (courseToDelete != null)
            {
                courses.Remove(courseToDelete);
            }
        }
    }
}

