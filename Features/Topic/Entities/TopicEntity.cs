using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Features.Group.Entities;
using Core.Features.Vocabulary.Entities;
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

    [Required(ErrorMessage = "Group Id is required")]
    [JsonProperty]
    public int GroupId { get; set; }
    public GroupEntity? Group { get; set; }

    public ICollection<VocabularyEntity>? Vocabularies { get; }
}