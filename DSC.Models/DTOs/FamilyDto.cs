﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class FamilyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Relation Relation { get; set; }
        public Status Status { get; set; }
        public string Job { get; set; }
        public decimal Income { get; set; }
        public bool IsAlive { get; set; }
        public bool isDisability { get; set; }
        public string SSNImgUrl { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public IEnumerable<Family> Families { get; set; }
        public Relation[] Relations { get; set; } = Enum.GetValues<Relation>();
        public Status[] Statues { get; set; } = Enum.GetValues<Status>();

    }
}
