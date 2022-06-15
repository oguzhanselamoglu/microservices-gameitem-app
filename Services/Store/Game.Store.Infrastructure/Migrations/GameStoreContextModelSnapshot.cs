﻿// <auto-generated />
using System;
using Game.Store.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Game.Store.Infrastructure.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    partial class GameStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Game.Store.Domain.Entities.GameItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("createddate");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Developer")
                        .HasColumnType("text")
                        .HasColumnName("developer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modifiedby");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modifieddate");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("Publisher")
                        .HasColumnType("text")
                        .HasColumnName("publisher");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("releasedate");

                    b.HasKey("Id")
                        .HasName("pk_gameitems");

                    b.ToTable("gameitems");
                });
#pragma warning restore 612, 618
        }
    }
}
