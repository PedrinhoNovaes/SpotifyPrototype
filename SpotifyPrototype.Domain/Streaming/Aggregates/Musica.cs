﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public String Letra { get; set; }
        public virtual EstiloMusical EstiloMusical { get; set; }
        public virtual IList<Autor> Autores { get; set; } = [];
        public virtual IList<Interprete> Interpretes { get; set; } = [];
        public virtual IList<Playlist> Playlists { get; set; } = [];
        public virtual IList<Album> Albuns { get; set; } = [];

        public void AdicionarAutor(Autor autor) => this.Autores.Add(autor);

        public void AdicionarInterprete(Interprete interprete) => this.Interpretes.Add(interprete);

        public void AdicionarPlayList(Playlist playlist) => this.Playlists.Add(playlist);

        public void RemoverPlayList(Playlist playlist) => this.Playlists.Remove(playlist);

        public static Musica Criar(String nome,
            String letra, EstiloMusical estilo, List<Autor> autores)
        {
            if (String.IsNullOrEmpty(nome)) throw new Exception("E obrigatorio informar o nome da musica");
            if (autores == null || autores.Count == 0) throw new Exception("E obrigatorio informar ao menos um autor.");

            var musica = new Musica()
            {
                Nome = nome,
                Letra = letra,
                EstiloMusical = estilo,
            };

            autores.ForEach(x => musica.AdicionarAutor(x));

            return musica;
        }
    }
}
