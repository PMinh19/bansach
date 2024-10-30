﻿namespace BanSach.Components.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Img { get; set; }
        public int Status  { get; set; }
        public int RoleId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
