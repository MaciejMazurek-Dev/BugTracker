﻿// <auto-generated />
using System;
using BugTracker.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BugTracker.Persistence.Migrations
{
    [DbContext(typeof(BTDatabaseContext))]
    [Migration("20241115125825_RefactorIssueTable")]
    partial class RefactorIssueTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BugTracker.Domain.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssigneeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("IssuePriorityId")
                        .HasColumnType("int");

                    b.Property<int>("IssueStatusId")
                        .HasColumnType("int");

                    b.Property<int>("IssueTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ReporterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssuePriorityId");

                    b.HasIndex("IssueStatusId");

                    b.HasIndex("IssueTypeId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("BugTracker.Domain.IssuePriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("IssuePriorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7137),
                            DateModified = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7187),
                            Name = "Low"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7276),
                            DateModified = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7278),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7281),
                            DateModified = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7283),
                            Name = "High"
                        },
                        new
                        {
                            Id = 4,
                            DateCreated = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7286),
                            DateModified = new DateTime(2024, 11, 15, 13, 58, 24, 460, DateTimeKind.Local).AddTicks(7288),
                            Name = "Critical"
                        });
                });

            modelBuilder.Entity("BugTracker.Domain.IssueStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("IssueStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Assigned"
                        },
                        new
                        {
                            Id = 3,
                            Name = "In progress"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Resolved"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Closed"
                        });
                });

            modelBuilder.Entity("BugTracker.Domain.IssueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("IssueTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bug"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Defect"
                        },
                        new
                        {
                            Id = 3,
                            Name = "New feature"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Task"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Improvement"
                        });
                });

            modelBuilder.Entity("BugTracker.Domain.Issue", b =>
                {
                    b.HasOne("BugTracker.Domain.IssuePriority", "IssuePriority")
                        .WithMany()
                        .HasForeignKey("IssuePriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Domain.IssueStatus", "IssueStatus")
                        .WithMany()
                        .HasForeignKey("IssueStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Domain.IssueType", "IssueType")
                        .WithMany()
                        .HasForeignKey("IssueTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IssuePriority");

                    b.Navigation("IssueStatus");

                    b.Navigation("IssueType");
                });
#pragma warning restore 612, 618
        }
    }
}
