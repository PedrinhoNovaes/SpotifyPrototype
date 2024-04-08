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
    public class BandService
    {
        private BandRepository BandRepository { get; set; }
        private IMapper Mapper { get; set; }

        public BandService(BandRepository bandRepository, IMapper mapper)
        {
            BandRepository = bandRepository;
            Mapper = mapper;
        }

        public BandDto Create(BandDto dto)
        {
            Band band = Mapper.Map<Band>(dto);
            BandRepository.Save(band);
            return Mapper.Map<BandDto>(band);
        }

        public BandDto Get(Guid id)
        {
            var band = BandRepository.GetById(id);
            return Mapper.Map<BandDto>(band);
        }

        public IEnumerable<BandDto> Get()
        {
            var bands = BandRepository.GetAll();
            return Mapper.Map<IEnumerable<BandDto>>(bands);
        }

        public AlbumDto AssociateAlbum(AlbumDto dto)
        {
            var band = BandRepository.GetById(dto.BandId);

            if (band == null)
            {
                throw new Exception("Band not found");
            }

            var newAlbum = AlbumDtoToAlbum(dto);
            band.AddAlbum(newAlbum);
            BandRepository.Update(band);

            return AlbumToAlbumDto(newAlbum);
        }

        public AlbumDto GetAlbumById(Guid bandId, Guid id)
        {
            var band = BandRepository.GetById(bandId);

            if (band == null)
            {
                throw new Exception("Band not found");
            }

            var album = band.Albums.FirstOrDefault(x => x.Id == id);

            var result = AlbumToAlbumDto(album);
            result.BandId = band.Id;

            return result;
        }

        public List<AlbumDto> GetAlbums(Guid bandId)
        {
            var band = BandRepository.GetById(bandId);

            if (band == null)
            {
                throw new Exception("Band not found");
            }

            var result = new List<AlbumDto>();

            foreach (var item in band.Albums)
            {
                result.Add(AlbumToAlbumDto(item));
            }

            return result;
        }

        private Album AlbumDtoToAlbum(AlbumDto dto)
        {
            Album album = new Album()
            {
                Name = dto.Name
            };

            foreach (MusicDto item in dto.Songs)
            {
                album.AddSong(new Song
                {
                    Name = item.Name,
                    Duration = new SpotifyPrototype.Domain.Streaming.ValueObjects.Duration(item.Duration)
                });
            }

            return album;
        }

        private AlbumDto AlbumToAlbumDto(Album album)
        {
            AlbumDto dto = new AlbumDto
            {
                Id = album.Id,
                Name = album.Name
            };

            foreach (var item in album.Songs)
            {
                var musicDto = new MusicDto
                {
                    Id = item.Id,
                    Duration = item.Duration.Value,
                    Name = item.Name
                };

                dto.Songs.Add(musicDto);
            }

            return dto;
        }
    }

}
