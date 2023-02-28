﻿using System;
using System.Collections.Generic;

namespace CI_platform.Entities.Models
{
    public partial class FavoriteMission
    {
        public long FavoriteMissionId { get; set; }
        public long UserId { get; set; }
        public long MissionId { get; set; }
        public byte[] CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Mission Mission { get; set; } = null!;
        public virtual UserTable User { get; set; } = null!;
    }
}
