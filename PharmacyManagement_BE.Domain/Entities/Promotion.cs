﻿using PharmacyManagement_BE.Domain.Entities.Bases;
using PharmacyManagement_BE.Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement_BE.Domain.Entities
{
    public class Promotion : BaseEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public PromotionType DiscountType { get; set; }

        [Required]
        public decimal DiscountValue { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string CodePromotion { get; set; }
    }
}
