﻿// <auto-generated />
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

                    b.Property<bool>("TodoIsFinished")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TodoTitel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TodoID");

                    b.ToTable("Entries");

                    b.HasData(
                        new
                        {
                            TodoID = 1,
                            TodoIsFinished = false,
                            TodoTitel = "Todo Item 1"
                        },
                        new
                        {
                            TodoID = 2,
                            TodoIsFinished = false,
                            TodoTitel = "Todo Item 2"
                        },
                        new
                        {
                            TodoID = 3,
                            TodoIsFinished = false,
                            TodoTitel = "Todo Item 3"
                        },
                        new
                        {
                            TodoID = 4,
                            TodoIsFinished = false,
                            TodoTitel = "Todo Item 4"
                        },
                        new
                        {
                            TodoID = 5,
                            TodoIsFinished = false,
                            TodoTitel = "Todo Item 5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
