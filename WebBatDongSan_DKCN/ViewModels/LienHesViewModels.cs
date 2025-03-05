using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.ViewModels
{
    public class LienHesViewModels
    {
        public List<Menu> Menus { get; set; }
        public List<LienHe> lienHes { get; set; }
        public LienHe GuiLienHe { get; set; }

        public LienHesViewModels()
        {
            GuiLienHe = new LienHe();
        }
    }
}
