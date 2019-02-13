﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public class UserDTO: BaseDTO
    {
        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public DateTime LastLoginTime { get; set; }

        [DataMember]
        public bool IsEnable { get; set; }

        [DataMember]
        public ICollection<UserRoleDTO> UserRolesDto { get; set; }

        [DataMember]
        public DepartDTO DepartDto { get; set; }
    }
}
