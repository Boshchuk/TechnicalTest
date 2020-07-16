using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TechnicalTest.Models
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public bool IsMediaInteractivaEmployee { get; set; }

        [DataMember]
        public List<Animal> Animals { get; set; }
    }
}