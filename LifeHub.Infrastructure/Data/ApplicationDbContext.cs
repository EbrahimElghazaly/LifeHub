using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LifeHub.Core.Entities;
using TaskEntity = LifeHub.Core.Entities.Task;

namespace LifeHub.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<TaskReminder> TaskReminders { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalMilestone> GoalMilestones { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitLog> HabitLogs { get; set; }
        public DbSet<StudySession> StudySessions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LearningPath> LearningPaths { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<QuranProgress> QuranProgress { get; set; }
        public DbSet<AzkarLog> AzkarLogs { get; set; }
        public DbSet<AzkarItem> AzkarItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Task - User Relationship
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Task - Category Relationship
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Task - Parent Task (Self Reference)
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.ParentTask)
                .WithMany(t => t.Subtasks)
                .HasForeignKey(t => t.ParentTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            // TaskReminder - Task Relationship
            modelBuilder.Entity<TaskReminder>()
                .HasOne(r => r.Task)
                .WithMany(t => t.Reminders)
                .HasForeignKey(r => r.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            // Goal - User Relationship
            modelBuilder.Entity<Goal>()
                .HasOne(g => g.User)
                .WithMany(u => u.Goals)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // GoalMilestone - Goal Relationship
            modelBuilder.Entity<GoalMilestone>()
                .HasOne(m => m.Goal)
                .WithMany(g => g.Milestones)
                .HasForeignKey(m => m.GoalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Habit - User Relationship
            modelBuilder.Entity<Habit>()
                .HasOne(h => h.User)
                .WithMany(u => u.Habits)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // HabitLog - Habit Relationship
            modelBuilder.Entity<HabitLog>()
                .HasOne(l => l.Habit)
                .WithMany(h => h.Logs)
                .HasForeignKey(l => l.HabitId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudySession - User Relationship
            modelBuilder.Entity<StudySession>()
                .HasOne(s => s.User)
                .WithMany(u => u.StudySessions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudySession - Course Relationship
            modelBuilder.Entity<StudySession>()
                .HasOne(s => s.Course)
                .WithMany(c => c.StudySessions)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            // Course - User Relationship
            modelBuilder.Entity<Course>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Course - LearningPath Relationship
            modelBuilder.Entity<Course>()
                .HasOne(c => c.LearningPath)
                .WithMany(l => l.Courses)
                .HasForeignKey(c => c.LearningPathId)
                .OnDelete(DeleteBehavior.SetNull);

            // LearningPath - User Relationship
            modelBuilder.Entity<LearningPath>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // JournalEntry - User Relationship
            modelBuilder.Entity<JournalEntry>()
                .HasOne(j => j.User)
                .WithMany(u => u.JournalEntries)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Note - User Relationship
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // QuranProgress - User Relationship
            modelBuilder.Entity<QuranProgress>()
                .HasOne(q => q.User)
                .WithMany(u => u.QuranProgress)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AzkarLog - User Relationship
            modelBuilder.Entity<AzkarLog>()
                .HasOne(a => a.User)
                .WithMany(u => u.AzkarLogs)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes for performance
            modelBuilder.Entity<TaskEntity>()
                .HasIndex(t => t.UserId);

            modelBuilder.Entity<TaskEntity>()
                .HasIndex(t => t.Status);

            modelBuilder.Entity<TaskEntity>()
                .HasIndex(t => t.DueDate);

            modelBuilder.Entity<Goal>()
                .HasIndex(g => g.UserId);

            modelBuilder.Entity<Habit>()
                .HasIndex(h => h.UserId);

            modelBuilder.Entity<StudySession>()
                .HasIndex(s => s.UserId);

            modelBuilder.Entity<StudySession>()
                .HasIndex(s => s.StartTime);
        }
    }
}