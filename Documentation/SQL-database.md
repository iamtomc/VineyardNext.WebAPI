# Vineyard Next Database Structure

The Vineyard Next application is designed to support members of an organization signing up for various groups. Let's walk through each aspect of this database, so you will understand how it was designed and how you should customize the project for your needs.

## Table of Contents:
1. [Reference Tables](#reference-table)
1. [Groups](#groups)
1. [Members](#members)
1. [Group Members](#groupmembers)
1. [Addresses](#addresses)
1. [Contact Methods](#contactmethods)
1. [Member Addresses](#memberaddresses)
1. [Member Contacts](#membercontacts)
1. [Group Addresses](#groupaddresses)
1. [Group Contacts](#groupcontacts)
1. [Auth0 Identities](#auth0identities)

## Reference Tables
Reference tables are used to associate individual records from different tables. For example, a person may have multiple phone numbers: home, cell, work, next-of-kin, pager, fax, etc. You could create a single field for each of those values on the "person" table. Or you could create a person-contacts table that references each method of contact to the record in the person table. If a phone number is used by more than one person, it's no big deal. The unique id for each record in the person-contacts table doesn't have anything to do with the person-id or the contact-id of that it relates.

If you're familiar with SQL or databases, I'll put it another way: the reference table has a primary key, table A foreign key, and table B foreign key. This is the minimum. For our person-contact relationships, we'll add a few additional pieces: Type and IsActive. You'll note that IsActive is a `bit` type. Bits are the usual method for storing `boolean` (true or false) datatypes in SQL.

| Id | PersonId | ContactId | Type | IsActive |
|:--:|:---:|:---:|:---:|:---:|
| 12 | 214 | 257 | Home | 1 |
| 13 | 214 | 293 | Work | 1 |
| 14 | 356 | 293 | Work | 1 |
| 16 | 412 | 293 | Work | 0 |

From this table, we can conclude that PersonID 214 works at the same location as PersonId 356. PersonId 412 also worked there at some point, but they have deactivated the phone as a contact method. If capturing those types of changes is important, you could also add a CreatedDate and UpdatedDate to the table. For my purposes, I don't really need that information.

You can see how reference tables are used to capture intricate relationships.

## Groups
Our groups need to have the who, what, when, where information. We'll hold off on adding people to the group, either as members or leaders of the group. There will be many members for each group, so we'll use a reference table for that.



Id
: Primary key for this table. I use `int` datatypes, but you can use `GUID` datatypes if you like. Must be unique.
CreatedBy
: UserId of member who created the group.
UpdatedBy
: UserId of last member to update the group. Can be null. Or can default to CreatedBy value.
CreatedDate
: Date the group was created. I use the `datetime` datatype. You could also consider `datetimeoffset` or `smalldatetime`. If you are supporting multiple timezones, `datetimeoffset` is the best choice.
Name
: Title of group.
: `varchar` or `nvarchar` datatype
Type
: Category of group. We have internal categories. Whether you use the categories externally or even with members, this segmentation helps provide access control in the API. One category might be "Children's Group." You can imagine wanting to keep access control on that to a minimum. Or you may have a "Addiction Recovery" category.
: `varchar`, `nvarchar`, or `int` (Use Int if you plan to use a drop-down list or enum datatype in your API.
Description
: Description of the group.
: `varchar` or `nvarchar`. I use `nvarchar(max)` for this field.
Track
: Another segmentation option. The goal for this field is to set up a learning track based on the member's talents, abilities, and gifts. For example, a "Leadership" track might have multiple classes on interpersonal communication, leadership, and conflict resolution. Look at the [Future Enhancements] page for how this will be used.
: `varchar`, `nvarchar`, or `int`. I would recommend using `int.` That allows you to devise as many tracks as you need.
IsFree
: Flag for free courses.
: `bit` for true/false.
IsStaffRequired
: Flag for staffing requirements. This is an internal field, for administrative use, but important to build in from the beginning.
: `bit` for true/false.
IsFull
: Flag for closing registration. I intend to use this to trigger a "Wait List" option on the front-end UI.
: `bit` for true/false.
IsActive
: Flag for class completion status. The API logic will compare today's date with the endDate for the Group. If the endDate is in the future, the class is active.
: `bit` for true/false.
Cost
: Monetary cost associated with the group.
: `int` datatype. It is far easier to multiply a cost by 0.01 to get money on the front-end than it is to pass various decimal values back and forth between C# and Javascript. Trust me on this. Capture your costs in pennies in the database. No one will ever see that, but you will save yourself so much trouble with debugging.
MaxSize
: Maximum group enrollment.
: Choose your datatype wisely. An `int` will get you roughly 2.15 million. A `smallint` will get you 32,767. A `tinyint` will get you 255.
StaffingRequired
: The actual number of staff members needed for this group. Consider a group of 200 people probably requires at least 1 person to coordinate membership, communicate changes to the course, prepare and distribute materials, etc. Think of this as your "volunteer" requirement for the group. *Personal note:* If you don't have enough groups to go around, over-staff your groups. Let people give their time and appreciate it as the gift of service that it truly is.
: `int`
RequiredMaterials
: Any items the members need to acquire for the class. Examples might include: a copy of a specific book, study guide, pen/paper for notes, light jacket for a cold room, or snacks/coffee. Or nothing at all.
: `varchar` or `nvarchar`. I prefer `nvarchar(max)` for flexibility of use.
LeaderComments
: Any specific tips, suggestions, or messages the Group Leader wants to pass to individual Members. I recommend this field be viewable without authentication (i.e., public!).
: `nvarchar(max)`
DaysOfWeek
: List of days on which the group meets. I enter the days of the week separated by commas. This allows me to treat the values like items in a list and display the items in a flexible manner. It also allows me to search for specific days more readily. While this is technically a many-to-one relationship, there are only 7 possibilities. (I know there are more unique values, but that's not the point.) Seven values, especially `string` values can be stored in a single field and parsed either in the API or on the front-end using Javascript. No need to get fancy on this example.
: `nvarchar(200)` You can use a smaller field that exactly limits the value to the seven days of the week, plus commas, plus spaces. I'm ball-parking it here.
StartDate
: First meeting date. Include startTime as the time portion of the date. A group that meets from 1/1 to 2/1 at 7:00 AM to 9:00 AM would have a StartDate of '2019-01-01 07:00:00 AM'. The front-end or API can separate out the time/date info with relative ease.
: `datetimeoffset` or `smalldatetime`
EndDate
: Last meeting date. Same as for StartDate, include the endTime as the time portion of the date.
: `datetimeoffset` or `smalldatetime`

Use the Id field as GroupId on your GroupAddresses and GroupMembers tables.

## Members


## Group Members

## Addresses

## Contact Methods

## Member Addresses

## Member Contacts

## Group Addresses

## Group Contacts

## Auth0 Identities
