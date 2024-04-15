using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotifyPrototype.Repository.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Backdrop = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstiloMusical",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstiloMusical", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interprete",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interprete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Valor_Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PeriodoInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodoFim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorPrincipalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albuns_Autor_AutorPrincipalId",
                        column: x => x.AutorPrincipalId,
                        principalTable: "Autor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Musica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(1080)", maxLength: 1080, nullable: true),
                    EstiloMusicalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musica_EstiloMusical_EstiloMusicalId",
                        column: x => x.EstiloMusicalId,
                        principalTable: "EstiloMusical",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assinatura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PeriodoInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodoFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assinatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assinatura_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Plano",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assinatura_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Cartao_Numero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DestinatarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemetenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoNotificacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacao_Usuario_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacao_Usuario_RemetenteId",
                        column: x => x.RemetenteId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoPlayList = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Publica = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_Usuario_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusicaAlbum",
                columns: table => new
                {
                    MusicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaAlbum", x => new { x.MusicaId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_MusicaAlbum_Albuns_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicaAlbum_Musica_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicaAutor",
                columns: table => new
                {
                    MusicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaAutor", x => new { x.MusicaId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_MusicaAutor_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicaAutor_Musica_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicaInterprete",
                columns: table => new
                {
                    MusicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterpreteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaInterprete", x => new { x.MusicaId, x.InterpreteId });
                    table.ForeignKey(
                        name: "FK_MusicaInterprete_Interprete_InterpreteId",
                        column: x => x.InterpreteId,
                        principalTable: "Interprete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicaInterprete_Musica_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTransacao = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MerchantNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusicaPlaylist",
                columns: table => new
                {
                    MusicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaPlaylist", x => new { x.MusicaId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_MusicaPlaylist_Musica_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicaPlaylist_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albuns_AutorPrincipalId",
                table: "Albuns",
                column: "AutorPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_PlanoId",
                table: "Assinatura",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_UsuarioId",
                table: "Assinatura",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_UsuarioId",
                table: "Cartao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_EstiloMusicalId",
                table: "Musica",
                column: "EstiloMusicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicaAlbum_AlbumId",
                table: "MusicaAlbum",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicaAutor_AutorId",
                table: "MusicaAutor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicaInterprete_InterpreteId",
                table: "MusicaInterprete",
                column: "InterpreteId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicaPlaylist_PlaylistId",
                table: "MusicaPlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_DestinatarioId",
                table: "Notificacao",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_RemetenteId",
                table: "Notificacao",
                column: "RemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_AutorId",
                table: "Playlist",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_CartaoId",
                table: "Transacao",
                column: "CartaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assinatura");

            migrationBuilder.DropTable(
                name: "MusicaAlbum");

            migrationBuilder.DropTable(
                name: "MusicaAutor");

            migrationBuilder.DropTable(
                name: "MusicaInterprete");

            migrationBuilder.DropTable(
                name: "MusicaPlaylist");

            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropTable(
                name: "Albuns");

            migrationBuilder.DropTable(
                name: "Interprete");

            migrationBuilder.DropTable(
                name: "Musica");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "EstiloMusical");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
