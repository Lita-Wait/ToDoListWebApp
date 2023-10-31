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
        [StringLength(50)]
        [Display(Name = "Название задачи")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Описание обязательно")]
        [StringLength(200)]
        [Display(Name = "Описание задачи")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Приоритет задачи")]
        public Priority Priority { get; set; }

    }
}
