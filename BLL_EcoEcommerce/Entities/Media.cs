using DAL_EcoEcommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EcoEcommerce.Entities
{
    public class Media
    {
        private string _imgUrl;
        private List<Media> _medias;
        public int Id_Media { get; private set; }
        public string ImgUrl { 
            get
            {
                return _imgUrl;
            }
            private set
            {
                _imgUrl = value;
            }
        }
        public int Id_Product { get; private set; }
        public Media(int id_Media, string imgUrl, int id_Product)
        {
            Id_Media = id_Media;
            ImgUrl = imgUrl;
            Id_Product = id_Product;
        }
        public Media(string imgUrl, int id_Product)
        {
            ImgUrl = imgUrl;
            Id_Product = id_Product;
            _medias = new List<Media>();
        }


        public Media[] Medias
        {
            get
            {
                return _medias.ToArray() ?? new Media[0];
            }
        }

        public void AddMedia(Media media)
        {
            _medias.Add(media);
        }

        public void RemoveMedia(Media media)
        {
            _medias.Remove(media);
        }
    }
}
