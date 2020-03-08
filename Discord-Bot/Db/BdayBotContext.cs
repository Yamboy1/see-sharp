using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Discord_Bot.Db
{
    public partial class BdayBotContext : DbContext
    {
        public virtual DbSet<Guild> Guild { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseNpgsql(Environment.GetEnvironmentVariable("DB_CONN") ?? "");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guild>(entity =>
            {
                entity.ToTable("Guild");

                entity.Property(e => e.GuildId)
                    .IsRequired();

                entity.Property(e => e.AnnouncementChannel)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                
                entity.Property(e => e.UserId)
                    .IsRequired();

                entity.Property(e => e.Birthday)
                    .IsRequired();
            });

            modelBuilder.Entity<UserGuild>()
                .HasKey(userGuild => new {userGuild.GuildId, userGuild.UserId});
            
            modelBuilder.Entity<UserGuild>()
                .HasOne(userGuild => userGuild.Guild)
                .WithMany(guild => guild.UserGuilds)
                .HasForeignKey(userGuild => userGuild.GuildId);
            
            modelBuilder.Entity<UserGuild>()
                .HasOne(userGuild => userGuild.User)
                .WithMany(user => user.UserGuilds)
                .HasForeignKey(userGuild => userGuild.UserId);
        }
    }
}
