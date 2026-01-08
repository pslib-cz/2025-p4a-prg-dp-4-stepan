using System;
using System.Collections.Generic;

namespace NavigationSystem.Menu
{
    public class MenuCategory : MenuComponent
    {
        private readonly List<MenuComponent> _children = new List<MenuComponent>();

        public MenuCategory(string title) : base(title)
        {
        }

        public override void Add(MenuComponent component)
        {
            component.Parent = this;
            _children.Add(component);
        }

        public override void Remove(MenuComponent component)
        {
            component.Parent = null;
            _children.Remove(component);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new string(' ', indent * 2) + "+ " + Title);
            for (int i = 0; i < _children.Count; i++)
            {
                Console.WriteLine($"{new string(' ', indent * 2)}{i + 1}. {_children[i].Title}");
            }
        }

        public MenuComponent GetChild(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                return _children[index];
            }
            return null;
        }
    }
}
