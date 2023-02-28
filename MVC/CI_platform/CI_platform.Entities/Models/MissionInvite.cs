using System;
using System.Collections.Generic;

namespace CI_platform.Entities.Models
{
    public partial class MissionInvite
    {
        public long MissionInviteId { get; set; }
        public long MissionId { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public byte[] CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual UserTable FromUser { get; set; } = null!;
        public virtual Mission Mission { get; set; } = null!;
        public virtual UserTable ToUser { get; set; } = null!;
    }
}
