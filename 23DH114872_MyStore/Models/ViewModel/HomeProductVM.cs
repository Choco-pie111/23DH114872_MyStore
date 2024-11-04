﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace _23DH114872_MyStore.Models.ViewModel
{
    public class HomeProductVM
    {
        //Tiêu chí để search theo tên, mô tả sp
        //hoặc loại sản phẩm
        public string SearchTerm { get; set; }
        //Các thuộc tính hỗ trợ phân trang
        public int PageNumber { get; set; }//Trang hiện tại
        public int PageSize { get; set; } = 10; //Số sp mỗi trang
        //Danh sách sản phẩm nổi bật
        public List<Product> FeaturedProducts { get; set; } 
        //Danh sách sản phẩm mới đã phân trang 
        public PagedList.IPagedList<Product> NewProducts { get; set; }
        //Danh sách sản phẩm thỏa điều kiện cần tìm kiếm
        //public List<Product> Products { get; set; }
    }
}