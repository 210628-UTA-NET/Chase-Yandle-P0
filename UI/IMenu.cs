using System;

namespace UI
{
    public enum MenuTitle
    {
        BaseMenu,
        CustInputMenu,
        CustReadoutMenu,
        Exit,
        Error
    }
    public interface IMenu
    {
        void Menu();
        MenuTitle UInput();
    }
}