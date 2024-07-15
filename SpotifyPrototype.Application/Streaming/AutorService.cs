using AutoMapper;
using SpotifyPrototype.Application.Streaming.Dto;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using SpotifyPrototype.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Streaming
{
    public class AutorService
    {
        private AutorRepository _autorRepository;
        private IMapper mapper;

        public AutorService(AutorRepository autorRepository, IMapper mapper)
        {
            this._autorRepository = autorRepository;
            this.mapper = mapper;
        }

        public AutorDto Criar(AutorDto Autordto)
        {
            Autor autor = Autor.Criar(Autordto.Nome, Autordto.Descricao, Autordto.Backdrop);

            this._autorRepository.Save(autor);

            return this.mapper.Map<AutorDto>(autor);
        }

        public AutorDto? Obter(Guid id)
        {
            var result = _autorRepository.GetById(id);

            if (result == null)
                return null;
            return this.mapper.Map<AutorDto>(result);
        }

        public IEnumerable<AutorDto> Obter()
        {
            var result = _autorRepository.GetAll().ToList();

            return this.mapper.Map<List<AutorDto>>(result);
        }

        public void Salvar(AutorDto dto)
        {
            var autor = mapper.Map<Autor>(dto);

            _autorRepository.Save(autor);
        }
    }
}
