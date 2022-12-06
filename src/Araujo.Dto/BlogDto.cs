using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace araujo.Dto
{

    public class BlogDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Handle { get; set; }

        // jhipster-needle-dto-add-field - JHipster will add fields here, do not remove
    }
}
