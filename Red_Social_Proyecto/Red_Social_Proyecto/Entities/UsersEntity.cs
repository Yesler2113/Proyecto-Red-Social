using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Red_Social_Proyecto.Entities
{
    [Table("users", Schema = "security")]
    public class UsersEntity : IdentityUser
    {
        // Campos heredados de IdentityUser
        [Column("email")]
        public override string Email { get; set; }

        [Column("normalized_email")]
        public override string NormalizedEmail { get; set; }

        [Column("password_hash")]
        public override string PasswordHash { get; set; }

        [Column("user_name")]
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        [Column("photo_url")]
        [MaxLength(300)]
        public string PhotoUrl { get; set; }

        [Column("biography")]
        [MaxLength(300)]
        public string Biography { get; set; }

        [Column("links")]
        [MaxLength(300)]
        public string SocialMediaLinks { get; set; }

        
    }
}

