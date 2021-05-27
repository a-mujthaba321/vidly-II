﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly_II.Models;

namespace Vidly_II.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public bool isSubscribedToCustomer { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}