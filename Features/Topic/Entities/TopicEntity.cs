using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Features.Group.Entities;
using Core.Features.Vocabulary.Entities;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace Core.Features.Topic.Entities;

[Table("topics")]
public class TopicEntity
{
    [Key]
    [JsonProperty]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [JsonProperty]
    [StringLength(100)]
    public required string Name { get; set; }

    [JsonProperty]
    [Optional]
    public int? GroupId { get; set; }

    [Optional]
    public virtual GroupEntity? Group { get; set; }

    [Optional]
    public virtual ICollection<VocabularyEntity>? Vocabularies { get; }
}