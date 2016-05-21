using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnhPhatMVC.Models
{
    public class User
    {

        [Key]
        public int id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public DateTime birthday { get; set; }
        public String email { get; set; }
        public String role { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}