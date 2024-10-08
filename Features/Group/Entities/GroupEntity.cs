using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Features.Topic.Entities;
using Newtonsoft.Json;

namespace Core.Features.Group.Entities;

[Table("groups")]
public class GroupEntity
{
    [Key]
    [JsonProperty]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [JsonProperty]
    [StringLength(100)]
    public required string Name { get; set; }
    public ICollection<TopicEntity>? Topics { get; }
}