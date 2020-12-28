# Usage

# Back-end

## Enteties

Use the `[ReadDTO(typeof(readDTO))]` attribute to select wich DTO maps to for the read.

Use the `[CreateDTO(typeof(createDTO))]` attribute to select wich DTO maps to the enty.

Use the `[UpdateDTO(typeof(updateDTO))]` attribute to select wich DTO maps to the enty.

Maping all happens automaticly.

## Repository

* GenericRepository<baseEntity, readDTO>

* All the methods are automatcly created due to the 3 Custom atributes

## Service

There are 4 types of over loads for the IGenericServices.

1. IGenericService<TBase, TID> is the basic for all the other service interfaces
2. IGenericService<Tbase, TID, TRead> is made for. Read, GetById and delete
3. IGenericService<Tbase, TID, TRead, TCreate> Is same as the one before but adds for creation of new enties in the database
4. IGenericService<Tbase, TID, TRead, TCreate, TUpdate> Same as before but adds updating objects in the database

## Generics.Configurations

`BaseEntityTypeConfiguration<TBase>`

A base configurer for the database enties.

The constructer of this configurer takes in a `prefix` and `sufix`

it automatcly creates the table names it loops over the `TBase` name it then for each Capitel letter it puts a `_` in the name.

Then it adds the prefix then the final name then the sufix

`BaseDeleteEntityTypeConfiguration<TBase>`

It does the same as the `BaseEntityTypeConfiguration` except it filters out if the item is soft deleted.
