using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.Data
{
    public class WebBatDongSan_DKCNContext : DbContext
    {
        public WebBatDongSan_DKCNContext (DbContextOptions<WebBatDongSan_DKCNContext> options)
            : base(options)
        {
        }

    }
}
