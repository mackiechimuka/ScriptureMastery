﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScriptureMastery.Data;

#nullable disable

namespace ScriptureMastery.Migrations
{
    [DbContext(typeof(ScriptureMasteryContext))]
    partial class ScriptureMasteryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScriptureMastery.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ScriptureMastery.Models.Scripture", b =>
                {
                    b.Property<int>("ScriptureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScriptureId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Chapter")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Verses")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ScriptureId");

                    b.HasIndex("BookId");

                    b.ToTable("Scripture");
                });

            modelBuilder.Entity("ScriptureMastery.Models.Scripture", b =>
                {
                    b.HasOne("ScriptureMastery.Models.Book", "Books")
                        .WithMany("Scriptures")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");
                });

            modelBuilder.Entity("ScriptureMastery.Models.Book", b =>
                {
                    b.Navigation("Scriptures");
                });
#pragma warning restore 612, 618
        }
    }
}
