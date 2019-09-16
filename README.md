# Vineyard Next API
Vineyard Next is the educational program launched by Vineyard Church Kansas City North in 2019. The purpose of the program is to streamline church member's interaction with small-group signup, class sign-up, and connecting with ministry and service opportunities. This project was initially intended to be a simple web-page to sign up for small-groups with a few clicks. Vineyard staff were less than enthusiastic about their existing system. Members also found it less than user-friendly.

## Links
1. [Quick Start]
1. [Setup]

## Table of Contents
1. [Framework](#framework)
1. [Project Setup)(#project-setup)


## Framework
This project is an ASP.NET Core (v2.0) Web API, using Entity Framework. The database is Microsoft SQL. I chose .NET Core because the framework had vastly improved over .NET MVC 4.x. This project is hosted in Microsoft Azure, which is more friendly (in my limited opinion) to .NET Core implementations. Lastly, I chose to use Auth0 as the Identity provider. Auth0 provides a series of templates for building your application on top of their services. Their templates impacted the direction I took with this project.

The front-end project is built with Angular 8 and Material Design. I chose that framework because I use Angular in my day job. I am familiar with it's strengths and weaknesses. Given the large user-base, long-term support should be stable.

## Project Setup
### Visual Studio Project
As stated above, I built the initial application on the Auth0 [template for an ASP.NET Core Web API](https://auth0.com/docs/quickstart/backend/aspnet-core-webapi).

### SQL Database
I crafted a SQL database for managing the small-group process. For Vineyard, this is more than just the literal small groups of people meeting around the city at various times. This also includes larger classes where new members are introduced to the Vineyard Association's beliefs, doctrine, and mission. "Small groups" includes the various ministries like Convoy of Hope and Beauty for Ashes. Small groups include the various discipleship and encouraing groups like Spiritual Growth and Oaks of Righteousness. "Group" is almost any program Vineyard might host or present. Given the broad definition and usage for "small groups," what other data is needed to support this purpose?

The SQL Database can be broken into XXX parts: entities/objects, relational tables, and administrative tables.
Entities or objects are the main tables for this database. 

### Main Tables
1. Members
2. Groups
3. Families
4. Addresses
5. ContactMetods

### Reference Tables
1. GroupMembers
1. GroupAddresses
1. GroupContacts
1. MemberAddresses
1. MemberContacts
1. Auth0Profiles

Addresses and contact methods are designed to be in a many-to-many relationship with other objects. In other words, Bob, who is a member, has multiple addresses, phone numbers, and email addresses. Some are for work, some are for his home, and some are for the location where he leads a men's group. Bob's phone number might be listed for both Bob and for the men's group. Contact methods can be an email, a phone number, social media username, or even a website. The table is designed to be flexible. The field "ContactMethod" is a string of sufficient length to capture anything you might use to contact a member or group. You could store an address there, but those are better suited for the Addresses table.

Families is another relational table that will have many entries for each family. The FamilyID field is used to identify all members of a family. The MemberID field identifies a single member who is part of that family. Potentially, you could have members that are part of two or more families, due to divorce, remarriage, or a child maturing into adulthood. Ultimately, the rules associated with how you handle familiy membership is up to you. Do what works for your organization.

### Reference Tables
Reference tables are where we store the many-to-many relationships. The basic structure of a reference table is this:

| id | Table A Id | Table B Id | Privacy | Is Active |
|:--:|:----------:|:----------:|:-------:|:---------:|
| 12 |   247      |    342     | 1, 3, 5 |   true    |

I have added fields to capture privacy and active/inactive status. By adding the privacy indicator directly to the relationship, I can filter those records without having to know much beyond the level of privacy I want to target.

The Auth0 table captures the relationship between the various social log-in accounts and each Member. A Member may try to log in using different accounts. Auth0 has methods in place to help you find and combine those identifiers to a single entity. This table is my internal method of keeping track of those many-to-one relationships.

### Data Retention
When it comes to data, I have three very firm beliefs: privacy builds trust, transparency is critical, and treat the sources of your data with respect. So what does that mean? By default, all data is private. This system requires a user to opt-in to sharing, with two exceptions. First, when you sign up for a group, the leader of the group is provided with your name, email and phone. Second, specific pastoral staff and church administrative staff require access to data for day-to-day planning and the business aspects of running a large organization. In this application, you can opt out of even those options. However, we'll still politely ask you to provide an email for identity and critical communications. I do not like deleting records. The database is designed to use a "soft-delete" method. Records have a "isActive" field that accepts a bit or 0/1 for false/true. However, should a member request the deletion of their data, it will be done without hesitation. A future enhancement is to provide members with a download of their data, usage, and record access logs.

### Children
Children's data is private by default. Parents have read/write access to their children's data. At the age of 15, we permit other member's to see limited information on children. At 18, the children default to the highest level of privacy for an adult, unless they have already explicitly modified those privacy levels. A future enhancement will include email notifications on a child's 18th birthday, or shortly thereafter, to advise them to revisit their privacy settings. 

## Child Safety Feature
The Member Search function will log each time a child was returned in a set of search results. This does not mean the search results actually sent the child's information to the UI or that the user will know a child exists in the database.

Here's an example use case: An adult member searches for Lilly Fritz. There are three Lilly Fritz's in the member table, ages 62, 27, and 12. The search will trigger a logging event that stores the user's ID, date of search, search criteria, number of records found, the member ID for each child in the search results, and number of records returned. Should the same member continue to search for children within a specific time range, an automated email is sent to designated staff members for follow-up. While there are a great many legitimate reasons to conduct those searches, we owe it to each other and to our users to identify issues before they become large problems and people are hurt. I will attempt to heavily document this feature so you can modify the process to meet your needs.

### Additional Logging
I'm an Admin for this application. As an admin, I have unlimited access to the data. I have ensured that anything an admin does is logged. If a question is rasied about how the data is being accessed, I want to provide clear records and a trail that shows necessity of access, limited scope access, and demonstrates the trust placed in me is completely justified. You can modify this process to suit your organization's needs.
