using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OpenSeaWebApi.Migrations
{
    public partial class InitialCommitHeroku : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    contact = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<byte[]>(type: "bytea", nullable: true),
                    image_small = table.Column<byte[]>(type: "bytea", nullable: true),
                    observations = table.Column<string>(type: "text", nullable: true),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    FirstLogin = table.Column<bool>(type: "boolean", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomAssetContract",
                columns: table => new
                {
                    primary_key_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: true),
                    AssetContractType = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NftVersion = table.Column<string>(type: "text", nullable: true),
                    OpenseaVersion = table.Column<string>(type: "text", nullable: true),
                    Owner = table.Column<int>(type: "integer", nullable: true),
                    SchemaName = table.Column<string>(type: "text", nullable: true),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    TotalSupply = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ExternalLink = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    DefaultToFiat = table.Column<bool>(type: "boolean", nullable: false),
                    DevBuyerFeeBasisPoints = table.Column<int>(type: "integer", nullable: false),
                    DevSellerFeeBasisPoints = table.Column<int>(type: "integer", nullable: false),
                    OnlyProxiedTransfers = table.Column<bool>(type: "boolean", nullable: false),
                    OpenseaBuyerFeeBasisPoints = table.Column<int>(type: "integer", nullable: false),
                    OpenseaSellerFeeBasisPoints = table.Column<int>(type: "integer", nullable: false),
                    BuyerFeeBasisPoints = table.Column<int>(type: "integer", nullable: false),
                    SellerFeeBasisPoints = table.Column<int>(type: "integer", nullable: false),
                    PayoutAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAssetContract", x => x.primary_key_Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomDisplayData",
                columns: table => new
                {
                    primary_key_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardDisplayStyle = table.Column<string>(type: "text", nullable: true),
                    Images = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomDisplayData", x => x.primary_key_Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomUser",
                columns: table => new
                {
                    primary_key_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomUser", x => x.primary_key_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "db_configUser",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    itemsPerPage = table.Column<int>(type: "integer", nullable: false),
                    isDarkTheme = table.Column<bool>(type: "boolean", nullable: false),
                    AppUser_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_configUser", x => x.id);
                    table.ForeignKey(
                        name: "FK_db_configUser_AspNetUsers_AppUser_id",
                        column: x => x.AppUser_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "db_Collection",
                columns: table => new
                {
                    primary_key_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    BannerImageUrl = table.Column<string>(type: "text", nullable: true),
                    ChatUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DefaultToFiat = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DevBuyerFeeBasisPoints = table.Column<string>(type: "text", nullable: true),
                    DevSellerFeeBasisPoints = table.Column<string>(type: "text", nullable: true),
                    DiscordUrl = table.Column<string>(type: "text", nullable: true),
                    DisplayDataprimary_key_Id = table.Column<int>(type: "integer", nullable: true),
                    ExternalUrl = table.Column<string>(type: "text", nullable: true),
                    Featured = table.Column<bool>(type: "boolean", nullable: false),
                    FeaturedImageUrl = table.Column<string>(type: "text", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    SafelistRequestStatus = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsSubjectToWhitelist = table.Column<bool>(type: "boolean", nullable: false),
                    LargeImageUrl = table.Column<string>(type: "text", nullable: true),
                    MediumUsername = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OnlyProxiedTransfers = table.Column<bool>(type: "boolean", nullable: false),
                    OpenseaBuyerFeeBasisPoints = table.Column<string>(type: "text", nullable: true),
                    OpenseaSellerFeeBasisPoints = table.Column<string>(type: "text", nullable: true),
                    PayoutAddress = table.Column<string>(type: "text", nullable: true),
                    RequireEmail = table.Column<bool>(type: "boolean", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    TelegramUrl = table.Column<string>(type: "text", nullable: true),
                    TwitterUsername = table.Column<string>(type: "text", nullable: true),
                    InstagramUsername = table.Column<string>(type: "text", nullable: true),
                    WikiUrl = table.Column<string>(type: "text", nullable: true),
                    IsNsfw = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_Collection", x => x.primary_key_Id);
                    table.ForeignKey(
                        name: "FK_db_Collection_CustomDisplayData_DisplayDataprimary_key_Id",
                        column: x => x.DisplayDataprimary_key_Id,
                        principalTable: "CustomDisplayData",
                        principalColumn: "primary_key_Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomOwner",
                columns: table => new
                {
                    primary_key_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Userprimary_key_Id = table.Column<int>(type: "integer", nullable: true),
                    ProfileImgUrl = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Config = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOwner", x => x.primary_key_Id);
                    table.ForeignKey(
                        name: "FK_CustomOwner_CustomUser_Userprimary_key_Id",
                        column: x => x.Userprimary_key_Id,
                        principalTable: "CustomUser",
                        principalColumn: "primary_key_Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomAsset",
                columns: table => new
                {
                    primary_key_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    NumSales = table.Column<int>(type: "integer", nullable: false),
                    BackgroundColor = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ImagePreviewUrl = table.Column<string>(type: "text", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    ImageOriginalUrl = table.Column<string>(type: "text", nullable: true),
                    AnimationUrl = table.Column<string>(type: "text", nullable: true),
                    AnimationOriginalUrl = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ExternalLink = table.Column<string>(type: "text", nullable: true),
                    AssetContractprimary_key_Id = table.Column<int>(type: "integer", nullable: true),
                    Permalink = table.Column<string>(type: "text", nullable: true),
                    Decimals = table.Column<int>(type: "integer", nullable: true),
                    TokenMetadata = table.Column<string>(type: "text", nullable: true),
                    IsNsfw = table.Column<bool>(type: "boolean", nullable: true),
                    Ownerprimary_key_Id = table.Column<int>(type: "integer", nullable: true),
                    TokenId = table.Column<string>(type: "text", nullable: true),
                    Collectionprimary_key_Id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAsset", x => x.primary_key_Id);
                    table.ForeignKey(
                        name: "FK_CustomAsset_CustomAssetContract_AssetContractprimary_key_Id",
                        column: x => x.AssetContractprimary_key_Id,
                        principalTable: "CustomAssetContract",
                        principalColumn: "primary_key_Id");
                    table.ForeignKey(
                        name: "FK_CustomAsset_CustomOwner_Ownerprimary_key_Id",
                        column: x => x.Ownerprimary_key_Id,
                        principalTable: "CustomOwner",
                        principalColumn: "primary_key_Id");
                    table.ForeignKey(
                        name: "FK_CustomAsset_db_Collection_Collectionprimary_key_Id",
                        column: x => x.Collectionprimary_key_Id,
                        principalTable: "db_Collection",
                        principalColumn: "primary_key_Id");
                });

            migrationBuilder.CreateTable(
                name: "db_AssetEvent",
                columns: table => new
                {
                    primary_key_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Assetprimary_key_Id = table.Column<int>(type: "integer", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: true),
                    EventTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<string>(type: "text", nullable: true),
                    CollectionSlug = table.Column<string>(type: "text", nullable: true),
                    ContractAddress = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db_AssetEvent", x => x.primary_key_Id);
                    table.ForeignKey(
                        name: "FK_db_AssetEvent_CustomAsset_Assetprimary_key_Id",
                        column: x => x.Assetprimary_key_Id,
                        principalTable: "CustomAsset",
                        principalColumn: "primary_key_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomAsset_AssetContractprimary_key_Id",
                table: "CustomAsset",
                column: "AssetContractprimary_key_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomAsset_Collectionprimary_key_Id",
                table: "CustomAsset",
                column: "Collectionprimary_key_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomAsset_Ownerprimary_key_Id",
                table: "CustomAsset",
                column: "Ownerprimary_key_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOwner_Userprimary_key_Id",
                table: "CustomOwner",
                column: "Userprimary_key_Id");

            migrationBuilder.CreateIndex(
                name: "IX_db_AssetEvent_Assetprimary_key_Id",
                table: "db_AssetEvent",
                column: "Assetprimary_key_Id");

            migrationBuilder.CreateIndex(
                name: "IX_db_Collection_DisplayDataprimary_key_Id",
                table: "db_Collection",
                column: "DisplayDataprimary_key_Id");

            migrationBuilder.CreateIndex(
                name: "IX_db_configUser_AppUser_id",
                table: "db_configUser",
                column: "AppUser_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "db_AssetEvent");

            migrationBuilder.DropTable(
                name: "db_configUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CustomAsset");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CustomAssetContract");

            migrationBuilder.DropTable(
                name: "CustomOwner");

            migrationBuilder.DropTable(
                name: "db_Collection");

            migrationBuilder.DropTable(
                name: "CustomUser");

            migrationBuilder.DropTable(
                name: "CustomDisplayData");
        }
    }
}
