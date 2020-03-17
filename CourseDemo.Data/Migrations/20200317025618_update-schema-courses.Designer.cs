﻿// <auto-generated />
using System;
using CourseDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseDemo.Data.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20200317025618_update-schema-courses")]
    partial class updateschemacourses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseDemo.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BeginSequence")
                        .HasColumnType("int");

                    b.Property<int?>("BeginYear")
                        .HasColumnType("int");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseLevelId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseTypeId")
                        .HasColumnType("int");

                    b.Property<bool?>("CreditAdvancementAvailable")
                        .HasColumnType("bit");

                    b.Property<bool?>("CreditRecoveryAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("CreditTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CreditUnits")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EndSequence")
                        .HasColumnType("int");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<int?>("HighGradeId")
                        .HasColumnType("int");

                    b.Property<int?>("LowGradeId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectAreaId")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseLevelId");

                    b.HasIndex("CourseTypeId");

                    b.HasIndex("HighGradeId");

                    b.HasIndex("LowGradeId");

                    b.ToTable("Courses","Common");
                });

            modelBuilder.Entity("CourseDemo.Domain.CourseLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseLevelCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourseLevels","Common");
                });

            modelBuilder.Entity("CourseDemo.Domain.CourseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseTypeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCore")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourseTypes","Common");
                });

            modelBuilder.Entity("CourseDemo.Domain.DeliveryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTypes","Common");
                });

            modelBuilder.Entity("CourseDemo.Domain.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grades","Common");
                });

            modelBuilder.Entity("CourseDemo.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags","Common");
                });

            modelBuilder.Entity("CourseDemo.Domain.Course", b =>
                {
                    b.HasOne("CourseDemo.Domain.CourseLevel", "CourseLevel")
                        .WithMany()
                        .HasForeignKey("CourseLevelId");

                    b.HasOne("CourseDemo.Domain.CourseType", "CourseType")
                        .WithMany()
                        .HasForeignKey("CourseTypeId");

                    b.HasOne("CourseDemo.Domain.Grade", "HighGrade")
                        .WithMany()
                        .HasForeignKey("HighGradeId");

                    b.HasOne("CourseDemo.Domain.Grade", "LowGrade")
                        .WithMany()
                        .HasForeignKey("LowGradeId");
                });
#pragma warning restore 612, 618
        }
    }
}
