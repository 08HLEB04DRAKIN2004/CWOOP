﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace OOP
{
	public class ProjectRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int role_id { get; set; }
      
    [Required]
    public string name { get; set; }
}
}