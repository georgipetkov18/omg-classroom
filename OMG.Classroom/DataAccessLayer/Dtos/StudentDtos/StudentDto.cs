﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos.StudentDtos
{
    public class StudentDto
    {
        public DateTime? DeletedOn { get; set; }
        public Guid RoleId { get; set; }
    }
}
