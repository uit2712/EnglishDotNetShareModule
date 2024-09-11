using Core.Features.Group.Entities;
using Core.Features.Topic.Entities;
using Core.Features.Vocabulary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.EnglishContext;

public interface IEnglishContext
{
    DbSet<GroupEntity> Groups { get; }
    DbSet<TopicEntity> Topics { get; }
    DbSet<VocabularyEntity> Vocabularies { get; }
    int SaveChanges();
}
