using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Features.Topic.Entities;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace Core.Features.Vocabulary.Entities;

[Table("vocabularies")]
public class VocabularyEntity
{
    [Key]
    [JsonProperty]
    public long Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [JsonProperty]
    [StringLength(100)]
    public required string Name { get; set; }

    [JsonProperty]
    [StringLength(100)]
    public string? Pronunciation { get; set; }

    [Required(ErrorMessage = "Meaning is required")]
    [JsonProperty]
    [StringLength(100)]
    public required string Meaning { get; set; }

    [JsonProperty]
    [StringLength(300)]
    public string? Image { get; set; }

    [JsonProperty]
    [Optional]
    public int? TopicId { get; set; }
    [Optional]
    public virtual TopicEntity? Topic { get; set; }
}