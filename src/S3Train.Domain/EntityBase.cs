﻿using System;
using System.ComponentModel.DataAnnotations;

namespace S3Train.Domain
{
    /// <summary>
    /// Base class for database domain entity
    /// </summary>
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}