﻿using System;
using System.Collections.Generic;

namespace CI_platform.Entities.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Missions = new HashSet<Mission>();
            UserTables = new HashSet<UserTable>();
        }

        public long CountryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Iso { get; set; }
        public byte[] CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<UserTable> UserTables { get; set; }
    }
}
