using System.ComponentModel.DataAnnotations;

namespace PracticandoMVC.Models
{
    public enum TypeList
    {
        Leonardo,
        Liliana,
        Luciana,
        Linda,
        Laura,
    }
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        public TypeList List { get; set; }
        [Required]
        public string Email { get; set; }
        [Display]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public int Birthdate { get; set; }
    }
}