﻿using Microsoft.EntityFrameworkCore;
using techMADT.Core.Entities;

namespace techMADT.Data
{
    public class DatabaseContext :DbContext
    {
        public DbSet <AppUser> AppUsers{ get; set; }
        public DbSet <Brand> Brands {get; set; }
        public DbSet <Category> Categories{ get; set; }
        public DbSet <Contact> Contacts{ get; set; }
        public DbSet <News> News{ get; set; }
        public DbSet <Product> Products{ get; set; }
        public DbSet <Slider> Sliders{ get; set; }
    }
}
