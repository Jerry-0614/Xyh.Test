﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yc.Portal.EntityFrameworkCore;

namespace Yc.Portal.Migrations
{
    [DbContext(typeof(PortalDbContext))]
    [Migration("20200227093005_addtableWorkBenchSectionAndSectionOrderIndex")]
    partial class addtableWorkBenchSectionAndSectionOrderIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Yc.Portal.Entities.AppVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApkUrl")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsBcis");

                    b.Property<bool>("IsForcedUpdate");

                    b.Property<int>("OrgId");

                    b.Property<int?>("TerminalType");

                    b.Property<string>("UpdateInfo")
                        .HasMaxLength(500);

                    b.Property<int>("VersionCode");

                    b.Property<string>("VersionName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AppVersions");
                });

            modelBuilder.Entity("Yc.Portal.Entities.AuthCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50);

                    b.Property<string>("SMSAuthCode")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AuthCodes");
                });

            modelBuilder.Entity("Yc.Portal.Entities.FileReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Memo")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("ReleaseBy")
                        .HasMaxLength(100);

                    b.Property<string>("ReleaseUserName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("State");

                    b.Property<int>("TenantId");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("FileReports");
                });

            modelBuilder.Entity("Yc.Portal.Entities.FileReportAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("FileName")
                        .HasMaxLength(100);

                    b.Property<int>("FileReportId");

                    b.Property<string>("FileSuffixes")
                        .HasMaxLength(50);

                    b.Property<int>("FileType");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("FileReportAttachments");
                });

            modelBuilder.Entity("Yc.Portal.Entities.FileReportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeepCode")
                        .HasMaxLength(500);

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("EnName")
                        .HasMaxLength(100);

                    b.Property<string>("IconFileName")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsInnerIP");

                    b.Property<bool>("IsStructType");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("MobileUrl")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("OrderNum");

                    b.Property<int>("ParentId");

                    b.Property<string>("PcUrl")
                        .HasMaxLength(500);

                    b.Property<string>("ReportCode")
                        .HasMaxLength(50);

                    b.Property<string>("ReportTypeCode")
                        .HasMaxLength(50);

                    b.Property<int>("TenantId");

                    b.Property<int>("WorkBenchId");

                    b.HasKey("Id");

                    b.ToTable("FileReportTypes");
                });

            modelBuilder.Entity("Yc.Portal.Entities.HuaweiUserDeviceToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DeviceToken")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("TenantId");

                    b.Property<string>("UserCode")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("HuaweiUserDeviceTokens");
                });

            modelBuilder.Entity("Yc.Portal.Entities.MessageQueue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("ExtendData");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool?>("IsRead");

                    b.Property<bool?>("IsReceive");

                    b.Property<bool>("IsSend");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("MessageType");

                    b.Property<string>("Owner")
                        .HasMaxLength(50);

                    b.Property<string>("ProductType")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ReadDate");

                    b.Property<DateTime?>("ReceiveDate");

                    b.Property<string>("RedirectUrl")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("SendTime");

                    b.Property<int>("TenantId");

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.Property<string>("UserCode")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MessageQueues");
                });

            modelBuilder.Entity("Yc.Portal.Entities.OAFlowOrgProjectMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("FlowInstitutionName")
                        .HasMaxLength(100);

                    b.Property<string>("FlowProjectCategory")
                        .HasMaxLength(100);

                    b.Property<string>("FlowProjectName")
                        .HasMaxLength(100);

                    b.Property<string>("FlowStructureName")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Memo")
                        .HasMaxLength(500);

                    b.Property<string>("OrgGuid")
                        .HasMaxLength(100);

                    b.Property<int>("OrgId");

                    b.HasKey("Id");

                    b.ToTable("OAFlowOrgProjectMappings");
                });

            modelBuilder.Entity("Yc.Portal.Entities.OrgFlowTemplateTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("FlowTemplateType")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("OrgGuid")
                        .HasMaxLength(100);

                    b.Property<int>("OrgId");

                    b.Property<string>("Tag")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("OrgFlowTemplateTags");
                });

            modelBuilder.Entity("Yc.Portal.Entities.OrgRelations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCode");

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("OrgId");

                    b.Property<int>("TenantCode");

                    b.HasKey("Id");

                    b.ToTable("OrgRelations");
                });

            modelBuilder.Entity("Yc.Portal.Entities.OrgVisitOaDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("FID");

                    b.Property<string>("FName");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("OaDocFolder");

                    b.Property<string>("OaDocFolderID");

                    b.Property<string>("OrgGuid");

                    b.HasKey("Id");

                    b.ToTable("OrgVisitOaDoc");
                });

            modelBuilder.Entity("Yc.Portal.Entities.ReportCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCode")
                        .HasMaxLength(100);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("ReportCode")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ReportCompanies");
                });

            modelBuilder.Entity("Yc.Portal.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsStatic");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Yc.Portal.Entities.RoleAddressBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("OrgId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleAddressBooks");
                });

            modelBuilder.Entity("Yc.Portal.Entities.RoleCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCode");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleCompanies");
                });

            modelBuilder.Entity("Yc.Portal.Entities.RoleOrg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("OrgId");

                    b.Property<string>("OrgName")
                        .HasMaxLength(100);

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleOrgs");
                });

            modelBuilder.Entity("Yc.Portal.Entities.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("PermissionName")
                        .HasMaxLength(500);

                    b.Property<int>("RoleId");

                    b.Property<int>("TenantId");

                    b.HasKey("Id");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Yc.Portal.Entities.RoleReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<int>("FileReportTypeId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleReports");
                });

            modelBuilder.Entity("Yc.Portal.Entities.RoleWorkBench", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("RoleId");

                    b.Property<int>("TenantId");

                    b.Property<int>("WorkBenchId");

                    b.HasKey("Id");

                    b.ToTable("RoleWorkBenches");
                });

            modelBuilder.Entity("Yc.Portal.Entities.SalarySetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DisplayCnName")
                        .HasMaxLength(100);

                    b.Property<string>("DisplayEnName")
                        .HasMaxLength(100);

                    b.Property<string>("GroupEnName")
                        .HasMaxLength(50);

                    b.Property<string>("GroupName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsShowing");

                    b.Property<string>("ItemKey");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Memo")
                        .HasMaxLength(500);

                    b.Property<int>("Nationality");

                    b.Property<string>("OrgGuid")
                        .HasMaxLength(100);

                    b.Property<int>("OrgId");

                    b.Property<int>("Sort");

                    b.HasKey("Id");

                    b.ToTable("SalarySettings");
                });

            modelBuilder.Entity("Yc.Portal.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("RoleId");

                    b.Property<int>("TenantId");

                    b.Property<string>("UserGuid")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Yc.Portal.Entities.VisitDict", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Group")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("PageKey")
                        .HasMaxLength(50);

                    b.Property<string>("PageName")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.Property<string>("Url")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("VisitDicts");
                });

            modelBuilder.Entity("Yc.Portal.Entities.VisitHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DeviceNumber")
                        .HasMaxLength(100);

                    b.Property<string>("Guid")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("PageKey")
                        .HasMaxLength(50);

                    b.Property<int>("PointClient");

                    b.Property<DateTime>("VisitTime");

                    b.HasKey("Id");

                    b.ToTable("VisitHistories");
                });

            modelBuilder.Entity("Yc.Portal.Entities.WirelessLan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Latitude")
                        .HasMaxLength(50);

                    b.Property<string>("Longitude")
                        .HasMaxLength(50);

                    b.Property<string>("MacAddress")
                        .HasMaxLength(50);

                    b.Property<string>("Memo")
                        .HasMaxLength(500);

                    b.Property<string>("WirelessName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("WirelessLans");
                });

            modelBuilder.Entity("Yc.Portal.Entities.WorkBench", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BCISMobileUrl")
                        .HasMaxLength(1000);

                    b.Property<int>("ClientType");

                    b.Property<string>("CreationBy")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreationUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DeleteBy")
                        .HasMaxLength(100);

                    b.Property<string>("DeleteUserName")
                        .HasMaxLength(50);

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("EnName")
                        .HasMaxLength(50);

                    b.Property<string>("EnSectionName")
                        .HasMaxLength(50);

                    b.Property<string>("IconUrl")
                        .HasMaxLength(100);

                    b.Property<string>("Intent")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("LinkOpenMode");

                    b.Property<string>("MacUrl")
                        .HasMaxLength(1000);

                    b.Property<string>("Memo")
                        .HasMaxLength(500);

                    b.Property<string>("MobileUrl")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("OrderIndex");

                    b.Property<int>("SectionId");

                    b.Property<string>("SectionName");

                    b.Property<string>("Template")
                        .HasMaxLength(100);

                    b.Property<int>("TenantId");

                    b.Property<string>("VisitPageKey")
                        .HasMaxLength(50);

                    b.Property<string>("WinUrl")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("WorkBenches");
                });
#pragma warning restore 612, 618
        }
    }
}