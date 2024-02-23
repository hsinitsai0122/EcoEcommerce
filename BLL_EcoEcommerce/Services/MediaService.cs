using BLL_EcoEcommerce.Entities;
using BLL_EcoEcommerce.Mappers;
using Shared_EcoEcommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DAL_EcoEcommerce.Entities;

namespace BLL_EcoEcommerce.Services
{
    public class MediaService : IMediaRepository<Media>
    {
        private readonly IMediaRepository<DAL.Media> _mediaRepository;

        public MediaService(IMediaRepository<DAL.Media> mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public IEnumerable<Media> GetAll()
        {
            return _mediaRepository.GetAll().Select(d => d.ToBLL());
        }

        public Media GetById(int id)
        {
            Media entity = _mediaRepository.GetById(id).ToBLL();
            if (!(entity.Id_Media == 0))
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Media> GetMediaForProduct(int id_product)
        {
            return _mediaRepository.GetMediaForProduct(id_product).Select(d => d.ToBLL());
        }

        public Media GetSingleImageForProduct(int id_Product)
        {
            return _mediaRepository.GetSingleImageForProduct(id_Product).ToBLL();
        }

        public int Insert(Media entity)
        {
            return _mediaRepository.Insert(entity.ToDAL());
        }

        public void Update(Media entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            _mediaRepository.Delete(id);
        }

        public void DeleteByProductId(int id_Product)
        {
            _mediaRepository.DeleteByProductId(id_Product);
        }
    }
}
