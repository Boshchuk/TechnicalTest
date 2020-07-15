using System;
using System.Runtime.Serialization;

namespace TechnicalTest.Models
{
    [DataContract]
    public class AnimalListItem
    {
        [DataMember]
        public Guid Id { get; set; }

        // TODO: ADD TYPE of ANIMAL )))

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string OwnerDisplayName { get; set; }
    }
}