using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required][Newtonsoft.Json.JsonIgnore][JsonIgnore]
        public string LoginId { get; set; }
        [Required]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonIgnore][JsonIgnore][IgnoreMap][Ignore]
        public ICollection<Book> Books { get; set; }
        [Newtonsoft.Json.JsonIgnore][JsonIgnore][IgnoreMap][Ignore]
        public ICollection<Transaction> Transactions { get; set; }
    }
}