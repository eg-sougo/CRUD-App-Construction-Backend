using ConstructionBackend1._0.Data;
using ConstructionBackend1._0.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionBackend1._0.Seeders
{
    public class DataSeeder
    {
        public static async Task SeedAsync(ConstructionDbContext context)
        {
            await context.Database.MigrateAsync();

            // --------------------
            // 1️⃣ SEED USERS
            // --------------------
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        FullName = "Souvik Goswami",
                        Email = "sougo@eg.dk",
                        Role = "Engineer",
                        PhoneNumber = "9234567819"
                    },
                    new User
                    {
                        FullName = "Aryan Singh",
                        Email = "asingh@eg.dk",
                        Role = "Engineer",
                        PhoneNumber = "9145612456"
                    },
                    new User
                    {
                        FullName = "Ayush Sinha",
                        Email = "aysin@eg.dk",
                        Role = "Engineer",
                        PhoneNumber = "9876543221"
                    },
                    new User
                    {
                        FullName = "Anish J Babu",
                        Email = "aniba@eg.dk",
                        Role = "Engineer",
                        PhoneNumber = "9876562781"
                    },
                    new User
                    {
                        FullName = "Ayush Prabhu",
                        Email = "aypra@eg.dk",
                        Role = "Engineer",
                        PhoneNumber = "9876272781"
                    }
                );

                await context.SaveChangesAsync();
            }

            var engineers = await context.Users.ToListAsync();

            // --------------------
            // 2️⃣ SEED PROJECTS
            // --------------------
            if (!context.Projects.Any())
            {
                var projects = new List<Project>
                {
                    new Project
                    {
                        ProjectName = "Bridge Construction",
                        Description = "City main bridge",
                        Status = "Planned",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMonths(6),
                        CreatorID = engineers[0].UserId
                    },
                    new Project
                    {
                        ProjectName = "Metro Line Expansion",
                        Description = "New metro corridor",
                        Status = "Planned",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMonths(8),
                        CreatorID = engineers[1].UserId
                    },
                    new Project
                    {
                        ProjectName = "IT Park Development",
                        Description = "Corporate offices construction",
                        Status = "Planned",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMonths(10),
                        CreatorID = engineers[2].UserId
                    },
                    new Project
                    {
                        ProjectName = "Highway Renovation",
                        Description = "Highway widening project",
                        Status = "Planned",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMonths(7),
                        CreatorID = engineers[3].UserId
                    },
                    new Project
                    {
                        ProjectName = "Hospital Construction",
                        Description = "New multi-specialty hospital",
                        Status = "Planned",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMonths(12),
                        CreatorID = engineers[4].UserId
                    }
                };

                context.Projects.AddRange(projects);
                await context.SaveChangesAsync();
            }

            var projectsFromDb = await context.Projects.ToListAsync();

            // --------------------
            // 3️⃣ SEED TASKS (2 per project)
            // --------------------
            if (!context.Tasks.Any())
            {
                var tasks = new List<TaskItem>();

                foreach (var project in projectsFromDb)
                {
                    tasks.AddRange(new[]
                    {
                        new TaskItem
                        {
                            TaskName = "Planning & Design",
                            Description = "Initial planning and design phase",
                            Status = "Planned",
                            StartDate = DateTime.UtcNow,
                            DueDate = DateTime.UtcNow.AddMonths(1),
                            ProjectId = project.ProjectId,
                            AssignedTo = engineers[0].UserId
                        },
                        new TaskItem
                        {
                            TaskName = "Execution Phase",
                            Description = "Main construction execution",
                            Status = "Planned",
                            StartDate = DateTime.UtcNow.AddMonths(1),
                            DueDate = DateTime.UtcNow.AddMonths(3),
                            ProjectId = project.ProjectId,
                            AssignedTo = engineers[1].UserId
                        }
                    });
                }

                context.Tasks.AddRange(tasks);
                await context.SaveChangesAsync();
            }
        }
    }
}
