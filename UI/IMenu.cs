using System;

namespace UI
{
    public enum MenuTitle
    {
        BaseMenu,
        CustInputMenu,
        CustReadoutMenu,
        Exit
    }
    public interface IMenu
    {
        void Menu();
        MenuTitle UInput();
    }
}