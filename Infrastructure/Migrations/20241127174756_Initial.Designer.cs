﻿// <auto-generated />
using System;
using Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DrugStoreDbContext))]
    [Migration("20241127174756_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasAnnotation("Comment", "Идентификатор");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("code")
                        .HasAnnotation("Comment", "Код страны");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name")
                        .HasAnnotation("Comment", "Название");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Drug", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasAnnotation("Comment", "Идентификатор");

                    b.Property<string>("CountryCodeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country_code_id")
                        .HasAnnotation("Comment", "Код страны - страна изготовитель");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("manufacturer")
                        .HasAnnotation("Comment", "Изготовитель");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("name")
                        .HasAnnotation("Comment", "Название");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Drug", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DrugItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasAnnotation("Comment", "Идентификатор");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount")
                        .HasAnnotation("Comment", "Кол-во");

                    b.Property<Guid>("DrugId")
                        .HasColumnType("uuid")
                        .HasColumnName("drug_id")
                        .HasAnnotation("Comment", "Идентификатор лекарства");

                    b.Property<Guid?>("DrugId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DrugStoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("drugstore_id")
                        .HasAnnotation("Comment", "Навигационное поле для DrugStore");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price")
                        .HasAnnotation("Comment", "Цена");

                    b.HasKey("Id");

                    b.HasIndex("DrugId");

                    b.HasIndex("DrugId1");

                    b.HasIndex("DrugStoreId");

                    b.ToTable("DrugItem", null, t =>
                        {
                            t.HasCheckConstraint("CK_Amount_Range", "[amount] >= 0 AND [amount] <= 10000");

                            t.HasCheckConstraint("CK_Price_GreaterThanOrEqualZero", "[price] >= 0");
                        });
                });

            modelBuilder.Entity("Domain.Entities.DrugStore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasAnnotation("Comment", "Идентификатор");

                    b.Property<string>("DrugNetwork")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("drug_network")
                        .HasAnnotation("Comment", "Аптечная сеть");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number")
                        .HasAnnotation("Comment", "Номер аптеки в сети");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone")
                        .HasAnnotation("Comment", "Номер телефона");

                    b.HasKey("Id");

                    b.ToTable("DrugStore", null, t =>
                        {
                            t.HasCheckConstraint("CK_House_GreaterThanZero", "[house] > 0");

                            t.HasCheckConstraint("CK_Number_GreaterThanZero", "[number] > 0");

                            t.HasCheckConstraint("CK_PostalCode_Range", "[postal_code] >= 10000 AND [postal_code] <= 999999");
                        });
                });

            modelBuilder.Entity("Domain.Entities.FavouriteDrug", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasAnnotation("Comment", "Идентификатор");

                    b.Property<Guid>("DrugId")
                        .HasColumnType("uuid")
                        .HasColumnName("drug_id")
                        .HasAnnotation("Comment", "Идентификатор лекарства");

                    b.Property<Guid?>("DrugStoreId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid")
                        .HasColumnName("profile_id")
                        .HasAnnotation("Comment", "Идентификатор профиля");

                    b.HasKey("Id");

                    b.HasIndex("DrugId");

                    b.HasIndex("DrugStoreId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FavouriteDrug", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasAnnotation("Comment", "Идентификатор");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("external_id")
                        .HasAnnotation("Comment", "Внешний идентификатор (телеграм)");

                    b.HasKey("Id");

                    b.ToTable("UserProfile", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Drug", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("Drugs")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.DrugItem", b =>
                {
                    b.HasOne("Domain.Entities.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Drug", null)
                        .WithMany("DrugItems")
                        .HasForeignKey("DrugId1");

                    b.HasOne("Domain.Entities.DrugStore", "DrugStore")
                        .WithMany("DrugItems")
                        .HasForeignKey("DrugStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("DrugStore");
                });

            modelBuilder.Entity("Domain.Entities.DrugStore", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("DrugStoreId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("city")
                                .HasAnnotation("Comment", "Город");

                            b1.Property<int>("House")
                                .HasColumnType("integer")
                                .HasColumnName("house")
                                .HasAnnotation("Comment", "Дом");

                            b1.Property<int>("PostalCode")
                                .HasColumnType("integer")
                                .HasColumnName("postal_code")
                                .HasAnnotation("Comment", "Почтовый индекс");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("street")
                                .HasAnnotation("Comment", "Улица");

                            b1.HasKey("DrugStoreId");

                            b1.ToTable("DrugStore");

                            b1.WithOwner()
                                .HasForeignKey("DrugStoreId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.FavouriteDrug", b =>
                {
                    b.HasOne("Domain.Entities.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.DrugStore", "DrugStore")
                        .WithMany()
                        .HasForeignKey("DrugStoreId");

                    b.HasOne("Domain.Entities.UserProfile", "UserProfile")
                        .WithMany("FavouriteDrugs")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("DrugStore");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Domain.Entities.UserProfile", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserProfileId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email")
                                .HasAnnotation("Comment", "Почта");

                            b1.HasKey("UserProfileId");

                            b1.ToTable("UserProfile");

                            b1.WithOwner()
                                .HasForeignKey("UserProfileId");
                        });

                    b.Navigation("Email");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("Drugs");
                });

            modelBuilder.Entity("Domain.Entities.Drug", b =>
                {
                    b.Navigation("DrugItems");
                });

            modelBuilder.Entity("Domain.Entities.DrugStore", b =>
                {
                    b.Navigation("DrugItems");
                });

            modelBuilder.Entity("Domain.Entities.UserProfile", b =>
                {
                    b.Navigation("FavouriteDrugs");
                });
#pragma warning restore 612, 618
        }
    }
}
