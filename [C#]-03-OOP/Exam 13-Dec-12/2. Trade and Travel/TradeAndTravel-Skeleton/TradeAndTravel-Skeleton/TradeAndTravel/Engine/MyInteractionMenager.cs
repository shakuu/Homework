
namespace TradeAndTravel
{
    using System;
    using System.Linq;

    public class MyInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {

            switch (itemTypeString)
            {
                case "armor":
                    item = new Armor(itemNameString, itemLocation);
                    break;
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    break;
            }
            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "shopkeeper":
                    person = new Shopkeeper(personNameString, personLocation);
                    break;
                case "traveller":
                    person = new Traveller(personNameString, personLocation);
                    break;
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    break;
            }
            return person;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "town":
                    location = new Town(locationName);
                    break;
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(commandWords[2], actor);
                    break;
                case "craft":
                    this.HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            switch (commandWords[2])
            {
                case "armor":
                    this.HandleCraftArmorInteraction(commandWords[3], actor);
                    break;
                case "weapon":
                    this.HandeCraftWeaponInteraction(commandWords[3], actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandeCraftWeaponInteraction(string newItemName, Person actor)
        {
            var inventory = actor.ListInventory();

            if (inventory.Any(item => item.GetType() == typeof(Iron))
                && inventory.Any(item => item.GetType() == typeof(Wood)))
            {
                // TODO: Remove iron ? 
                base.AddToPerson(actor, new Weapon(newItemName));
            }
        }

        private void HandleCraftArmorInteraction(string newItemName, Person actor)
        {
            var inventory = actor.ListInventory();

            if (inventory.Any(item => item.GetType() == typeof(Iron)))
            {
                // TODO: Remove iron and wood ? 
                base.AddToPerson(actor, new Armor(newItemName));
            }
        }

        private void HandleGatherInteraction(string newItemName, Person actor)
        {
            if (actor.Location.GetType() == typeof(Forest))
            {
                this.HandeGatherInteractionInForest(newItemName, actor);
            }
            else if (actor.Location.GetType() == typeof(Mine))
            {
                this.HandeGatherInteractionInMine(newItemName, actor);
            }
            else
            {
                // Nothing.
            }
        }

        private void HandeGatherInteractionInMine(string newItemName, Person actor)
        {
            var inventory = actor.ListInventory();

            if (inventory.Any(item => item.GetType() == typeof(Armor)))
            {
                base.AddToPerson(actor, new Iron(newItemName));
            }
        }

        private void HandeGatherInteractionInForest(string newItemName, Person actor)
        {
            var inventory = actor.ListInventory();

            if (inventory.Any(item => item.GetType() == typeof(Weapon)))
            {
                base.AddToPerson(actor, new Wood(newItemName));
            }
        }
    }
}
