using Core.Features.Group.Entities;
using Core.Features.Topic.Entities;
using Core.Features.Vocabulary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.EnglishContext;

public class EnglishContext : DbContext, IEnglishContext
{
    public EnglishContext(DbContextOptions<EnglishContext> options)
        : base(options)
    {

    }

    public DbSet<VocabularyEntity> Vocabularies { get; set; } = null!;
    public DbSet<TopicEntity> Topics { get; set; } = null!;
    public DbSet<GroupEntity> Groups { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateTableGroup(modelBuilder);
        CreateTableTopic(modelBuilder);
        CreateTableVocabulary(modelBuilder);
    }

    private void CreateTableGroup(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupEntity>()
                    .Property(e => e.Id)
                    .ValueGeneratedOnAdd();

        modelBuilder.Entity<GroupEntity>()
            .HasMany(e => e.Topics)
            .WithOne(e => e.Group)
            .HasForeignKey(e => e.GroupId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private void CreateTableTopic(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TopicEntity>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<TopicEntity>()
            .HasMany(e => e.Vocabularies)
            .WithOne(e => e.Topic)
            .HasForeignKey(e => e.TopicId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private void CreateTableVocabulary(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VocabularyEntity>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}