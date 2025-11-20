SHOPPING LIST

The main project contains a shopping list example, and the applied logic distributes the items into baskets according to these rules:

  - Maximum weight per basket: 20 kg.

  - Items are sorted by descending weight.

  - As many baskets as needed are generated.

  - Each basket’s contents and total weight are printed to the console.

This project includes 4 unit tests that reference the main project and verify the functionality of the BasketSelector.
The tests check that:

  - The basket never exceeds the 20 kg limit.

  - Heavier items are prioritized first.

  - Only items that fit within the weight limit are selected.

  - An empty list is handled correctly.
