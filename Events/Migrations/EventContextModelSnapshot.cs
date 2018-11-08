﻿// <auto-generated />
using System;
using Events.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Events.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:Sequence:.event_id_hilo", "'event_id_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Events.Domain.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cost");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("EventName")
                        .IsRequired();

                    b.Property<int>("EventTypeId");

                    b.Property<int>("HostId");

                    b.Property<string>("PictureUrl");

                    b.Property<int>("VenueId");

                    b.HasKey("EventId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("HostId");

                    b.HasIndex("VenueId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Events.Domain.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventTypeName")
                        .IsRequired();

                    b.HasKey("EventTypeId");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("Events.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Events.Domain.UserEvent", b =>
                {
                    b.Property<int>("UserEventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("GuestId");

                    b.HasKey("UserEventId");

                    b.HasIndex("EventId");

                    b.HasIndex("GuestId");

                    b.ToTable("UserEvent");
                });

            modelBuilder.Entity("Events.Domain.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("MaxCapacity");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("VenueName")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("VenueId");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Events.Domain.Event", b =>
                {
                    b.HasOne("Events.Domain.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Events.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Events.Domain.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Events.Domain.UserEvent", b =>
                {
                    b.HasOne("Events.Domain.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Events.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}