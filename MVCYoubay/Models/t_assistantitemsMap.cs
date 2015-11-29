using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_assistantitemsMap : EntityTypeConfiguration<t_assistantitems>
    {
        public t_assistantitemsMap()
        {
            // Primary Key
            this.HasKey(t => t.assistantItemsId);

            // Properties
            this.Property(t => t.affirmativeAnswer)
                .HasMaxLength(200);

            this.Property(t => t.affirmativeAnswerQuery)
                .HasMaxLength(200);

            this.Property(t => t.negativeAnswer)
                .HasMaxLength(200);

            this.Property(t => t.negativeAnswerQuery)
                .HasMaxLength(200);

            this.Property(t => t.questionText)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("t_assistantitems", "pidev_youbay");
            this.Property(t => t.assistantItemsId).HasColumnName("assistantItemsId");
            this.Property(t => t.affirmativeAnswer).HasColumnName("affirmativeAnswer");
            this.Property(t => t.affirmativeAnswerQuery).HasColumnName("affirmativeAnswerQuery");
            this.Property(t => t.negativeAnswer).HasColumnName("negativeAnswer");
            this.Property(t => t.negativeAnswerQuery).HasColumnName("negativeAnswerQuery");
            this.Property(t => t.questionDisplayPriority).HasColumnName("questionDisplayPriority");
            this.Property(t => t.questionText).HasColumnName("questionText");
            this.Property(t => t.subcategory_subcategoryId).HasColumnName("subcategory_subcategoryId");

            // Relationships
            this.HasOptional(t => t.t_subcategory)
                .WithMany(t => t.t_assistantitems)
                .HasForeignKey(d => d.subcategory_subcategoryId);

        }
    }
}
