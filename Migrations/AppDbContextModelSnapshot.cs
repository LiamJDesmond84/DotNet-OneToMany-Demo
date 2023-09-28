﻿// <auto-generated />
using System;
using DotNet_OneToMany_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNet_OneToMany_Demo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sport")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.PlayerTeam", b =>
                {
                    b.Property<int>("PlayerTeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerTeamId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerTeams");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.Player", b =>
                {
                    b.HasOne("DotNet_OneToMany_Demo.Models.Team", "CurrentTeam")
                        .WithMany("CurrentPlayers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTeam");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.PlayerTeam", b =>
                {
                    b.HasOne("DotNet_OneToMany_Demo.Models.Player", "PlayerOnTeam")
                        .WithMany("AllTeams")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNet_OneToMany_Demo.Models.Team", "TeamOfPlayer")
                        .WithMany("AllPlayers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerOnTeam");

                    b.Navigation("TeamOfPlayer");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.Team", b =>
                {
                    b.HasOne("DotNet_OneToMany_Demo.Models.League", "CurrLeague")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrLeague");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.Player", b =>
                {
                    b.Navigation("AllTeams");
                });

            modelBuilder.Entity("DotNet_OneToMany_Demo.Models.Team", b =>
                {
                    b.Navigation("AllPlayers");

                    b.Navigation("CurrentPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
