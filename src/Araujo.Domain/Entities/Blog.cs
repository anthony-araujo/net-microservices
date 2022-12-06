using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace araujo.Domain.Entities
{
    [Table("blog")]
    public class Blog : BaseEntity<long>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Handle { get; set; }

        // jhipster-needle-entity-add-field - JHipster will add fields here, do not remove

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            var blog = obj as Blog;
            if (blog?.Id == null || blog?.Id == 0 || Id == 0) return false;
            return EqualityComparer<long>.Default.Equals(Id, blog.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return "Blog{" +
                    $"ID='{Id}'" +
                    $", Name='{Name}'" +
                    $", Handle='{Handle}'" +
                    "}";
        }
    }
}
