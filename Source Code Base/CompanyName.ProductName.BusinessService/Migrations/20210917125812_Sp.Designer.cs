﻿// <auto-generated />
using System;
using AspireSystems.TakeYourJob.BusinessService.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspireSystems.TakeYourJob.BusinessService.Migrations
{
    [DbContext(typeof(Dbcontext))]
    [Migration("20210917125812_Sp")]
    partial class Sp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.AppliedCandidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CandidateId");

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<string>("Gender");

                    b.Property<Guid>("JobId");

                    b.Property<string>("JobRole");

                    b.Property<string>("Name");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("JobId");

                    b.ToTable("AppliedCandidate");
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<string>("City");

                    b.Property<string>("CollegeName");

                    b.Property<string>("CollegeType");

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Course");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("EmploymentType");

                    b.Property<int>("Experience");

                    b.Property<string>("Gender");

                    b.Property<string>("HSCBoard");

                    b.Property<string>("HSCMedium");

                    b.Property<int>("HSCPassingYear");

                    b.Property<int>("HSCPercentage");

                    b.Property<string>("HSCSpecialization");

                    b.Property<string>("JobType");

                    b.Property<string>("Location");

                    b.Property<long>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<int>("PassingYear");

                    b.Property<string>("Password");

                    b.Property<string>("ProfessionalBackground");

                    b.Property<string>("Qualification");

                    b.Property<string>("Question");

                    b.Property<Guid>("RoleId");

                    b.Property<string>("SSLCBoard");

                    b.Property<string>("SSLCMedium");

                    b.Property<int>("SSLCPassingYear");

                    b.Property<int>("SSLCPercentage");

                    b.Property<string>("Skills");

                    b.Property<string>("Specialization");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<int>("Experience");

                    b.Property<int>("HSCPercenatge");

                    b.Property<string>("Location");

                    b.Property<string>("Qualification");

                    b.Property<Guid>("RecruiterId");

                    b.Property<string>("Role");

                    b.Property<int>("SSLCPercentage");

                    b.Property<int>("Salary");

                    b.Property<string>("Skills");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<Guid>("RoleId");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Recruiter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyAddress");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompanyType");

                    b.Property<string>("ConfirmPassword");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<string>("Email");

                    b.Property<long>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<long>("Pincode");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.ToTable("Recruiter");
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedByUserId");

                    b.Property<string>("RoleName");

                    b.Property<bool>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.AppliedCandidate", b =>
                {
                    b.HasOne("AspireSystems.TakeYourJob.BusinessService.Models.Candidate", "CandidateDetails")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspireSystems.TakeYourJob.BusinessService.Models.Job", "JobDetails")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Candidate", b =>
                {
                    b.HasOne("AspireSystems.TakeYourJob.BusinessService.Models.Role", "RoleDetails")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Job", b =>
                {
                    b.HasOne("AspireSystems.TakeYourJob.BusinessService.Models.Recruiter", "UserId")
                        .WithMany()
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspireSystems.TakeYourJob.BusinessService.Models.Login", b =>
                {
                    b.HasOne("AspireSystems.TakeYourJob.BusinessService.Models.Role", "RoleDetails")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
