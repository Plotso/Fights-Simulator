namespace Fights_Simulator.Models
{
    using Fights_Simulator.Interfaces;
    using Fights_Simulator.Models.Items;
    using System;
    using System.Collections.Generic;

    public class Shop
    {
        private IList<IItem> shopItems;

        public Shop()
        {
            shopItems = new List<IItem>();
        }

        public IList<IItem> Items
        {
            get => this.shopItems;
        }

        public void AddBasicItems()
        {
            var items = new List<IItem>();
            items.Add(AddHelmet());
            items.Add(AddGloves());
            items.Add(AddMouthguard());
            items.Add(AddBoots());

            foreach (var item in items)
            {
                shopItems.Add(item);
            }
        }

        private IItem AddBoots()
        {
            Boots boots = new Boots("Basic Boots", false, 5, 20, 10, 10, 10);
            return boots;
        }

        private IItem AddMouthguard()
        {
            Mouthguard mouthguard = new Mouthguard("Basic MouthGuard", false, 5, 5, 20, 20, 5);
            return mouthguard;
        }

        private IItem AddGloves()
        {
            Gloves gloves = new Gloves("Basic Gloves", false, 15, 5, 10, 10, 20);
            return gloves;
        }

        private IItem AddHelmet()
        {
            Helmet helmet = new Helmet("Basic Helmet",false,5,5,20,15,5);
            return helmet;

        }
        //public AbstractItem AddSpecialItem(IList<string> arguments)
        //{
        //    var name = arguments[0];
        //    var trueOrFalse = arguments[1];
        //    if (trueOrFalse != "Y")
        //    {
        //        throw new ArgumentException("Item isn't special")
        //    }
        //}
    }
}
