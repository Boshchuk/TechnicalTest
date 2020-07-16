using System;
using System.Runtime.Serialization;

namespace TechnicalTest.Models
{
    [DataContract]
    public class Animal
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Employee Owner { get; set; }
    }
}