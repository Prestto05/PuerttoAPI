using Core.Puertto.DTOs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.General
{
    public class PersonEntity : EntityWithAudit<Guid>
    {
        public string? NanmeFirst { get; set; }

        public string? NameSecond { get; set; }

        public string? SureName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public int IdGener { get; set; }

        public DateTime BirthDate { get; set; }

        public string?  Address { get; set; }

        public string? AddressOptional { get; set; }

        public int? IdTypeIdentification { get; set; }

        public string? Identification { get; set; }

        public string? BusinessName { get; set; }

        public int? Phone { get; set; }

        public int? IdNationality { get; set; }

        public string? ProfilePhoto { get; set; }

        public StatePerson State { get; set; }

    }

    public enum StatePerson
    {
        Active = 0,
        Inactive = 1,
    }
}
