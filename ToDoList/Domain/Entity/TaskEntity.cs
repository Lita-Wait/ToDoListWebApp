using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Entity
{
    public class TaskEntity
    {
        [Key]
        [Required]
        public long ID { get; set; }

        [Required(ErrorMessage ="Название обязательно")]
        [MaxLength(50,ErrorMessage ="Максимальная длина 50 символов")]
        [Display(Name = "Название задачи")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Описание обязательно")]
        [MaxLength(200, ErrorMessage = "Максимальная длина 200 символов")]
        [Display(Name = "Описание задачи")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Приоритет задачи")]
        public Priority Priority { get; set; }

    }
}
