using System;
using NavigationSystem.Menu;

namespace NavigationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            // Define actions
            Action selectReact = () => Console.WriteLine(">> Vybráno: React Framework");
            Action selectTypescript = () => Console.WriteLine(">> Vybráno: TypeScript konfigurace");
            Action selectJavascript = () => Console.WriteLine(">> Vybráno: JavaScript konfigurace");
            Action exitAction = () => { running = false; };

            // Create root menu
            var mainMenu = new MenuCategory("NPM Project Wizard");

            // Level 1: JS
            var jsMenu = new MenuCategory("js");

            // Level 2: React (jako konečná volba)
            jsMenu.Add(new MenuItem("react", selectReact));

            // Level 2: React-Router (jako podmenu)
            var reactRouterMenu = new MenuCategory("react-router");
            
            // Level 3: TS / JS
            reactRouterMenu.Add(new MenuItem("typescript", selectTypescript));
            reactRouterMenu.Add(new MenuItem("javascript", selectJavascript));

            jsMenu.Add(reactRouterMenu);
            
            // Přidání do hlavního menu
            mainMenu.Add(jsMenu);
            mainMenu.Add(new MenuItem("Ukončit", exitAction));

            MenuComponent currentMenu = mainMenu;

            while (running)
            {
                Console.Clear();
                Console.WriteLine($"--- {currentMenu.Title} ---");
                // Zobrazíme jen přímé potomky s číslováním
                currentMenu.Display(0);
                
                Console.WriteLine("0. Zpět");
                Console.Write("\nVyberte možnost: ");

                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int selection))
                {
                    if (selection == 0)
                    {
                        if (currentMenu.Parent != null)
                            currentMenu = currentMenu.Parent;
                        else
                            running = false;
                        continue;
                    }

                    if (currentMenu is MenuCategory category)
                    {
                        MenuComponent selectedComponent = category.GetChild(selection - 1);
                        if (selectedComponent != null)
                        {
                            if (selectedComponent is MenuCategory)
                            {
                                currentMenu = selectedComponent;
                            }
                            else
                            {
                                selectedComponent.Execute();
                                Console.WriteLine("\nStiskněte libovolnou klávesu...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Neplatná volba.");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
    }
}