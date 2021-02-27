# Proposed Database Schemas

Goal of this is to outline tables we possibly need.

## Source of Truth Table

The main table that will hold all the info. For the nullable tables, the idea is that these will initialize as null. When a null field is detected, the service will run on that card to determine the legality status. The `int` value of the statuses will be held in another table.

#### Schema

- `int` DynamoID
  - Unique Identifier supplied by Dynamo
- `int` YGOProDeckID
  - Unique Identifier provided by the API
  - For optimal querying, it's in our best interest to have this saved
- `string` Card Image URL
  - For whenever a front page is developed, this will be useful.
- `nullable int` GoatFormat
  - Legality in Goat Format
- `nullable int` Edison Format
  - Legality in Edison Format
- `nullable int` Sept2011 Format
  - Legality in Sept 2011



## Set Table

Goal of this table is to have all the Sets and their release date on hand. This will prevent future API calls where unesseary.

#### Schema

- `int` DynamoID
  - Unique Identifier supplied by Dynamo
- `string` SetCode
  - Konami's identifier for the set
- `DateTime` Release Date
  - When the set was released

## Legality Status

For the `int` values for what a legal status for a card is.

#### Schema

- `int` DynamoID
  - Unique Identifier supplied by Dynamo
- `int` Legal Identifier
  - A number representing a legality status
- `string` Legal Status
  - The string representation of a legality status
- `string` Legal description
  - Explains what that legal status means

## Lookup Table

This table may not be needed. Only holds a lookup of the cards in the API. For whenever the front-end is made, this might be more performant. In the meantime, will skip until it is needed.

#### Schema

- `int` DynamoDB
  - Unique Identifier supplied by Dynamo
- `int` YGOProDeckID
  - Unique Identifier provided by the API
- `int` Card Name
  - The name of the card.