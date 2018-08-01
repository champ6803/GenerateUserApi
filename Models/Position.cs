using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeInsertApi.Models
{
    public class Computer
    {
        
        public int id { get; set; }
        public string computer_lang_name { get; set; }
        public string created_by { get; set; }
        public DateTime created_at {get; set;}
        public string updated_by { get; set; }
        public DateTime updated_at {get; set;}
        
    }
}
  