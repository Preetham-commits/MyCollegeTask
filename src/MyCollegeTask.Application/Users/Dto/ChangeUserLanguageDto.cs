using System.ComponentModel.DataAnnotations;

namespace MyCollegeTask.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}