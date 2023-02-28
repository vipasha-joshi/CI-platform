using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CI_platform.Entities.Models;

namespace CI_platform.Entities.Data
{
    public partial class CI_PlatformContext : DbContext
    {
        public CI_PlatformContext()
        {
        }

        public CI_PlatformContext(DbContextOptions<CI_PlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CmsPage> CmsPages { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<FavoriteMission> FavoriteMissions { get; set; } = null!;
        public virtual DbSet<GoalMission> GoalMissions { get; set; } = null!;
        public virtual DbSet<Mission> Missions { get; set; } = null!;
        public virtual DbSet<MissionApplication> MissionApplications { get; set; } = null!;
        public virtual DbSet<MissionDocument> MissionDocuments { get; set; } = null!;
        public virtual DbSet<MissionInvite> MissionInvites { get; set; } = null!;
        public virtual DbSet<MissionMedium> MissionMedia { get; set; } = null!;
        public virtual DbSet<MissionRating> MissionRatings { get; set; } = null!;
        public virtual DbSet<MissionSkill> MissionSkills { get; set; } = null!;
        public virtual DbSet<MissionTheme> MissionThemes { get; set; } = null!;
        public virtual DbSet<PasswordReset> PasswordResets { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Story> Stories { get; set; } = null!;
        public virtual DbSet<StoryInvite> StoryInvites { get; set; } = null!;
        public virtual DbSet<StoryMedium> StoryMedia { get; set; } = null!;
        public virtual DbSet<Timesheet> Timesheets { get; set; } = null!;
        public virtual DbSet<UserSkill> UserSkills { get; set; } = null!;
        public virtual DbSet<UserTable> UserTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-H765FCE8;Database=CI_Platform;Encrypt=False;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("admin_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("banner");

                entity.Property(e => e.BannerId)
                    .ValueGeneratedNever()
                    .HasColumnName("banner_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Image)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sort_order")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__city__country_id__403A8C7D");
            });

            modelBuilder.Entity<CmsPage>(entity =>
            {
                entity.ToTable("cms_page");

                entity.Property(e => e.CmsPageId)
                    .ValueGeneratedNever()
                    .HasColumnName("cms_page_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Slug)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("slug");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("comment_id");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approval_status");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment__mission__41EDCAC5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment__user_id__40F9A68C");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Iso)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("ISO");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<FavoriteMission>(entity =>
            {
                entity.ToTable("favorite_mission");

                entity.Property(e => e.FavoriteMissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("favorite_mission_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.FavoriteMissions)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favorite___missi__0A9D95DB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteMissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__favorite___user___09A971A2");
            });

            modelBuilder.Entity<GoalMission>(entity =>
            {
                entity.ToTable("goal_mission");

                entity.Property(e => e.GoalMissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("goal_mission_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.GoalObjectiveText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("goal_objective_text");

                entity.Property(e => e.GoalValue).HasColumnName("goal_value");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.GoalMissions)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__goal_miss__missi__00200768");
            });

            modelBuilder.Entity<Mission>(entity =>
            {
                entity.ToTable("mission");

                entity.Property(e => e.MissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_id");

                entity.Property(e => e.Availability)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("availability");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.MissionThemeId).HasColumnName("mission_theme_id");

                entity.Property(e => e.MissionType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mission_type");

                entity.Property(e => e.OrganizationDetail)
                    .HasColumnType("text")
                    .HasColumnName("organization_detail");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("organization_name");

                entity.Property(e => e.ShortDescription)
                    .HasColumnType("text")
                    .HasColumnName("short_description");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission__city_id__6477ECF3");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission__country__656C112C");

                entity.HasOne(d => d.MissionTheme)
                    .WithMany(p => p.Missions)
                    .HasForeignKey(d => d.MissionThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission__mission__6383C8BA");
            });

            modelBuilder.Entity<MissionApplication>(entity =>
            {
                entity.ToTable("mission_application");

                entity.Property(e => e.MissionApplicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_application_id");

                entity.Property(e => e.AppliedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("applied_at");

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("approval_status")
                    .HasDefaultValueSql("('PENDING')");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionApplications)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_a__missi__0F624AF8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MissionApplications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_a__user___10566F31");
            });

            modelBuilder.Entity<MissionDocument>(entity =>
            {
                entity.ToTable("mission_document");

                entity.Property(e => e.MissionDocumentId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_document_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_name");

                entity.Property(e => e.DocumentPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_path");

                entity.Property(e => e.DocumentType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("document_type");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionDocuments)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_d__missi__6FE99F9F");
            });

            modelBuilder.Entity<MissionInvite>(entity =>
            {
                entity.ToTable("mission_invite");

                entity.Property(e => e.MissionInviteId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_invite_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.MissionInviteFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_i__from___1AD3FDA4");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionInvites)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_i__missi__19DFD96B");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.MissionInviteToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_i__to_us__1BC821DD");
            });

            modelBuilder.Entity<MissionMedium>(entity =>
            {
                entity.HasKey(e => e.MissionMediaId)
                    .HasName("PK__mission___848A78E8B306FF9D");

                entity.ToTable("mission_media");

                entity.Property(e => e.MissionMediaId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_media_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MediaName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("media_name");

                entity.Property(e => e.MediaPath)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("media_path");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("media_type");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionMedia)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_m__missi__74AE54BC");
            });

            modelBuilder.Entity<MissionRating>(entity =>
            {
                entity.ToTable("mission_rating");

                entity.Property(e => e.MissionRatingId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_rating_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionRatings)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_r__missi__2180FB33");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MissionRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_r__user___208CD6FA");
            });

            modelBuilder.Entity<MissionSkill>(entity =>
            {
                entity.ToTable("mission_skill");

                entity.Property(e => e.MissionSkillId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_skill_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.MissionSkills)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_s__missi__47A6A41B");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.MissionSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mission_s__skill__46B27FE2");
            });

            modelBuilder.Entity<MissionTheme>(entity =>
            {
                entity.ToTable("mission_theme");

                entity.Property(e => e.MissionThemeId)
                    .ValueGeneratedNever()
                    .HasColumnName("mission_theme_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_reset");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Token)
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.SkillId)
                    .ValueGeneratedNever()
                    .HasColumnName("skill_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("skill_name");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Story>(entity =>
            {
                entity.ToTable("story");

                entity.Property(e => e.StoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("story_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("published_at");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('DRAFT')");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Stories)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story__mission_i__2739D489");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Stories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story__user_id__2645B050");
            });

            modelBuilder.Entity<StoryInvite>(entity =>
            {
                entity.ToTable("story_invite");

                entity.Property(e => e.StoryInviteId)
                    .ValueGeneratedNever()
                    .HasColumnName("story_invite_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<StoryMedium>(entity =>
            {
                entity.HasKey(e => e.StoryMediaId)
                    .HasName("PK__story_me__29BD053C22E01648");

                entity.ToTable("story_media");

                entity.Property(e => e.StoryMediaId)
                    .ValueGeneratedNever()
                    .HasColumnName("story_media_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Path)
                    .HasColumnType("text")
                    .HasColumnName("path");

                entity.Property(e => e.StoryId).HasColumnName("story_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.StoryMedia)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_med__story__2FCF1A8A");
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("timesheet");

                entity.Property(e => e.TimesheetId)
                    .ValueGeneratedNever()
                    .HasColumnName("timesheet_id");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DateVolunteered)
                    .HasColumnType("datetime")
                    .HasColumnName("date_volunteered");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.MissionId).HasColumnName("mission_id");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('PENDING')");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Mission)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.MissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__timesheet__missi__3587F3E0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__timesheet__user___3493CFA7");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.ToTable("user_skill");

                entity.Property(e => e.UserSkillId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_skill_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_skil__skill__3C34F16F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_skil__user___3B40CD36");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__user_tab__B9BE370FB2632B5E");

                entity.ToTable("user_table");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.Department)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("employee_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.LinkedInUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("linked_in_url");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.ProfileText)
                    .HasColumnType("text")
                    .HasColumnName("profile_text");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.WhyIVolunteer)
                    .HasColumnType("text")
                    .HasColumnName("why_i_volunteer");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_tabl__city___4AB81AF0");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_tabl__count__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
