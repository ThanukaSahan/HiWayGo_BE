using System;

namespace HiwayGo_API.Mapper
{
    public sealed class UserRoleDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}