# YGODeckBuilder

In development... This is not ready yet.

Deck Building service that provides information about a status legality of a card. This is to be intended to used to help with deckbuilding with legacy card formats.

## Setup

#### Database

This application uses DynamoDB. To set it up, it needs Java. To download Java, go to [this](https://www.oracle.com/java/technologies/javase-jdk15-downloads.html) to get the latest version of Java.

Go to [this](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/DynamoDBLocal.DownloadingAndRunning.html) url to download a local copy of DynamoDB.

### Application

Application runs on .NET Core. 



#### SSL Keys

You may need to create new HTTPS keys on your machine in order to create a working API project.

On a Mac, you might already have expired ones. If so, open *KeyChain Access*. From there, look at your *login* and *system* under keychains. For both of those, look under *Certificates* and *My Certificates*. Delete any expired certificates.

To create a trusted development SSL certificate, run the following command in your terminal:

```bash
dotnet dev-certs https --trust
```

---

## API Guide


- Api Guide [Help](https://db.ygoprodeck.com/api-guide/)
- List of Card Sets [Api](https://db.ygoprodeck.com/api/v7/cardsets.php)
- Card from a Set [Api](https://db.ygoprodeck.com/api/v7/cardsetsinfo.php?setcode=SDY-046)
- All Card Sets [API](https://db.ygoprodeck.com/api/v7/cardsets.php)
- All cards [Api](https://db.ygoprodeck.com/api/v7/cardinfo.php)

Search card by ID:

> https://db.ygoprodeck.com/api/v7/cardinfo.php?id=6983839

Where ID is the YGO card information.

## Banlists


- Sept 2011 [Banlist](https://yugioh.fandom.com/wiki/September_2011_Lists_(TCG))