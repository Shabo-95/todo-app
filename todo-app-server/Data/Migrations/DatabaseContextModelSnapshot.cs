﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todo_app_server.Data;

#nullable disable

namespace todo_app_server.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("todo_app_server.Data.Entry", b =>
                {
                    b.Property<int>("TodoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("TodoDeadline")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TodoIsFinished")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TodoTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TodoID");

                    b.ToTable("Entries");

                    b.HasData(
                        new
                        {
                            TodoID = 1,
                            TodoDeadline = new DateOnly(2022, 7, 21),
                            TodoIsFinished = false,
                            TodoTitle = "Todo Item 1"
                        },
                        new
                        {
                            TodoID = 2,
                            TodoDeadline = new DateOnly(2022, 7, 21),
                            TodoIsFinished = false,
                            TodoTitle = "Todo Item 2"
                        },
                        new
                        {
                            TodoID = 3,
                            TodoDeadline = new DateOnly(2022, 7, 21),
                            TodoIsFinished = false,
                            TodoTitle = "Todo Item 3"
                        },
                        new
                        {
                            TodoID = 4,
                            TodoDeadline = new DateOnly(2022, 7, 21),
                            TodoIsFinished = false,
                            TodoTitle = "Todo Item 4"
                        },
                        new
                        {
                            TodoID = 5,
                            TodoDeadline = new DateOnly(2022, 7, 21),
                            TodoIsFinished = false,
                            TodoTitle = "Todo Item 5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
