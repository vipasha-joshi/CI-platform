﻿using System;
using System.Collections.Generic;

namespace CI_platform.Entities.Models
{
    public partial class Admin
    {
        public long AdminId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[] CreatedAt { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
