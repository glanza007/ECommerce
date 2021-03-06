﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Producto")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [DisplayName("Disponible")]
        public bool IsActive { get; set; }

        [MaxLength(15)]
        [DisplayName("Código")]
        public string Code { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        [DisplayName("No Imagenes")]
        public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        //TODO: Pending to put the correct paths
        [Display(Name = "Imagen")]
        public string ImageFullPath => ProductImages == null || ProductImages.Count == 0
            ? $"https://localhost:44390/images/noimage.png"
            : ProductImages.FirstOrDefault().ImageFullPath;
    }

}
