﻿using System;

namespace Tennis.DAL.Models
{
    public class MemberRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
